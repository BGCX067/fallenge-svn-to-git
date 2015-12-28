using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using FallenGE.Graphics;
using FallenGE.Win32;

namespace FallenGE.Input
{
    /// <summary>
    /// Represent a mouse to gather input from the hardware mouse.
    /// </summary>
    public class Mouse
    {
        #region Properites
        /// <summary>
        /// Get the mouse x position.
        /// </summary>
        public int MouseX
        {
            get
            {
                Core.POINT pos;
                Core.GetCursorPos(out pos);
                Core.ScreenToClient(Core.GetActiveWindow(), ref pos);
                return (int)pos.x;
            }
        }

        /// <summary>
        /// Get the mouse y position.
        /// </summary>
        public int MouseY
        {
            get
            {
                Core.POINT pos;
                Core.GetCursorPos(out pos);
                Core.ScreenToClient(Core.GetActiveWindow(), ref pos);
                return (int)pos.y;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get the mouse X position local to a context.
        /// </summary>
        /// <param name="context">The local context.</param>
        /// <returns>The relative position.</returns>
        public int LocalMouseX(Context context)
        {
            Core.POINT pos;
            Core.GetCursorPos(out pos);
            Core.ScreenToClient(context.Handle, ref pos);
            return (int)pos.x;
        }

        /// <summary>
        /// Get the mouse Y position local to a context.
        /// </summary>
        /// <param name="context">The local context.</param>
        /// <returns>The relative position.</returns>
        public int LocalMouseY(Context context)
        {
            Core.POINT pos;
            Core.GetCursorPos(out pos);
            Core.ScreenToClient(context.Handle, ref pos);
            return (int)pos.y;
        }
        #endregion
    }
}
