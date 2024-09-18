# Full Processor User

A small Windows app that keeps the processor at full load until you stop it. Written in C# with Windows Forms on .NET Framework 3.5.

## Features

- **Start** runs busy loops on threads with Highest priority: one for each processor core reported by Windows (`NumberOfCores` from WMI, added up over all processors).
- **Stop** ends the threads; **Start** can then run them again.
- **exit** stops the threads and closes the app. Closing the window stops them too.
- **about** shows who wrote the app.

While it runs, the PC can feel slow and a laptop gets warm: that is the point. Press **Stop** when you are done.

## Requirements

Windows with .NET Framework 3.5 (it includes 2.0). On Windows 10 and 11 it is an optional feature: if it isn't installed, Windows offers to add it the first time the app starts, or turn it on in "Turn Windows features on or off".

## Usage

Download `Full-Processor-User-v1.0.2.7z` from [Releases](https://github.com/Mohammad-Diab/Full-Processor-User/releases), extract it, and run `Full Processor User.exe`. There is no installer.

The exe is not signed, so Windows SmartScreen may warn the first time you run it: click **More info**, then **Run anyway**.

## Building

```
git clone https://github.com/Mohammad-Diab/Full-Processor-User.git
```

Open `Full Processor User.sln` in Visual Studio and build, or run:

```
MSBuild "Full Processor User.sln" /p:Configuration=Release
```

The exe is written to `Full Processor User\bin\Release`.

## Author

Mohammad Diab

## License

[Apache 2.0](LICENSE)
