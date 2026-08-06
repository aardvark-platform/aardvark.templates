open Aardvark.Template.UI

open Aardvark.Base
open Aardvark.Application.Slim
open Aardvark.UI
open Aardvark.UI.Giraffe
open Aardium

[<EntryPoint>]
let main args =
    Aardvark.Init()
    Aardium.Init()

    #if (backend = "opengl")
    use app = new OpenGlApplication()
    #elif (backend = "vulkan")
    use app = new VulkanApplication()
    #endif
    use mapp = App.start App.app

    Server.startLocalhost 4321 mapp.CancellationToken [
        MutableApp.toWebPart' app.Runtime false mapp
    ] |> ignore

    Aardium.run {
        title "Aardvark rocks \\o/"
        width 1024
        height 768
        url "http://localhost:4321/"
#if DEBUG
        debug true
        log (fun msg -> Report.Line(2, $"[Aardium] {msg}"))
#else
        debug false
#endif
    }

    0