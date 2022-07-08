using MediaDevices;
using System.IO.Compression;

var devices = MediaDevice.GetDevices();
MediaDevice garminDevice;

// check if there are any connected garmin devices
if (devices.Count() == 0 || (garminDevice = devices.First(d => d.Manufacturer == "Garmin")) == null)
{
    Console.WriteLine("No Garmin device found.");
    Console.ReadKey();
    return;
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
                    var destFileName = @$"Primary\GARMIN\Apps\{Path.GetFileNameWithoutExtension(entry.FullName)}.prg";
                    garminDevice.Connect();
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
    var destFileName = @$"Primary\GARMIN\Apps\{Path.GetFileNameWithoutExtension(filename)}.prg";
    garminDevice.Connect();
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
