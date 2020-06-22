open Aardvark.Template.UI

open Aardvark.Base
open Aardvark.UI
open Aardvark.Application.Slim
open Aardium
open Suave

[<EntryPoint>]
let main args =
    Aardvark.Init()
    Aardium.init()

    let app = new OpenGlApplication()

    WebPart.startServer 4321 [
        MutableApp.toWebPart' app.Runtime false (App.start App.app)
    ] |> ignore
    
    Aardium.run {
        title "Aardvark rocks \\o/"
        width 1024
        height 768
        url "http://localhost:4321/"
    }

    0
