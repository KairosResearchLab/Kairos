# VL.Kairos

[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/VL.Kairos?logo=nuget&style=flat-square)](https://www.nuget.org/packages/VL.Kairos/) [![Matrix](https://img.shields.io/matrix/VL.Kairos:matrix.org?label=chat%20on%20element&logo=element&style=flat-square)](https://app.element.io/#/room/#VL.Kairos:matrix.org) [![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg?style=flat-square)](https://opensource.org/licenses/MIT) [![vvvv](https://img.shields.io/static/v1?label=MADE%20WITH&message=VVVV&color=191919&style=flat-square)](https://visualprogramming.net/)

![VL.Kairos banner](/img/banner.png)

### A complete framework for data control and composition in [vvvv](http://visualprogramming.net)

## Features

* High level functionalities
    * Timeline tool
    * Compositor tool
* Tools are nestable inside each other
* Advanced layering system
* Advanced interpolation, blending and compositing techniques
* Direct support for most of standard types (Boolean, Intereger32, Float32, Float64, Vector2, Vector3, Vector4, Matrix, RGBA, String, Skia layer, Stride Entity)
* Support for collections (for any implemented type)
* Custom type registration
* Custom Interpolation/Blending/Compositing technique registration
* Data binding helpers for vvvv app control


![VL.Kairos tools](/img/tools.png)

## Installing

To use the latest stable version in vvvv gamma (2021.3.3):
1. Go to Gamma's Quad menu > Manage Nugets > Commandline and type:

	```
	nuget install VL.Kairos
	```
2. Press Enter and wait the ending of the installation process

## Contributing to the development

1. Clone the repository
2. Build the solution located in the `src` folder in `Release` mode. 
3. You can then start contributing to the lib.