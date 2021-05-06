namespace Aardvark.Template.UI.Model

open System
open FSharp.Data.Adaptive

open Aardvark.Base
open Aardvark.UI.Primitives
open Adaptify

type Primitive =
    | Box
    | Sphere

[<ModelType>]
type Model =
    {
        currentModel    : Primitive
        cameraState     : CameraControllerState
    }
