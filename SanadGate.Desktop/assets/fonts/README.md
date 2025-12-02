IBM Plex Sans Arabic

This folder is intended to contain the IBM Plex Sans Arabic font used by the application.

Please download the font file `IBMPlexSansArabic-Regular.ttf` from an official source (e.g. Google Fonts or the IBM Plex GitHub repo)
and place it in this folder. The project file already includes the files under `assets/fonts/` as resources.

After placing the `.ttf` file, rebuild the project so WPF can load the embedded font.

Example (from repository root):
```bash
# download manually and then:
# cp /path/to/IBMPlexSansArabic-Regular.ttf SanadGate.Desktop/assets/fonts/
dotnet build SanadGate.Desktop
```

If you want, I can attempt to download and add the font automatically if you permit network access.
# IBM Plex Sans Arabic Font Files

This directory contains the IBM Plex Sans Arabic font files used in the SanadGate Desktop application.

## Required Files:
- IBMPlexSansArabic-Regular.ttf
- IBMPlexSansArabic-Medium.ttf
- IBMPlexSansArabic-Bold.ttf

## Installation Instructions:

Download the IBM Plex Sans Arabic font from:
https://github.com/IBM/plex/releases

Or from Google Fonts:
https://fonts.google.com/specimen/IBM+Plex+Sans+Arabic

Copy the TTF files to this directory.

## Font License:
IBM Plex Sans Arabic is licensed under the SIL Open Font License (OFL).
See: https://github.com/IBM/plex/blob/master/LICENSE.txt
