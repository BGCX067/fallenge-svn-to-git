using System;
using System.Collections.Generic;
using System.Text;

using FallenGE.Audio;
using FallenGE.Graphics;
using FallenGE.Input;
using FallenGE.Physics;
using FallenGE.Utility;

namespace FallenGE
{
    /// <summary>
    /// Represents a FallenGE Engine.
    /// </summary>
    public class Engine
    {
        #region Members
        private Renderer renderer;
        private AudioPlayer audioPlayer;
        private Mouse mouse;
        private Keyboard keyboard;
        private GamepadManager gamepadManager;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new engine with the given managers.
        /// </summary>
        /// <param name="renderer">The render manager.</param>
        /// <param name="audioPlayer">The audio manager.</param>
        /// <param name="mouse">The mouse manager.</param>
        /// <param name="keyboard">The keyboard manager.</param>
        public Engine(Renderer renderer, AudioPlayer audioPlayer, Mouse mouse, Keyboard keyboard, GamepadManager gamepadManager)
        {
            this.renderer = renderer;
            this.audioPlayer = audioPlayer;
            this.mouse = mouse;
            this.keyboard = keyboard;
            this.gamepadManager = gamepadManager;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the render manager.
        /// </summary>
        public Renderer RenderManager
        {
            get
            {
                return renderer;
            }
        }

        /// <summary>
        /// Get the audio manager.
        /// </summary>
        public AudioPlayer AudioManager
        {
            get
            {
                return audioPlayer;
            }
        }

        /// <summary>
        /// Get the mouse manager.
        /// </summary>
        public Mouse MouseManager
        {
            get
            {
                return mouse;
            }
        }

        /// <summary>
        /// Get the keyboard manager.
        /// </summary>
        public Keyboard KeyboardManager
        {
            get
            {
                return keyboard;
            }
        }

        public GamepadManager GamepadManager
        {
            get
            {
                return gamepadManager;
            }
        }
        #endregion
    }
}
