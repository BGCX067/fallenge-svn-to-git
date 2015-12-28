using System;
using System.Collections.Generic;
using System.Text;

namespace FallenGE.Graphics
{
    /// <summary>
    /// Represents a context that is used to define parameters used by a renderer.
    /// </summary>
    [Serializable]
    public class Context
    {
        #region Members
        private IntPtr deviceContext, renderingContext, handle;
        private int[] size;
        private int[] drawColor, clearColor, maskColor;
        private float[] offset;
        private float[] origin;
        private float[] scale;
        private int[] viewport;
        private double rotation;
        private BlendMode blendMode;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a blank context with the size given by width and height.
        /// </summary>
        /// <param name="width">Width of the context.</param>
        /// <param name="height">Height of the context.</param>
        public Context(int width, int height)
        {
            deviceContext = renderingContext = handle = IntPtr.Zero;

            size = new int[2];
            size[0] = width;
            size[1] = height;

            drawColor = new int[4];
            clearColor = new int[4];
            maskColor = new int[3];
            offset = new float[2];
            origin = new float[2];
            scale = new float[2];
            viewport = new int[4];
        }

        /// <summary>
        /// Create a new context using the deviceContext, renderContext and handle given.
        /// It will also set the size to width and height given.
        /// </summary>
        /// <param name="deviceContext">The device context to use.</param>
        /// <param name="renderingContext">The rendering context to use.</param>
        /// <param name="handle">The handle to use.</param>
        /// <param name="width">Width of the context.</param>
        /// <param name="height">Height of the context.</param>
        public Context(IntPtr deviceContext, IntPtr renderingContext, IntPtr handle, int width, int height)
        {
            this.deviceContext = deviceContext;
            this.renderingContext = renderingContext;
            this.handle = handle;

            size = new int[2];
            size[0] = width;
            size[1] = height;

            viewport = new int[4];
            viewport[0] = 0;
            viewport[1] = 0;
            viewport[2] = width;
            viewport[3] = height;

            drawColor = new int[4];
            clearColor = new int[4];
            maskColor = new int[3];
            offset = new float[2];
            origin = new float[2];
            scale = new float[2];
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get or Set the device context.
        /// </summary>
        public IntPtr DeviceContext
        {
            get
            {
                return deviceContext;
            }
            set
            {
                deviceContext = value;
            }
        }

        /// <summary>
        /// Get or Set the rending context.
        /// </summary>
        public IntPtr RenderingContext
        {
            get
            {
                return renderingContext;
            }
            set
            {
                renderingContext = value;
            }
        }

        /// <summary>
        /// Get or Set the handle.
        /// </summary>
        public IntPtr Handle
        {
            get
            {
                return handle;
            }
            set
            {
                handle = value;
            }
        }

        /// <summary>
        /// Get the current color used to tint vertices.
        /// </summary>
        public int[] DrawColor
        {
            get
            {
                return drawColor;
            }
        }

        /// <summary>
        /// Get or Set the red value of the draw color.
        /// </summary>
        public int DrawRedValue
        {
            get
            {
                return drawColor[0];
            }
            set
            {
                drawColor[0] = value;
            }
        }

        /// <summary>
        /// Get or Set the green value of the draw color.
        /// </summary>
        public int DrawGreenValue
        {
            get
            {
                return drawColor[1];
            }
            set
            {
                drawColor[1] = value;
            }
        }

        /// <summary>
        /// Get or Set the blue value of the draw color.
        /// </summary>
        public int DrawBlueValue
        {
            get
            {
                return drawColor[2];
            }
            set
            {
                drawColor[2] = value;
            }
        }

        /// <summary>
        /// Get or Set the alpha value of the draw color.
        /// </summary>
        public float DrawAlphaValue
        {
            get
            {
                return 255.0f / (float)drawColor[3];
            }
            set
            {
                drawColor[3] = (int)(value * 255.0f);
            }
        }

        /// <summary>
        /// Get the current color used to clear the screen.
        /// </summary>
        public int[] ClearColor
        {
            get
            {
                return clearColor;
            }
        }

        /// <summary>
        /// Get or Set the red value of the clear color.
        /// </summary>
        public int ClearRedValue
        {
            get
            {
                return clearColor[0];
            }
            set
            {
                clearColor[0] = value;
            }
        }

        /// <summary>
        /// Get or Set the green value of the clear color.
        /// </summary>
        public int ClearGreenValue
        {
            get
            {
                return clearColor[1];
            }
            set
            {
                clearColor[1] = value;
            }
        }

        /// <summary>
        /// Get or Set the blue value of the clear color.
        /// </summary>
        public int ClearBlueValue
        {
            get
            {
                return clearColor[2];
            }
            set
            {
                clearColor[2] = value;
            }
        }

        /// <summary>
        /// Get the color to mask when loading an image.
        /// </summary>
        public int[] MaskColor
        {
            get
            {
                return maskColor;
            }
        }

        /// <summary>
        /// Get or Set the red value of the mask color.
        /// </summary>
        public int MaskRedValue
        {
            get
            {
                return maskColor[0];
            }
            set
            {
                maskColor[0] = value;
            }
        }

        /// <summary>
        /// Get or Set the green value of the mask color.
        /// </summary>
        public int MaskGreenValue
        {
            get
            {
                return maskColor[1];
            }
            set
            {
                maskColor[1] = value;
            }
        }

        /// <summary>
        /// Get or Set the blue value of the mask color.
        /// </summary>
        public int MaskBlueValue
        {
            get
            {
                return maskColor[2];
            }
            set
            {
                maskColor[2] = value;
            }
        }

        /// <summary>
        /// Get the internal origin of drawing operations.
        /// </summary>
        public float[] Offset
        {
            get
            {
                return offset;
            }
        }

        /// <summary>
        /// Get or Set the x offset.
        /// </summary>
        public float XOffset
        {
            get
            {
                return offset[0];
            }
            set
            {
                offset[0] = value;
            }
        }

        /// <summary>
        /// Get or Set the y offset.
        /// </summary>
        public float YOffset
        {
            get
            {
                return offset[1];
            }
            set
            {
                offset[1] = value;
            }
        }

        /// <summary>
        /// Get the origin of all drawing operations.
        /// </summary>
        public float[] Origin
        {
            get
            {
                return origin;
            }
        }

        /// <summary>
        /// Get or Set the x origin.
        /// </summary>
        public float XOrigin
        {
            get
            {
                return origin[0];
            }
            set
            {
                origin[0] = value;
            }
        }

        /// <summary>
        /// Get or Set the y origin.
        /// </summary>
        public float YOrigin
        {
            get
            {
                return origin[1];
            }
            set
            {
                origin[1] = value;
            }
        }

        /// <summary>
        /// Get the scale of all drawing operations.
        /// </summary>
        public float[] Scale
        {
            get
            {
                return scale;
            }
        }

        /// <summary>
        /// Get or Set the x scale.
        /// </summary>
        public float XScale
        {
            get
            {
                return scale[0];
            }
            set
            {
                scale[0] = value;
            }
        }

        /// <summary>
        /// Get or Set the y scale.
        /// </summary>
        public float YScale
        {
            get
            {
                return scale[1];
            }
            set
            {
                scale[1] = value;
            }
        }

        /// <summary>
        /// Get or Set the rotation of all drawing operations.
        /// </summary>
        public double Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
            }
        }

        /// <summary>
        /// Get or Set the blending operation used when rendering.
        /// </summary>
        public BlendMode BlendMode
        {
            get
            {
                return blendMode;
            }
            set
            {
                blendMode = value;
            }
        }

        /// <summary>
        /// Get or Set the screen width.
        /// </summary>
        public int Width
        {
            get
            {
                return size[0];
            }
            set
            {
                size[0] = value;
            }
        }

        /// <summary>
        /// Get or Set the screen height.
        /// </summary>
        public int Height
        {
            get
            {
                return size[1];
            }
            set
            {
                size[1] = value;
            }
        }

        public int ViewportX
        {
            get
            {
                return viewport[0];
            }
            set
            {
                viewport[0] = value;
            }
        }

        public int ViewportY
        {
            get
            {
                return viewport[1];
            }
            set
            {
                viewport[1] = value;
            }
        }

        public int ViewportWidth
        {
            get
            {
                return viewport[2];
            }
            set
            {
                viewport[2] = value;
            }
        }

        public int ViewportHeight
        {
            get
            {
                return viewport[3];
            }
            set
            {
                viewport[3] = value;
            }
        }
        #endregion
    }
}
