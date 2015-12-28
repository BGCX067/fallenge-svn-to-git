using System;
using System.Collections.Generic;
using System.Text;

using FallenGE.Win32;

namespace FallenGE.Utility
{
    /// <summary>
    /// Represents a timer.
    /// </summary>
    [Serializable]
    public class Timer
    {
        #region Members
        private float start, end, delta;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new timer.
        /// </summary>
        public Timer()
        {
            delta = start = end = 0.0f;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Start the timer ticking.
        /// </summary>
        public void Start()
        {
            start = Core.timeGetTime();
        }

        /// <summary>
        /// Stop the timer and calculate delta.
        /// </summary>
        public void Stop()
        {
            end = Core.timeGetTime();
            delta = (float)(end - start) / 1000.0f;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the time in milliseconds.
        /// </summary>
        public float Time
        {
            get
            {
                return Core.timeGetTime() - start;
            }
        }

        /// <summary>
        /// Get the delta time.
        /// </summary>
        public float Delta
        {
            get
            {
                return System.Math.Abs(delta);
            }
        }
        #endregion
    }
}
