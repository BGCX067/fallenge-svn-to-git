using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using FallenGE.Win32;

namespace FallenGE.Input
{
    /// <summary>
    /// Specifies a key state
    /// </summary>
    public enum KeyState : int
    {
        /// <summary>
        /// The key if current not pressed.
        /// </summary>
        UP,
        /// <summary>
        /// The key has been hit.
        /// </summary>
        HIT,
        /// <summary>
        /// The key is being held down.
        /// </summary>
        DOWN,
        /// <summary>
        /// The key has been pressed.
        /// </summary>
        PRESSED
    }
    
    /// <summary>
    /// Represent a keyboard to gather input from hardware keyboard.
    /// </summary>
    public class Keyboard
    {
        #region Members
        private Stack<string> keyStack;
        private KeyState[] keyState;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new keyboard manager.
        /// </summary>
        public Keyboard()
        {
            keyState = new KeyState[256];
            keyStack = new Stack<string>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Capture input from keyboard.
        /// </summary>
        public void Capture()
        {
            short[] ks = new short[256];
            for (int i = 0; i < 256; i++)
            {
                ks[i] = Core.GetAsyncKeyState(i);

                if ((ks[i] & 0x8000) != 0)
                {
                    if (this.keyState[i] == KeyState.HIT)
                    {
                        this.keyState[i] = KeyState.DOWN;
                    }
                    else if (keyState[i] == KeyState.UP)
                    {
                        this.keyState[i] = KeyState.HIT;
                    }
                }
                else
                {
                    if (this.keyState[i] == KeyState.DOWN)
                    {
                        this.keyState[i] = KeyState.PRESSED;
                    }
                    else
                    {
                        this.keyState[i] = KeyState.UP;
                    }
                }
            }

            foreach (Int32 i in Enum.GetValues(typeof(Keys)))
            {
                if ((Core.GetAsyncKeyState(i) == 1) || (Core.GetAsyncKeyState(i) == -32767))
                {
                    keyStack.Push(Enum.GetName(typeof(Keys), i));
                }
            }
        }

        /// <summary>
        /// Determines if a key has been hit.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>True if the key has been hit.</returns>
        public bool KeyHit(Keys key)
        {
            return (this.keyState[Convert.ToInt32(key)] == KeyState.HIT);
        }

        /// <summary>
        /// Determines if a key is not pressed.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>True if the key is not pressed.</returns>
        public bool KeyUp(Keys key)
        {
            return (this.keyState[Convert.ToInt32(key)] == KeyState.UP);
        }

        /// <summary>
        /// Determines if a key is pressed down.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>True if the key is pressed down.</returns>
        public bool KeyDown(Keys key)
        {
            return (this.keyState[Convert.ToInt32(key)] == KeyState.DOWN);
        }

        /// <summary>
        /// Determines if a key has been pressed (Held down and released).
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>True if the key has been pressed.</returns>
        public bool KeyPressed(Keys key)
        {
            return (this.keyState[Convert.ToInt32(key)] == KeyState.PRESSED);
        }

        public bool HasInput
        {
            get
            {
                return (Core.KeyStack.Length > 0);
            }
        }

        /// <summary>
        /// Gets the last key from the key buffer.
        /// </summary>
        /// <returns>The last key to be put into the buffer.</returns>
        public char GetKey()
        {
            if (Core.KeyStack.Length > 0)
                return Core.PopKey();

            return '0';
        }

        /// <summary>
        /// Clears the key buffer.
        /// </summary>
        public void FlushKeys()
        {
            Core.FlushKeys();
        }
        #endregion
    }
}
