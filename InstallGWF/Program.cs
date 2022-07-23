using MediaDevices;
using System.IO.Compression;

var devices = MediaDevice.GetDevices();
MediaDevice garminDevice;

while (true)
{
    int count = devices.Count();
    if (count == 0)
    {
        Console.WriteLine("No Garmin device found, please plugin your Garmin device.");
        Console.WriteLine("Press any key to continue or ctrl+c to exit.");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Available devices: ");
        for (int i = 1; i <= count; i++)
        {
            var device = devices.ElementAt(i - 1);
            Console.WriteLine($"{i}: {device.FriendlyName}");
        }
        if (count == 1 && devices.ElementAt(0).Manufacturer == "Garmin")
        {
            garminDevice = devices.ElementAt(0);
            Console.WriteLine($"Auto select device: {garminDevice.FriendlyName}");
            break;
        }
        else
        {
            Console.WriteLine("Enter the number to select the device (or press enter to refresh the device list):");
            var sel = Console.ReadLine();

            if (int.TryParse(sel, out int iSel) && iSel > 0 && iSel <= count)
            {
                garminDevice = devices.ElementAt(iSel - 1);
                break;
            }
        }
    }
    devices = MediaDevice.GetDevices();
}

string? filename = null;
if (args.Length == 0)
{
    Console.WriteLine("Type or drag url address, zip file, or prg file here, and press Enter key:");
    filename = Console.ReadLine();
}
else
{
    filename = args[0];
}

if (string.IsNullOrEmpty(filename))
{
    // usage
    Console.WriteLine($@"To install Garmin app to your device, you can either drag and drop the downloaded zip file or unzipped prg file to this app, or run one of the following in command lines:

    InstallGWF xxxxx.zip
or
    InstallGWF xxxxx.prg
or
    InstallGWF https://garmin.watchfacebuilder.com/watchface/xxxxx/
");
    Console.ReadKey();
    return;
}

// download file from website
if (filename.StartsWith("https://"))
{
    Console.Write("Downloading...");

    // get the download url
    if (!filename.Contains("file=app")) filename += (filename.Contains("?") ? "&" : "?") + "file=app";

    var httpClient = new HttpClient();
    using (var stream = await httpClient.GetStreamAsync(filename))
    {
        string tmp = Path.GetTempFileName();
        using (var fileStream = new FileStream(tmp + ".zip", FileMode.CreateNew))
        {
            await stream.CopyToAsync(fileStream);
        }
        filename = tmp + ".zip";
    }
}

// process input file
var ext = Path.GetExtension(filename);
if (".zip".Equals(ext, StringComparison.OrdinalIgnoreCase))
{
    Console.Write("Unzipping...");
    try
    {
        using (var za = ZipFile.OpenRead(filename))
        {
            foreach (var entry in za.Entries)
            {
                if (entry.FullName.EndsWith(".prg", StringComparison.OrdinalIgnoreCase))
                {
                    string tmp = Path.GetTempFileName();
                    entry.ExtractToFile(tmp + ".prg");
                    Console.Write("Copying...");
                    garminDevice.Connect();
                    var driver = garminDevice.GetDrives()?.FirstOrDefault();
                    var desc = "Primary";
                    if (driver != null)
                    {
                        desc = driver.RootDirectory.Name;
                    }
                    var destFileName = @$"{desc}\GARMIN\Apps\{Path.GetFileNameWithoutExtension(entry.FullName)}.prg";
                    if (garminDevice.FileExists(destFileName)) garminDevice.DeleteFile(destFileName);
                    garminDevice.UploadFile(tmp + ".prg", destFileName);
                    garminDevice.Disconnect();
                    Console.WriteLine(Path.GetFileName(destFileName) + ". Done!");
                }
            }
        }
    }
    catch
    {
        Console.WriteLine("Invalid zip file.");
    }
}
else if (".prg".Equals(ext, StringComparison.OrdinalIgnoreCase))
{
    Console.Write("Copying...");
    garminDevice.Connect();
    var sid = garminDevice.FunctionalObjects(FunctionalCategory.Storage).FirstOrDefault();
    var driver = garminDevice.GetDrives()?.FirstOrDefault();
    var desc = "Primary";
    if (driver != null)
    {
        desc = driver.RootDirectory.Name;
    }
    var destFileName = @$"{desc}\GARMIN\Apps\{Path.GetFileNameWithoutExtension(filename)}.prg";
    if (garminDevice.FileExists(destFileName)) garminDevice.DeleteFile(destFileName);
    garminDevice.UploadFile(filename, destFileName);
    garminDevice.Disconnect();
    Console.WriteLine(Path.GetFileName(destFileName) + ". Done!");
}
else
{
    Console.WriteLine("Invalid input file.");
}
Console.ReadKey();
