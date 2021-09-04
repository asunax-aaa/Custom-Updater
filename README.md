# Custom-Updater
A universal auto-updater, designed specfically for my custom Synapse UIs.

# Usage
Command line arguments:

`Updater.exe [PROCESS_PATH] [PROCESS_NAME] [PROCESS_URL] [ENTIRES]`
- PROCESS_PATH: The directory that the main .EXE is located in.
- PROCESS_NAME: The process to start after downloading required files.
- PROCESS_URL: The process URL to which download new process from.
- ENTIRES: A string containing file entries seperated by `|`. A file entry will contain the file download URL + `|` + path.
  - E.g: "asunax.com/CustomUI/download`|`C:\Users\asuna\Desktop\CustomSynapseUI\SynapseUI.exe"
 
