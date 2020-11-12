using System;
using System.Collections.Generic;
using System.Text;

namespace Kairos
{
    /// <summary>
    /// ExposePadAttribute is used to filter pads that are visible in a Timeline.
    /// This is for Opt-In.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ExposePadAttribute : Attribute
    {
    }

    /// <summary>
    /// SuppressAttribute is used to filter pads that are visible in a Timeline.
    /// This is for Opt-Out.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SuppressPadAttribute : Attribute
    {
    }
}
