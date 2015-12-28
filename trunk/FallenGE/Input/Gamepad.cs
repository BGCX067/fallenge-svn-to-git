using System;
using System.Collections.Generic;
using System.Text;

using FallenGE.Win32;

using SlimDX.XInput;

namespace FallenGE.Input
{
    /// <summary>
    /// An interface for a gamepad.
    /// </summary>
    public class Gamepad
    {
        #region Members
        private Controller controller;
        private State state;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new gamepad to interface with the given player.
        /// </summary>
        /// <param name="index">Index of the player.</param>
        public Gamepad(int index)
        {
            switch (index)
            {
                case 0:
                    controller = new Controller(UserIndex.One); break;
                case 1:
                    controller = new Controller(UserIndex.Two); break;
                case 2:
                    controller = new Controller(UserIndex.Three); break;
                case 3:
                    controller = new Controller(UserIndex.Four); break;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Update the gamepad state.
        /// </summary>
        public void Capture()
        {
            if (controller.IsConnected)
                state = controller.GetState();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the state of the buttons as a boolean array.
        /// </summary>
        public bool[] Button
        {
            get
            {
                bool[] buttonState = new bool[14]; 
                GamepadButtonFlags buttons = state.Gamepad.Buttons;

                buttonState[0] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.A)) != 0);
                buttonState[1] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.B)) != 0);
                buttonState[2] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.Y)) != 0);
                buttonState[3] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.X)) != 0);
                buttonState[4] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.LeftShoulder)) != 0);
                buttonState[5] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.RightShoulder)) != 0);
                buttonState[6] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.DPadDown)) != 0);
                buttonState[7] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.DPadUp)) != 0);
                buttonState[8] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.DPadLeft)) != 0);
                buttonState[9] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.DPadRight)) != 0);
                buttonState[10] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.Start)) != 0);
                buttonState[11] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.Back)) != 0);
                buttonState[12] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.RightThumb)) != 0);
                buttonState[13] = ((Convert.ToInt32(buttons) & Convert.ToInt32(GamepadButtonFlags.LeftThumb)) != 0);

                return buttonState;
            }
        }

        /// <summary>
        /// Get the state of button A.
        /// </summary>
        public bool Button1
        {
            get { return Button[0]; }
        }

        /// <summary>
        /// Get the state of button B.
        /// </summary>
        public bool Button2
        {
            get { return Button[1]; }
        }

        /// <summary>
        /// Get the state of button Y.
        /// </summary>
        public bool Button3
        {
            get { return Button[2]; }
        }

        /// <summary>
        /// Get the state of button X.
        /// </summary>
        public bool Button4
        {
            get { return Button[3]; }
        }

        /// <summary>
        /// Get the state of left shoulder button.
        /// </summary>
        public bool Button5
        {
            get { return Button[4]; }
        }

        /// <summary>
        /// Get the state of right shoulder button.
        /// </summary>
        public bool Button6
        {
            get { return Button[5]; }
        }

        /// <summary>
        /// Get the state of the right thumb stick.
        /// </summary>
        public bool Button7
        {
            get { return Button[12]; }
        }

        /// <summary>
        /// Get the state of the left thumb stick.
        /// </summary>
        public bool Button8
        {
            get { return Button[13]; }
        }

        /// <summary>
        /// Get the state of the start button.
        /// </summary>
        public bool Start
        {
            get { return Button[10]; }
        }

        /// <summary>
        /// Get the state of the back button.
        /// </summary>
        public bool Back
        {
            get { return Button[11]; }
        }

        /// <summary>
        /// Get the state of D-Pad Up.
        /// </summary>
        public bool Up
        {
            get { return Button[7]; }
        }

        /// <summary>
        /// Get the state of D-Pad Down.
        /// </summary>
        public bool Down
        {
            get { return Button[6]; }
        }

        /// <summary>
        /// Get the state of D-Pad Left.
        /// </summary>
        public bool Left
        {
            get { return Button[8]; }
        }

        /// <summary>
        /// Get the state of D-Pad Right.
        /// </summary>
        public bool Right
        {
            get { return Button[9]; }
        }

        /// <summary>
        /// Get the value of the left thumb x-axis.
        /// </summary>
        public float LeftX
        {
            get
            {
                if ((state.Gamepad.LeftThumbX < SlimDX.XInput.Gamepad.GamepadLeftThumbDeadZone && state.Gamepad.LeftThumbX > -SlimDX.XInput.Gamepad.GamepadLeftThumbDeadZone) &&
                    (state.Gamepad.LeftThumbY < SlimDX.XInput.Gamepad.GamepadLeftThumbDeadZone && state.Gamepad.LeftThumbY > -SlimDX.XInput.Gamepad.GamepadLeftThumbDeadZone))
                    return 0.0f;

                return state.Gamepad.LeftThumbX / 32768.0f;
            }
        }

        /// <summary>
        /// Get the value of the left thumb y-axis.
        /// </summary>
        public float LeftY
        {
            get
            {
                if ((state.Gamepad.LeftThumbX < SlimDX.XInput.Gamepad.GamepadLeftThumbDeadZone && state.Gamepad.LeftThumbX > -SlimDX.XInput.Gamepad.GamepadLeftThumbDeadZone) &&
                    (state.Gamepad.LeftThumbY < SlimDX.XInput.Gamepad.GamepadLeftThumbDeadZone && state.Gamepad.LeftThumbY > -SlimDX.XInput.Gamepad.GamepadLeftThumbDeadZone))
                    return 0.0f;

                return state.Gamepad.LeftThumbY / 32768.0f;
            }
        }

        /// <summary>
        /// Get the value of the right thumb x-axis.
        /// </summary>
        public float RightX
        {
            get
            {
                if ((state.Gamepad.RightThumbX < SlimDX.XInput.Gamepad.GamepadRightThumbDeadZone && state.Gamepad.RightThumbX > -SlimDX.XInput.Gamepad.GamepadRightThumbDeadZone) &&
                    (state.Gamepad.RightThumbY < SlimDX.XInput.Gamepad.GamepadRightThumbDeadZone && state.Gamepad.RightThumbY > -SlimDX.XInput.Gamepad.GamepadRightThumbDeadZone))
                    return 0.0f;

                return state.Gamepad.RightThumbX / 32768.0f;
            }
        }

        /// <summary>
        /// Get the value of the left thumb x-axis.
        /// </summary>
        public float RightY
        {
            get
            {
                if ((state.Gamepad.RightThumbX < SlimDX.XInput.Gamepad.GamepadRightThumbDeadZone && state.Gamepad.RightThumbX > -SlimDX.XInput.Gamepad.GamepadRightThumbDeadZone) &&
                    (state.Gamepad.RightThumbY < SlimDX.XInput.Gamepad.GamepadRightThumbDeadZone && state.Gamepad.RightThumbY > -SlimDX.XInput.Gamepad.GamepadRightThumbDeadZone))
                    return 0.0f;

                return state.Gamepad.RightThumbY / 32768.0f;
            }
        }

        /// <summary>
        /// Get the value of the left trigger.
        /// </summary>
        public int LeftTrigger
        {
            get
            {
                return state.Gamepad.LeftTrigger;
            }
        }

        /// <summary>
        /// Get the value of the right trigger.
        /// </summary>
        public int RightTrigger
        {
            get
            {
                return state.Gamepad.RightTrigger;
            }
        }

        /// <summary>
        /// Get the state of the contoller connection.
        /// </summary>
        public bool PluggedIn
        {
            get
            {
                return controller.IsConnected;
            }
        }
        #endregion
    }

    /// <summary>
    /// Allows you to access all four possible gamepads.
    /// </summary>
    public class GamepadManager
    {
        #region Members
        private Gamepad[] pads;
        #endregion

        #region Constructors
        /// <summary>
        /// Create the gamepad manager and init the four controllers.
        /// </summary>
        public GamepadManager()
        {
            pads = new Gamepad[4];

            for (int i = 0; i < 4; i++)
            {
                pads[i] = new Gamepad(i);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the gamepads.
        /// </summary>
        public Gamepad[] Pad
        {
            get
            {
                return pads;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Update gamepad input.
        /// </summary>
        public void Capture()
        {
            foreach (Gamepad gamepad in pads)
                gamepad.Capture();
        }
        #endregion
    }
}
