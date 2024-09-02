# Kairos

A complete framework for data control and composition in [vvvv](http://visualprogramming.net)

[![Matrix](https://img.shields.io/matrix/VL.Kairos:matrix.org?label=chat%20on%20element&logo=element&style=flat-square)](https://app.element.io/#/room/#VL.Kairos:matrix.org) [![vvvv](https://img.shields.io/static/v1?label=MADE%20WITH&message=VVVV&color=191919&style=flat-square)](https://visualprogramming.net/)

![VL.Kairos banner](/img/banner.png)

## Requirements

Kairos works with the latest vvvv gamma 5.2. Get it [here](http://visualprogramming.net)

## Installing

- Go to Gamma's Quad menu > Manage Nugets > Commandline and type

```
nuget install VL.Kairos
```
- Press Enter and wait the ending of the installation process
- For more information on nugets and how to use them in vvvv, click [here](https://thegraybook.vvvv.org/reference/libraries/referencing.html#manage-nugets)

| Package           | Current version                                                                                                                                            | Description                                                                                                            |
|-------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------|
| VL.AlchemX        | [![VL.AlchemX](https://img.shields.io/nuget/vpre/VL.AlchemX?logo=nuget&style=flat-square)](https://www.nuget.org/packages/VL.AlchemX/)                     | A library dedicated to value synthesis. It includes functionalities for value interpolation, blending and compositing  |
| VL.LayerX         | [![VL.LayerX](https://img.shields.io/nuget/vpre/VL.LayerX?logo=nuget&style=flat-square)](https://www.nuget.org/packages/VL.LayerX/)                        | A library to handle values by embedding them into Layers, allowing sampling and advanced multi-layer compositing       |
| VL.Touchy         | [![VL.Touchy](https://img.shields.io/nuget/vpre/VL.Touchy?logo=nuget&style=flat-square)](https://www.nuget.org/packages/VL.Touchy)                         | A multi-touch gesture based interactive engine                                                                         |
| VL.Kairos.Runtime | [![VL.Kairos.Runtime](https://img.shields.io/nuget/vpre/VL.Kairos.Runtime?logo=nuget&style=flat-square)](https://www.nuget.org/packages/VL.Kairos.Runtime) | Contains all the Kairos functionalities to run without all the UI editors provided by VL.Kairos                        |
| VL.Kairos         | [![VL.Kairos](https://img.shields.io/nuget/vpre/VL.Kairos?logo=nuget&style=flat-square)](https://www.nuget.org/packages/VL.Kairos)                         |                                                                                                                        |

## Features

* High level functionalities
    * KeyframeEditor tool
    * Compositor tool
* Tools are nestable inside each other
* Advanced layer system
* Advanced interpolation, blending and compositing techniques
* Direct support for many of standard types (Intereger32, Float32, Vector2, Vector3, Vector4, RGBA, String)
* Custom type easy registration
* Custom Interpolation/Blending/Compositing technique registration
* Data binding helpers for vvvv app control



## Contributing to the development

1. Clone the repository
2. Build the solution located in the `src` folder in `Release` mode. 
3. You can then start contributing to the lib.
