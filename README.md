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

To create the project use the `dotnet new` command:

```
$ mkdir TestApp
$ cd TestApp
$ dotnet new aardvark.ui --backend opengl
```

or alternatively:

```
$ dotnet new aardvark.ui --name TestApp --backend opengl
```

There are two backends that are available for aardvark applications: OpenGL and Vulkan.
You can choose between them using parameter `--backend`. You can see the description of the parameter by running:

```
$ dotnet new aardvark.ui --help
```

After the test application has been created, it can be built via the `build.cmd` or `build.sh` script.

# Build

To build and test templates from package use `aardpack` and install the resulting `*.nupkg`:

```
$ dotnet tool restore
$ dotnet aardpack Aardvark.Templates.csproj
$ dotnet new -i .\bin\pack\*.nupkg
```

# Packages

Update `RELEASE_NOTES.md` to trigger the CI to build and push a new Aardvark.Templates package.