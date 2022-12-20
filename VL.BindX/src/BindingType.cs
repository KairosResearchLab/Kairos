namespace VL.BindX
{
    public enum BindingType
    {
        None = 0,
        Send = 1,
        Receive = 2,
        SendAndReceive = Send | Receive,
    }
}