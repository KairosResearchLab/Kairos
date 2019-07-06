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

    public enum KairosType
    {
        Boolean, Integer, Float, Color, String, Vector2, Vector3, Vector4, Matrix
    }

    public enum BooleanWidget
    {
        Toggle, Press, Bang
    }

    public enum IntegerWidget
    {
        Integer, NumericUpDown
    }

    public enum FloatWidget
    {
        Value, Slider, Rotary
    }

    public enum ColorWidget
    {
        Color
    }

    public enum StringWidget
    {
        TextField
    }

    public enum Vector2Widget
    {
        Vector2D, Slider2D
    }

    public enum Vector3Widget
    {
        Vector3D
    }

    public enum Vector4Widget
    {
        Vector4D
    }

    public enum MatrixWidget
    {
        Matrix
    }

}
