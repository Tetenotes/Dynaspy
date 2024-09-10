# DynaSpy: Library Monitoring & Malware Detection Tool

DynaSpy is a straightforward yet powerful tool designed for monitoring the loading of shared libraries on Unix-based systems, specifically macOS. The primary function of DynaSpy is to detect whether a loaded library contains malware, providing an added layer of security to your system.

## Features

- **Shared Library Monitoring:** Keep track of shared libraries as they load on your system.
- **Malware Detection:** Automatically analyze loaded libraries to determine if they contain any malicious code.
- **Cross-Platform Support:** Designed for Unix-based operating systems, with a focus on macOS.
- **Efficient Implementation:** Built as a C# console application using the .NET Core runtime.
- **Dynamic Library Handling:** Utilizes the `libdl` dynamic library to manage the loading process.

## How It Works

DynaSpy operates by interfacing with the `libdl` library to monitor shared libraries as they load. Once a library is detected, DynaSpy analyzes its contents to determine if any malware is present, alerting the user if a threat is found.

## Requirements

- **Operating System:** Unix-based (macOS)
- **Runtime:** .NET Core
- **Dependencies:** `libdl` dynamic library

## Installation

To get started with DynaSpy:

1. Clone this repository:
   ```bash
   git clone https://github.com/yourusername/DynaSpy.git
   ```
2. Navigate to the project directory:
   ```bash
   cd DynaSpy
   ```
3. Build the application:
   ```bash
   dotnet build
   ```
4. Run the tool:
   ```bash
   dotnet run
   ```

## Usage

Upon running DynaSpy, the tool will begin monitoring shared libraries in real-time. Any detected malware will be immediately reported in the console output.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue if you find bugs or have suggestions for new features.


