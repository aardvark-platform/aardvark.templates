Experimental .NET Core template for Aardvark.UI applications.

See [`template.json`](./Aardvark.Template.UI.FSharp/.template.config/template.json)

# How to test

First you need to install template (it's not available on NuGet right now):

```
$ git clone https://github.com/gsomix/aardvark.temlpate.ui.git
$ dotnet new --install .\aardvark.temlpate.ui\Aardvark.Template.UI.FSharp\
```

Then create new application:

```
$ mkdir TestApp
$ cd TestApp
$ dotnet new aardvark.ui --backend opengl
```

For now there are two backends that are available for aardvark applications: OpenGL and Vulkan.
You can choose between then using parameter `--backend`. You can see description of the parameter:

```
$ dotnet new aardvark.ui --help
```

After creation our test application let's build and run it:

```
$ dotnet build
$ dotnet run -c Release
```
