

[<img src="https://diwen.visualstudio.com/_apis/public/build/definitions/a8e7698a-4776-4376-9e15-b4998e54def7/4/badge"/>](https://diwen.visualstudio.com/tldr/_build/index?definitionId=4)

# Introduction 
tldr is a project to help read and write header ("envelope") files used for submitting AIFMDXML/XBRL reports
to Finanssivalvonta - Finnish Financial Supervisory Authority (FIN-FSA)

## Specifications
All specifications should be found in FIN-FSA (and Eurofiling) website, eg.

[Description of electronic AIFMD reporting](http://www.finanssivalvonta.fi/en/Regulation/International_Projects/AIFMD/reporting/Documents/AIFMD_description_of_electronic_reporting_01042016.pdf)

[Konekielisen tiedonvälityksen kuvaus, Solvenssi II -raportointi, taksonomia 2.1.0](http://www.fin-fsa.fi/Documents/SII_Full_konekielisen_tietojenvalityksen_kuvaus_versio_2_2_netti.pdf)

[Yhteiseurooppalainen raportointi (COREP) - Konekielisen tietojenvälityksen kuvaus](http://www.finanssivalvonta.fi/fi/Saantely/Maarayskokoelma/Uusi/Documents/2013_26/EBA_ITS_konekielisen_tietojenvalityksen_kuvaus_2017.pdf)

[http://www.finanssivalvonta.fi/fi/Raportointi/xbrl/Documents/FivaStandardHeader.xsd](http://www.finanssivalvonta.fi/fi/Raportointi/xbrl/Documents/FivaStandardHeader.xsd)

[www.finanssivalvonta.fi/fi/Raportointi/xbrl/Documents/FivaAIFMDHeader.xsd](www.finanssivalvonta.fi/fi/Raportointi/xbrl/Documents/FivaAIFMDHeader.xsd)

[http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader.xsd](http://www.eurofiling.info/eu/fr/esrs/Header/BasicHeader.xsd)

# Environment
I use [Visual Studio Code](https://code.visualstudio.com/) 
on [Ubuntu 17.10](https://www.ubuntu.com/desktop/1710)

Code is written in [C#](https://docs.microsoft.com/en-us/dotnet/csharp/index) 7.0, targeting 
[.NET Standard 2.0](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md) / 
[.NET Core 2.0](https://docs.microsoft.com/en-us/dotnet/core/)

Test framework is [xUnit.net](https://xunit.github.io/)

## Diwen.FivaHeaders
.NET Standard 2.0 library

### License:
GNU Lesser General Public License v3.0

[http://www.gnu.org/licenses/gpl.txt](http://www.gnu.org/licenses/gpl.txt)

[http://www.gnu.org/licenses/lgpl.txt](http://www.gnu.org/licenses/lgpl.txt)


## Diwen.FivaHeaders.Test
.NET Core 2.0 test project with code and data for testing the library, also serving as documentation

### License
[Free Public License 1.0.0](https://opensource.org/licenses/FPL-1.0.0)
