using System.IO.Compression;

// Entry point
public static class Program
{
    public static async Task Main(string[] args)
    {
        // The device mount path, e.g. /run/user/1000/gvfs/mtp:host=XXX or /media/youruser/GARMIN
        string? garminMountPath = null;

        // If you want to automatically guess or prompt for the mount path:
        while (true)
        {
            Console.WriteLine("Enter the mount path of your Garmin device (or leave blank to re-prompt).");
            Console.Write("Mount path: ");
            garminMountPath = Console.ReadLine()?.Trim('"', ' ');

            if (!string.IsNullOrEmpty(garminMountPath) && Directory.Exists(garminMountPath))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid or empty mount path. Please try again.\n");
            }
        }

        // At this point, the user has specified a valid mount path
        Console.WriteLine($"Using device mount path: {garminMountPath}");

        // Check if the user passed a file argument (zip, prg, set) or a URL
        string? filename = null;
        if (args.Length == 0)
        {
            Console.WriteLine("Type or drag a URL, zip file, or .prg file here, then press Enter:");
            filename = Console.ReadLine()?.Trim('"', ' ');
        }
        else
        {
            filename = args[0];
        }

        if (string.IsNullOrEmpty(filename))
        {
            // Show usage
            ShowUsage();
            return;
        }

        // (1) If it's a URL, download the file
        if (filename.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Downloading...");

            // Make sure the URL includes the app param
            if (!filename.Contains("file=app"))
            {
                filename += (filename.Contains("?") ? "&" : "?") + "file=app";
            }

            var httpClient = new HttpClient();
            var tmpZip = Path.GetTempFileName() + ".zip";

            using (var stream = await httpClient.GetStreamAsync(filename))
            using (var fileStream = new FileStream(tmpZip, FileMode.CreateNew))
            {
                await stream.CopyToAsync(fileStream);
            }
            
            filename = tmpZip;
        }

        // (2) Process the local file (.zip, .prg, .SET, etc.)
        var ext = Path.GetExtension(filename);
        if (".zip".Equals(ext, StringComparison.OrdinalIgnoreCase))
        {
            await InstallFromZip(filename, garminMountPath);
        }
        else if (".prg".Equals(ext, StringComparison.OrdinalIgnoreCase))
        {
            InstallPrg(filename, garminMountPath);
        }
        else if (".set".Equals(ext, StringComparison.OrdinalIgnoreCase))
        {
            InstallSet(filename, garminMountPath);
        }
        else
        {
            Console.WriteLine("Invalid input file.");
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    private static void ShowUsage()
    {
        Console.WriteLine(@"
Usage examples:
    InstallGWF mywatchface.zip
    InstallGWF watchface.prg
    InstallGWF https://garmin.watchfacebuilder.com/watchface/xxxx/

After running, you'll be prompted for the mount path of your Garmin device on Linux.

Make sure your Garmin is connected via USB and mounted, or is accessible via GVFS (e.g. /run/user/1000/gvfs/mtp:host=xxxx).
");
    }

    /// <summary>
    /// Extracts all .prg files from the ZIP and installs them into the Garmin's /GARMIN/Apps folder.
    /// </summary>
    private static async Task InstallFromZip(string zipFile, string garminMountPath)
    {
        Console.Write("Unzipping...");
        try
        {
            using (var za = ZipFile.OpenRead(zipFile))
            {
                foreach (var entry in za.Entries)
                {
                    if (entry.FullName.EndsWith(".prg", StringComparison.OrdinalIgnoreCase))
                    {
                        // Extract the .prg to a temp file
                        var tmpPrg = Path.GetTempFileName() + ".prg";
                        entry.ExtractToFile(tmpPrg, true);

                        // Copy to Garmin device
                        Console.Write("Copying app...");
                        var destFileName = Path.Combine(garminMountPath, "GARMIN", "Apps",
                                            Path.GetFileName(entry.FullName));

                        // Ensure the Apps folder exists
                        Directory.CreateDirectory(Path.GetDirectoryName(destFileName) 
                                                  ?? Path.Combine(garminMountPath, "GARMIN", "Apps"));

                        // If the file already exists, remove it
                        if (File.Exists(destFileName))
                        {
                            File.Delete(destFileName);
                        }

                        // Copy
                        File.Copy(tmpPrg, destFileName);
                        
                        Console.WriteLine($"{Path.GetFileName(destFileName)}. Done!");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error unzipping or copying files: {ex.Message}");
        }
    }

    /// <summary>
    /// Copies a .prg file directly into /GARMIN/Apps.
    /// </summary>
    private static void InstallPrg(string prgFile, string garminMountPath)
    {
        try
        {
            Console.Write("Copying app...");

            var destFileName = Path.Combine(garminMountPath, "GARMIN", "Apps",
                                Path.GetFileName(prgFile));

            // Ensure the Apps folder exists
            Directory.CreateDirectory(Path.GetDirectoryName(destFileName) 
                                      ?? Path.Combine(garminMountPath, "GARMIN", "Apps"));

            if (File.Exists(destFileName))
            {
                File.Delete(destFileName);
            }

            File.Copy(prgFile, destFileName);
            Console.WriteLine($"{Path.GetFileName(destFileName)}. Done!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error copying .prg file: {ex.Message}");
        }
    }

    /// <summary>
    /// Copies a .SET file to /GARMIN/Apps/Settings.
    /// </summary>
    private static void InstallSet(string setFile, string garminMountPath)
    {
        try
        {
            Console.Write("Copying setting file...");

            var destFileName = Path.Combine(garminMountPath, "GARMIN", "Apps", "Settings",
                                Path.GetFileName(setFile));

            // Ensure the Settings folder exists
            Directory.CreateDirectory(Path.GetDirectoryName(destFileName) 
                                      ?? Path.Combine(garminMountPath, "GARMIN", "Apps", "Settings"));

            if (File.Exists(destFileName))
            {
                File.Delete(destFileName);
            }

            File.Copy(setFile, destFileName);
            Console.WriteLine($"{Path.GetFileName(destFileName)}. Done!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error copying .SET file: {ex.Message}");
        }
    }
}
