# InstallGWF
Install Garmin watch face app to your device (Windows only). Download the released zip file and unzip it to a folder, double click InstallGWF.exe to run.

You will need to have .Net Core runtime installed in your computer before you can run this.  Install it here: https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime

Connect your device via USB cable, then double click EXE file. You can enter your watch face app's url, or drag the downloaded zip file or unzipped prg file to the program, and the installer will copy the app to your device.  For your own app (not shared), you can copy and paste the link under the "Share this url".

# Linux Installation
1. Install .Net Core runtime
Arch Linux example:
```yay -S dotnet-sdk-6.0```
2. Verify installation
```dotnet --version``` this should show 6.0.0
2. Build the project
```dotnet build```
3. Run the project
```dotnet run```

# Grab installer

[Link to releases](https://github.com/joshuahxh/InstallGWF/releases)
