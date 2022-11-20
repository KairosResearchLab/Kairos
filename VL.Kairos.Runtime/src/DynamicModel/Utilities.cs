using System;
using System.Collections.Generic;
using System.Text;

namespace Kairos.Core
{
    public static class Utilities
    {
        public static TOut CastAsNICE<TIn, TOut>(TIn input) => (TOut)(object)input;

        public static Type TypeOf<T>(T input) => typeof(T);
    }
}
