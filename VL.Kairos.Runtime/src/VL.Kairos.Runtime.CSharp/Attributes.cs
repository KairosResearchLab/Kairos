using System;
using System.Collections.Generic;
using System.Text;

namespace Kairos
{
    /// <summary>
    /// ExposePadAttribute is used to filter pads that are visible in a KeyframeEditor.
    /// This is for Opt-In.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ExposeAttribute : Attribute
    {
    }

    /// <summary>
    /// SuppressAttribute is used to filter pads that are visible in a KeyframeEditor.
    /// This is for Opt-Out.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SuppressAttribute : Attribute
    {
    }
}
