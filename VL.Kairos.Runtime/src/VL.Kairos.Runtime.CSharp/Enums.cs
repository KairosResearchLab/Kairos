using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kairos.Utils
{
    public enum MappingType
    {
        Float, Clamp, Mirror, Wrap
    }
}

namespace Kairos.Runtime
{
    public enum FallbackOption
    {
        Background, Latest
    }

    public enum TrackItemType
    {
        ConstantValue, LiveValue, Layer
    }

}

