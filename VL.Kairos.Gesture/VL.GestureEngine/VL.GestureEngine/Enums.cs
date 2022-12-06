using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestureEngine.Utils
{
    public enum GestureState
    {
        Start, Update, Finish, Abort
    }
    public enum GestureEvaluation
    {
        On_Notify, On_Render, On_Mainloop, On_CustomEvent
    }
}

