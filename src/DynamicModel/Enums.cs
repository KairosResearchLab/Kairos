using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kairos.Core
{
    public enum FallbackOption
    {
        Default_Value, Keep_Last_Value, Keep_Alive_Last_Source
    }

    public enum KairosSourceMethod
    {
        LiveData, Sample
    }

    public enum KairosType
    {
        Boolean, Integer, Float, Color, String, Vector2, Vector3, Vector4, Matrix
    }

    public enum BlendingMode
    {
        Normal, Multiply, Add, Subtract, Divide, Difference, Darken, Lighten, Screen, Overlay
    }

    public enum ValueInterpolationFunction
    {
        Step, Linear, Tween, Oscillator, Bezier
    }

    public enum CountInterpolationFunction
    {
        Step, Linear, Tween, Oscillator, Bezier, Branching
    }

    public enum NeighbourSelection
    {
        Previous, Next
    }
    public enum ActivationStatus
    {
        Inactive, Preparation, Sampling, WaitingForDispose
    }
    public enum CanvasInputPinSorting
    {
        ByClipPosition, ByClipName, ByPinID
    }

}

namespace Kairos.Generators
{
    public enum ClockMapperKind
    {
        Wrap, Mirror, Clamp, Step
    }

}

namespace Kairos.Utils
{
    public enum MapType
    {
        Float, Wrap, Clamp, Mirror
    }

    public enum MixerType
    {
        Add, Subtract, Multiply, Divide, Min, Max
    }
}

