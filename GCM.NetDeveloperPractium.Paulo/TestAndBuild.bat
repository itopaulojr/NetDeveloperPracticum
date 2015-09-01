@echo off
set currentPath=%cd%
set msTestLocation="C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\"
set dotNetLocation="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\"

set solutionPath="%currentPath%\GCM.NetDeveloperPractium.Paulo.sln"
set unitTestDllLocation="%currentPath%\GCM.NetDeveloperPractium.Paulo.Test\bin\Debug\GCM.NetDeveloperPractium.Paulo.Test.dll"

echo %solutionPath%
echo %msTestLocation%

%msTestLocation%MSTest.exe /testcontainer:%unitTestDllLocation%

%dotNetLocation%MsBuild.exe %solutionPath% /t:Build /p:Configuration=Release /p:TargetFramework=v4.5



