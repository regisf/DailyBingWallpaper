;
; Daily Bing Wallpaper installer
;
; Use Inno Setup to create the installer
;

#define AppVer GetFileVersion('bin/Release/DailyBingWallpaper.exe')

[Setup]
AppName=BingWallpaper
AppVersion={#AppVer}
WizardStyle=modern
DefaultDirName={autopf}\BingWallpaper
DefaultGroupName=Daily Bing Wallpaper
UninstallDisplayIcon={app}\BingWallPaper.exe
Compression=lzma2
SolidCompression=yes
OutputDir=Installer
LicenseFile=LICENSE.txt
OutputBaseFilename=DailyBingWallpaper-{#AppVer}

[Run]
Filename: {app}\{cm:AppName}.exe; Description: {cm:LaunchProgram,{cm:AppName}}; Flags: nowait postinstall skipifsilent

[CustomMessages]
AppName=BingWallpaper
LaunchProgram=Start Bing Wallpaper after finishing installation

[Files]
Source: "bin/Release/BingWallpaper.exe"; DestDir: "{app}"; DestName: "BingWallpaper.exe"
Source: "bin/Release/WindowsBase.dll"; DestDir: "{app}"; DestName: "WindowsBase.dll"
Source: "README.md"; DestDir: "{app}"
Source: "LICENSE.txt"; DestDir: "{app}"

[Icons]
Name: "{group}\Daily Bing Wallpaper"; Filename: "{app}\BingWallpaper.exe"

[Code]
(* This code (c) Christoph Nahr 2010 and later see: http://www.kynosarges.de/DotNetVersion.html *) 
function IsDotNetDetected(version: string; service: cardinal): boolean;
var
    key, versionKey: string;
    install, release, serviceCount, versionRelease: cardinal;
    success: boolean;
begin
    versionKey := version;
    versionRelease := 0;

    // .NET 1.1 and 2.0 embed release number in version key
    if version = 'v1.1' then begin
        versionKey := 'v1.1.4322';
    end else if version = 'v2.0' then begin
        versionKey := 'v2.0.50727';
    end

    // .NET 4.5 and newer install as update to .NET 4.0 Full
    else if Pos('v4.', version) = 1 then begin
        versionKey := 'v4\Full';
        case version of
          'v4.5':   versionRelease := 378389;
          'v4.5.1': versionRelease := 378675; // 378758 on Windows 8 and older
          'v4.5.2': versionRelease := 379893;
          'v4.6':   versionRelease := 393295; // 393297 on Windows 8.1 and older
          'v4.6.1': versionRelease := 394254; // 394271 before Win10 November Update
          'v4.6.2': versionRelease := 394802; // 394806 before Win10 Anniversary Update
          'v4.7':   versionRelease := 460798; // 460805 before Win10 Creators Update
          'v4.7.1': versionRelease := 461308; // 461310 before Win10 Fall Creators Update
          'v4.7.2': versionRelease := 461808; // 461814 before Win10 April 2018 Update
          'v4.8':   versionRelease := 528040; // 528049 before Win10 May 2019 Update
        end;
    end;

    // installation key group for all .NET versions
    key := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\' + versionKey;

    // .NET 3.0 uses value InstallSuccess in subkey Setup
    if Pos('v3.0', version) = 1 then begin
        success := RegQueryDWordValue(HKLM, key + '\Setup', 'InstallSuccess', install);
    end else begin
        success := RegQueryDWordValue(HKLM, key, 'Install', install);
    end;

    // .NET 4.0 and newer use value Servicing instead of SP
    if Pos('v4', version) = 1 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Servicing', serviceCount);
    end else begin
        success := success and RegQueryDWordValue(HKLM, key, 'SP', serviceCount);
    end;

    // .NET 4.5 and newer use additional value Release
    if versionRelease > 0 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Release', release);
        success := success and (release >= versionRelease);
    end;

    result := success and (install = 1) and (serviceCount >= service);
end;


function InitializeSetup(): Boolean;
begin
    if not IsDotNetDetected('v4.7', 0) then 
    begin
        MsgBox('MyApp requires Microsoft .NET Framework 4.7.'#13#13
            'Please use Windows Update to install this version,'#13
            'and then re-run the MyApp setup program.', mbInformation, MB_OK);
        result := false;
    end 
    else
        result := true;
end;
