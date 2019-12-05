# Introduction 
tldr is a project to help read and write header ("envelope") files used for submitting AIFMDXML/XBRL reports
to Finanssivalvonta - Finnish Financial Supervisory Authority (FIN-FSA)

## Specifications
All specifications should be found in FIN-FSA (and Eurofiling) website, eg.

[https://www.finanssivalvonta.fi/en/reporting/regulatory-reporting/](https://www.finanssivalvonta.fi/en/reporting/regulatory-reporting/)

[http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader.xsd](http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader.xsd)

## Caveat
The library DOES NOT VALIDATE CONTENTS of the header, ie. no checks are made for entity identifiers, dates/times, email address etc.
Any content should be checked by other means after reading and/or before writing the header file.

# Environment
I use [Visual Studio Code](https://code.visualstudio.com/) 
on [Arch Linux](https://www.archlinux.org/)

Code is written in [C#](https://docs.microsoft.com/en-us/dotnet/csharp/index) 7.0, targeting 
[.NET Standard 2.0](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md) / 
[.NET Framework 4.5.2](https://docs.microsoft.com/en-us/dotnet/framework/)


Test framework is [xUnit.net](https://xunit.github.io/)

and test code is targeting [.NET Core 2.1](https://docs.microsoft.com/en-us/dotnet/core/)

## Diwen.FivaHeaders
.NET Standard 2.0 / .NET Framework 4.5.2 library

### License:
GNU Lesser General Public License v3.0

[http://www.gnu.org/licenses/gpl.txt](http://www.gnu.org/licenses/gpl.txt)

[http://www.gnu.org/licenses/lgpl.txt](http://www.gnu.org/licenses/lgpl.txt)


## Diwen.FivaHeaders.Test
.NET Core 2.1 test project with code and data for testing the library, also serving as documentation

### License
[Free Public License 1.0.0](https://opensource.org/licenses/FPL-1.0.0)
