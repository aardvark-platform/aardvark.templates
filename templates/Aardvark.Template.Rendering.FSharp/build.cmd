@echo off

CALL restore.cmd
dotnet build src\Aardvark.Template.Rendering\Aardvark.Template.Rendering.fsproj
