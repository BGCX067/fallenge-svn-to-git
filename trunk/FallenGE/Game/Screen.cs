using System;
using System.Collections.Generic;
using System.Text;

using FallenGE.Graphics;
using FallenGE.Utility;
using FallenGE.Win32;

namespace FallenGE.Game
{
    /// <summary>
    /// Represents a screen.
    /// </summary>
    public class Screen
    {
        #region Members
        protected string nextScreen;
        protected Engine engine;
        #endregion

        #region Constructors

        /// <summary>
        /// Create a new screen.
        /// </summary>
        public Screen()
        {
            nextScreen = "";
        }

        /// <summary>
        /// Create a new screen.
        /// </summary>
        public Screen(Engine engine)
        {
            nextScreen = "";

            this.engine = engine;
        }
        #endregion

        #region Properites
        /// <summary>
        /// Get the name of the next screen.
        /// </summary>
        public string NextScreen
        {
            get
            {
                return nextScreen;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Called when the screen if loaded.
        /// </summary>
        public virtual void Load()
        {
        }

        /// <summary>
        /// Called when the screen is unloaded.
        /// </summary>
        public virtual void Unload()
        {
        }

        /// <summary>
        /// Called when the screen is rendered.
        /// </summary>
        public virtual void Render()
        {
        }

        /// <summary>
        /// Called when the screen needs updating.
        /// </summary>
        /// <param name="delta">The delta time, used for timing purposes.</param>
        public virtual void Update(float delta)
        {
        }

        /// <summary>
        /// Called when the screen is being hidden.
        /// </summary>
        public virtual void TransOut()
        {
        }

        /// <summary>
        /// Called when the screen is being shown.
        /// </summary>
        public virtual void TransIn()
        {
        }

        public void FadeFromBlack(float time)
        {
            float ticker;
            Timer timer = new Timer();

            ticker = 0.0f;
            while ((ticker < time))
            {
                if (Core.Update() == false)
                {
                    Core.PostQuitMessage(0);
                    break;
                }

                ticker += 1.0f * timer.Delta;
                timer.Start();
                float black = timer.Delta;

                engine.RenderManager.SetDrawColor((int)((ticker / time) * 255), (int)((ticker / time) * 255), (int)((ticker / time) * 255));
                this.Render();
                this.Update(timer.Delta);

                timer.Stop();
            }
        }

        public void FadeToBlack(float time)
        {
            float ticker;
            Timer timer = new Timer();

            ticker = 0.0f;
            while ((ticker < time))
            {
                ticker += 1.0f * timer.Delta;
                timer.Start();
                float black = timer.Delta;

                engine.RenderManager.SetDrawColor(255 - (int)((ticker / time) * 255), 255 - (int)((ticker / time) * 255), 255 - (int)((ticker / time) * 255));
                this.Render();
                this.Update(timer.Delta);

                timer.Stop();
            }
        }
        #endregion
    }
}
