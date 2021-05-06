.NET Core SDK templates for bootstrapping new Aardvark projects.

# Install

```
$ dotnet new -i Aardvark.Templates
```

# How to create project

After installation two templates will be added:

```
$ dotnet new

...

Templates                                         Short Name              Language          Tags
-------------------------------------------------------------------------------------------------------
Aardvark.Rendering Application                    aardvark.rendering      F#                Aardvark
Aardvark.UI Application                           aardvark.ui             F#                Aardvark
```

To create project use `dotnet new` command:

```
$ mkdir TestApp
$ cd TestApp
$ dotnet new aardvark.ui --backend opengl
```

There are two backends that are available for aardvark applications: OpenGL and Vulkan.
You can choose between them using parameter `--backend`. You can see description of the parameter:

```
$ dotnet new aardvark.ui --help
```

After creation our test application let's build and run it:

```
$ dotnet tool restore
$ dotnet paket restore
$ dotnet run -c Release -p .\src\TestApp\TestApp.fsproj
```

# Build

To build and test templates from package use `dotnet pack`:

```
$ dotnet pack -c Release
$ dotnet new -i .\bin\Release\Aardvark.Templates.2.0.0.nupkg
```

All templates' projects are also runnable from repository, it might be useful for testing:

```
$ cd .\templates\Aardvark.Template.Rendering.FSharp\OpenGL\
$ dotnet tool restore
$ dotnet paket restore
$ dotnet run -c Release -p .\src\Aardvark.Template.Rendering\Aardvark.Template.Rendering.fsproj
```