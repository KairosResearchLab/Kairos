# Kairos

A complete framework for data control and composition in [vvvv](http://visualprogramming.net)

[![Matrix](https://img.shields.io/matrix/VL.Kairos:matrix.org?label=chat%20on%20element&logo=element&style=flat-square)](https://app.element.io/#/room/#VL.Kairos:matrix.org) [![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg?style=flat-square)](https://opensource.org/licenses/MIT) [![vvvv](https://img.shields.io/static/v1?label=MADE%20WITH&message=VVVV&color=191919&style=flat-square)](https://visualprogramming.net/)

![VL.Kairos banner](/img/banner.png)

## Requirements

As of today, Kairos only works with vvvv gamma 2022.5 previews. Get the latest [here](http://visualprogramming.net)

## Installing

- Go to Gamma's Quad menu > Manage Nugets > Commandline and type

```
nuget install VL.Kairos -pre
```
- Press Enter and wait the ending of the installation process
- For more information on nugets and how to use them in vvvv, click [here](https://thegraybook.vvvv.org/reference/libraries/referencing.html#manage-nugets)

| Package           | Current version                                                                                                                                              |
|-------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
| VL.AlchemX        | [![VL.AlchemX](https://img.shields.io/nuget/vpre/VL.AlchemX?logo=nuget&style=flat-square)](https://www.nuget.org/packages/VL.AlchemX/)                     |
| VL.LayerX         | [![VL.LayerX](https://img.shields.io/nuget/vpre/VL.LayerX?logo=nuget&style=flat-square)](https://www.nuget.org/packages/VL.LayerX/)                        |
| VL.BindX          | To be released                                                                                                                                               |
| VL.Touchy         | [![VL.Touchy](https://img.shields.io/nuget/vpre/VL.Touchy?logo=nuget&style=flat-square)](https://www.nuget.org/packages/VL.Touchy)                         |
| VL.Kairos.Runtime | [![VL.Kairos.Runtime](https://img.shields.io/nuget/vpre/VL.Kairos.Runtime?logo=nuget&style=flat-square)](https://www.nuget.org/packages/VL.Kairos.Runtime) |
| VL.Kairos         | [![VL.Kairos](https://img.shields.io/nuget/vpre/VL.Kairos?logo=nuget&style=flat-square)](https://www.nuget.org/packages/VL.Kairos)                         |

## Features

* High level functionalities
    * Timeline tool
    * Compositor tool
* Tools are nestable inside each other
* Advanced layer system
* Advanced interpolation, blending and compositing techniques
* Direct support for most of standard types (Boolean, Intereger32, Float32, Float64, Vector2, Vector3, Vector4, Matrix, RGBA, String, Skia layer, Stride Entity)
* Support for collections (for any implemented type)
* Custom type easy registration
* Custom Interpolation/Blending/Compositing technique registration
* Data binding helpers for vvvv app control



## Contributing to the development

1. Clone the repository
2. Build the solution located in the `src` folder in `Release` mode. 
3. You can then start contributing to the lib.
