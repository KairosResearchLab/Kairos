using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicModel
{
    public struct ValueHolder : IEquatable<ValueHolder>
    {
        public readonly object Value;

        public ValueHolder(object value)
        {
            Value = value;
        }

        public bool Equals(ValueHolder other)
        {
            var thisValue = Value;
            var thatValue = other.Value;
            if (ReferenceEquals(thisValue, thatValue))
                return true;
            if (ReferenceEquals(thisValue, null))
                return false;
            return thisValue.Equals(thatValue);
        }

        public override bool Equals(object obj)
        {
            if (obj is ValueHolder)
                return Equals((ValueHolder)obj);
            return false;
        }

        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 0;
        }

        public static bool operator ==(ValueHolder a, ValueHolder b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ValueHolder a, ValueHolder b)
        {
            return !a.Equals(b);
        }
    }
}
