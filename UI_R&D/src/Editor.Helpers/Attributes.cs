namespace Editor.Helpers
{
    public class WidgetTypeAttribute : Attribute
    {
        public WidgetTypeAttribute(string value)
        {
            Value = value;
        }
        public string Value { get; }
    }

    public class LabelAttribute : Attribute
    {
        public LabelAttribute(string value)
        {
            Value = value;
        }
        public string Value { get; }
    }
    public class MinAttribute : Attribute
    {
        public MinAttribute(object value)
        {
            Value = value;
        }
        public object Value { get; }
    }
    public class MaxAttribute : Attribute
    {
        public MaxAttribute(object value)
        {
            Value = value;
        }
        public object Value { get; }
    }
}