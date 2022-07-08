using MediaDevices;
using System.IO.Compression;

if (args.Length == 0)
{
    Console.WriteLine($@"To install Garmin app to your device, you can either drag and drop the downloaded zip file or unzip prg file to this app, or run the following in command line:

    InstallGWF xxxxx.zip
or
    InstallGWF xxxxx.prg

where xxxxx.zip is what you download from watchfacebuilder website.");
    Console.ReadKey();
    return;
}
var devices = MediaDevice.GetDevices();
var garminDevice = devices.First(d => d.Manufacturer == "Garmin");
if (garminDevice == null)
{
    Console.WriteLine("No Garmin device found.");
    Console.ReadKey();
    return;
}
var ext = Path.GetExtension(args[0]);
if (".zip".Equals(ext, StringComparison.OrdinalIgnoreCase))
{
    using (var za = ZipFile.OpenRead(args[0]))
    {
        foreach (var entry in za.Entries)
        {
            if (entry.FullName.EndsWith(".prg", StringComparison.OrdinalIgnoreCase))
            {
                string tmp = Path.GetTempFileName();
                entry.ExtractToFile(tmp + ".prg");
                var destFileName = @$"Primary\GARMIN\Apps\{Path.GetFileNameWithoutExtension(entry.FullName)}.prg";
                garminDevice.Connect();
                if (garminDevice.FileExists(destFileName)) garminDevice.DeleteFile(destFileName);
                garminDevice.UploadFile(tmp + ".prg", destFileName);
                garminDevice.Disconnect();
                Console.WriteLine(Path.GetFileName(destFileName) + " copied successfully");
            }
        }
    }
}
else if (".prg".Equals(ext, StringComparison.OrdinalIgnoreCase))
{
    var destFileName = @$"Primary\GARMIN\Apps\{Path.GetFileNameWithoutExtension(args[0])}.prg";
    garminDevice.Connect();
    if (garminDevice.FileExists(destFileName)) garminDevice.DeleteFile(destFileName);
    garminDevice.UploadFile(args[0], destFileName);
    garminDevice.Disconnect();
    Console.WriteLine(Path.GetFileName(destFileName) + " copied successfully");
}
else
{
    Console.WriteLine("Invalid file");
}
Console.ReadKey();

// test