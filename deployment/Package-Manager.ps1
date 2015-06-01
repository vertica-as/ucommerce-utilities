﻿$ErrorActionPreference = "Stop"
$script_directory = Split-Path -Parent $PSCommandPath

$settings = @{
    "src" = @{
        "utilities" = Resolve-Path $script_directory\..\src\Utilities
		"ucommerce_core_libraries" = Resolve-Path $script_directory\..\src\UCommerce.CoreLibraries
    }
    "tools" = @{
        "nuget" = Resolve-Path $script_directory\..\tools\NuGet\NuGet.exe
    }
	"packages" = @{
		#"destination" = "\\nuget.vertica.dk\nuget.vertica.dk\root\Packages"
		"destination" = "D:\Dropbox\Development\NuGet.Packages"
	}
}

foreach ($project in $settings.src.Keys) {

    cd $settings.src[$project]

    # remove .nupkg files
    Get-ChildItem | Where-Object { $_.Extension -eq ".nupkg" } | Remove-Item

	if (Test-Path "NuGet-Before-Pack.ps1") {
		
		$beforePack = Join-Path $settings.src[$project] "NuGet-Before-Pack.ps1"

		Invoke-Expression $beforePack
	}

	# https://docs.nuget.org/consume/command-line-reference
    &$settings.tools.nuget pack -Build -Properties Configuration=Release -IncludeReferencedProjects

	if (Test-Path "NuGet-After-Pack.ps1") {
		
		$afterPack = Join-Path $settings.src[$project] "NuGet-After-Pack.ps1"

		Invoke-Expression $afterPack
	}

    Get-ChildItem | Where-Object { $_.Extension -eq ".nupkg" } | Move-Item -Destination $settings.packages.destination -Force
}

cd $script_directory