# VL.AlchemX

[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/VL.AlchemX?logo=nuget&style=flat-square)](https://www.nuget.org/packages/VL.AlchemX/) [![Matrix](https://img.shields.io/matrix/VL.Kairos:matrix.org?label=chat%20on%20element&logo=element&style=flat-square)](https://app.element.io/#/room/#VL.Kairos:matrix.org) [![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg?style=flat-square)](https://opensource.org/licenses/MIT) [![vvvv](https://img.shields.io/static/v1?label=MADE%20WITH&message=VVVV&color=191919&style=flat-square)](https://visualprogramming.net/)

AlchemX is a library dedicated to value synthesis. It includes functionalities for value interpolation, blending and compositing.

## Installation

In Gamma's quad-menu, click _Manage Nugets_ and then _Command Line_. This will open a command prompt in which you'll type

```
nuget install VL.AlchemX -pre
```

Wait for the end of the installation process and close the command line window.

## Usage

Once the library is installed, press <kbd>F1</kbd> to open the Help Browser and searchf or AlchemX. The different operations are explained with simple examples.

## Available synthesis operations

In a nutshell :

- Interpolation : produce a new value that transitions from `A` to `B` using an input `Scalar`
- Blending : produce a new value that is the result of a blending algorithm betwen a `Background` and a `Foreground` (think image blending modes : Add, Subtract, Screen, etc)
- Compositing : produce a new value that transitions from `A` to `B` using a blending model. See it as Interpolation + Blending.