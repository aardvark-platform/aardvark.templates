﻿namespace Aardvark.Template.UI

open FSharp.Data.Adaptive

open Aardvark.Base
open Aardvark.Rendering
open Aardvark.UI
open Aardvark.UI.Primitives

open Aardvark.Template.UI.Model

type Message =
    | ToggleModel
    | CameraMessage of FreeFlyController.Message

module App =

    let initial = { currentModel = Box; cameraState = FreeFlyController.initial }

    let update (m : Model) (msg : Message) =
        match msg with
        | ToggleModel ->
            match m.currentModel with
            | Box -> { m with currentModel = Sphere }
            | Sphere -> { m with currentModel = Box }

        | CameraMessage msg ->
            { m with cameraState = FreeFlyController.update m.cameraState msg }

    let view (m : AdaptiveModel) =

        let frustum =
            Frustum.perspective 60.0 0.1 100.0 1.0
                |> AVal.constant

        let sg =
            m.currentModel |> AVal.map (function
                | Box -> Sg.box' C4b.Red (Box3d(-V3d.III, V3d.III))
                | Sphere -> Sg.sphere' 5 C4b.Green 1.0
            )
            |> Sg.dynamic
            |> Sg.shader {
                do! DefaultSurfaces.trafo
                do! DefaultSurfaces.simpleLighting
            }

        let att =
            [
                style "position: fixed; left: 0; top: 0; width: 100%; height: 100%"
            ]

        body [] [
            FreeFlyController.controlledControl m.cameraState CameraMessage frustum (AttributeMap.ofList att) sg

            div [style "position: fixed; left: 20px; top: 20px"] [
                button [onClick (fun _ -> ToggleModel)] [text "Toggle Model"]
            ]
        ]

    let app : App<Model, AdaptiveModel, Message> =
        {
            initial = initial
            update = update
            view = view
            threads = fun m -> m.cameraState |> FreeFlyController.threads |> ThreadPool.map CameraMessage
            unpersist = Unpersist.instance
        }