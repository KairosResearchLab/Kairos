using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touchy.Utils
{
    public enum GestureState
    {
        Start, Update, Finish, Abort
    }

    public enum MouseEventKind
    {
        Down, Up, Pressed, Move, DoubleClick, IsLost
    }

    public enum KeyboardEventKind
    {
        Down, Up, Pressed
    }

}
