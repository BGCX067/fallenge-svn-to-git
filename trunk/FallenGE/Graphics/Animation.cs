using System;
using System.Collections.Generic;
using System.Text;

using FallenGE.Utility;

namespace FallenGE.Graphics
{
    [Serializable]
    public class Animation
    {
        #region Members
        private Timer timer;
        private int tick, frameSkip;
        private int startFrame, endFrame, curFrame;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a blank animation with no frames.
        /// </summary>
        public Animation()
        {
            timer = new Timer();
            startFrame = endFrame = curFrame = tick = 0;
            frameSkip = 1;
        }

        /// <summary>
        /// Create a new animation.
        /// </summary>
        /// <param name="start">Integer starting point.</param>
        /// <param name="end">Integer ending point.</param>
        /// <param name="tickSpeed">How fast the animtion ticks in milliseconds.</param>
        public Animation(int start, int end, int tickSpeed)
        {
            timer = new Timer();
            startFrame = start;
            endFrame = end;
            curFrame = startFrame;
            tick = tickSpeed;
            timer.Start();
            frameSkip = 1;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sync the animation by updating with the timer.
        /// </summary>
        public void Update()
        {
            if (timer.Time >= tick)
            {
                timer.Stop();
                curFrame += frameSkip;
                if (curFrame > endFrame)
                    curFrame = startFrame;
                timer.Start();
            }
        }
        #endregion

        #region Properites
        /// <summary>
        /// Get the frame the animation is currently on.
        /// </summary>
        public int Frame
        {
            get { return curFrame; }
        }
        #endregion
    }
}
