@echo off

dotnet tool restore
dotnet paket restore
dotnet build src\Aardvark.Template.Rendering\Aardvark.Template.Rendering.fsproj
