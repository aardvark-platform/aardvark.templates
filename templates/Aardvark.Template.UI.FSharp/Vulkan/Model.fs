namespace Aardvark.Template.UI.Model

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
