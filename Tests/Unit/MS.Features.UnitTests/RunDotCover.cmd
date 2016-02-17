@echo off

set toolFilePath=c:\TeamCity\buildAgent\tools\dotCover\dotCover.exe
set vsTestFilePath=C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe
set workingDir=.
set testAssembly=c:\Projects\Rhenus.HD.Features.Solution\Tests\Unit\Rhenus.HD.Features.UnitTests\bin\Debug\Rhenus.HD.Features.UnitTests.dll

%toolFilePath% analyse /ReportType=HTML /Output=dotCover.html "/TargetExecutable=%vsTestFilePath%" "/TargetWorkingDir=%workingDir%" "/TargetArguments=%testAssembly%"