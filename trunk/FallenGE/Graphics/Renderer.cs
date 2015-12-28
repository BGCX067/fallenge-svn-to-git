using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.DevIl;
using Tao.Platform.Windows;

using FallenGE.File_System;
using FallenGE.Math;

namespace FallenGE.Graphics
{
    /// <summary>
    /// Specifies the blend operation used when rendering.
    /// </summary>
    public enum BlendMode
    {
        /// <summary>
        /// Allows for alpha blending.
        /// </summary>
        ALPHA,
        /// <summary>
        /// All pixels are drawn.
        /// </summary>
        SOLID,
        /// <summary>
        /// Adds image to destination (brightness).
        /// </summary>
        LIGHT,
        /// <summary>
        /// Removes image from destination (brightness).
        /// </summary>
        DARK,
        /// <summary>
        /// Disable blending.
        /// </summary>
        NONE
    }

    /// <summary>
    /// Represents a graphics mode.
    /// </summary>
    public class GraphicsMode
    {
        private int width, height, bitdepth, frequency;

        /// <summary>
        /// Setup a graphics mode.
        /// </summary>
        /// <param name="width">Width of the graphics.</param>
        /// <param name="height">Height of the graphics.</param>
        /// <param name="bitdepth">Bitdepth of the graphics.</param>
        /// <param name="frequency">Frequency of the graphics.</param>
        public GraphicsMode(int width, int height, int bitdepth, int frequency)
        {
            this.width = width;
            this.height = height;
            this.bitdepth = bitdepth;
            this.frequency = frequency;
        }

        /// <summary>
        /// Get the width.
        /// </summary>
        public int Width
        {
            get { return width; }
        }

        /// <summary>
        /// Get the height.
        /// </summary>
        public int Height
        {
            get { return height; }
        }

        /// <summary>
        /// Get the bitdepth.
        /// </summary>
        public int Bitdepth
        {
            get { return bitdepth; }
        }

        /// <summary>
        /// Get the frequency.
        /// </summary>
        public int Frequency
        {
            get { return frequency; }
        }
    }

    /// <summary>
    /// Represents a renderer.
    /// </summary>
    public class Renderer
    {
        #region Members
        private List<Context> contextList;
        private Context currentContext;
        private Image targetTexture;
        private int oldWidth, oldHeight;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new renderer using the given context.
        /// </summary>
        public Renderer()
        {
            
            Il.ilInit();
            Ilut.ilutInit();

            contextList = new List<Context>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get or Set the current context used by the renderer.
        /// </summary>
        public Context CurrentContext
        {
            get
            {
                return currentContext;
            }
            set
            {
                currentContext = value;
                Wgl.wglMakeCurrent(currentContext.DeviceContext, currentContext.RenderingContext);
                Setup2DProjection(currentContext.Width, currentContext.Height);
            }
        }

        /// <summary>
        /// Get the width of render target.
        /// </summary>
        public int Width
        {
            get
            {
                return currentContext.Width;
            }
        }

        /// <summary>
        /// Get the height of render target.
        /// </summary>
        public int Height
        {
            get
            {
                return currentContext.Height;
            }
        }

        /// <summary>
        /// Get or Set the red value of the draw color.
        /// </summary>
        public int DrawRedValue
        {
            get
            {
                return currentContext.DrawRedValue;
            }
            set
            {
                currentContext.DrawRedValue = value;
            }
        }

        /// <summary>
        /// Get or Set the green value of the draw color.
        /// </summary>
        public int DrawGreenValue
        {
            get
            {
                return currentContext.DrawGreenValue;
            }
            set
            {
                currentContext.DrawGreenValue = value;
            }
        }

        /// <summary>
        /// Get or Set the blue value of the draw color.
        /// </summary>
        public int DrawBlueValue
        {
            get
            {
                return currentContext.DrawBlueValue;
            }
            set
            {
                currentContext.DrawBlueValue = value;
            }
        }

        /// <summary>
        /// Get or Set the alpha value of the draw color.
        /// </summary>
        public float DrawAlphaValue
        {
            get
            {
                return currentContext.DrawAlphaValue;
            }
            set
            {
                currentContext.DrawAlphaValue = value;
            }
        }

        /// <summary>
        /// Get or Set the red value of the clear color.
        /// </summary>
        public int ClearRedValue
        {
            get
            {
                return currentContext.ClearRedValue;
            }
            set
            {
                currentContext.ClearRedValue = value;
            }
        }

        /// <summary>
        /// Get or Set the green value of the clear color.
        /// </summary>
        public int ClearGreenValue
        {
            get
            {
                return currentContext.ClearGreenValue;
            }
            set
            {
                currentContext.ClearGreenValue = value;
            }
        }

        /// <summary>
        /// Get or Set the blue value of the clear color.
        /// </summary>
        public int ClearBlueValue
        {
            get
            {
                return currentContext.ClearBlueValue;
            }
            set
            {
                currentContext.ClearBlueValue = value;
            }
        }

        /// <summary>
        /// Get or Set the red value of the mask color.
        /// </summary>
        public int MaskRedValue
        {
            get
            {
                return currentContext.MaskRedValue;
            }
            set
            {
                currentContext.MaskRedValue = value;
            }
        }

        /// <summary>
        /// Get or Set the green value of the mask color.
        /// </summary>
        public int MaskGreenValue
        {
            get
            {
                return currentContext.MaskGreenValue;
            }
            set
            {
                currentContext.MaskGreenValue = value;
            }
        }

        /// <summary>
        /// Get or Set the blue value of the mask color.
        /// </summary>
        public int MaskBlueValue
        {
            get
            {
                return currentContext.MaskBlueValue;
            }
            set
            {
                currentContext.MaskBlueValue = value;
            }
        }

        /// <summary>
        /// Get or Set the x offset.
        /// </summary>
        public float XOffset
        {
            get
            {
                return currentContext.XOffset;
            }
            set
            {
                currentContext.XOffset = value;
            }
        }

        /// <summary>
        /// Get or Set the y offset.
        /// </summary>
        public float YOffset
        {
            get
            {
                return currentContext.YOffset;
            }
            set
            {
                currentContext.YOffset = value;
            }
        }

        /// <summary>
        /// Get or Set the x origin.
        /// </summary>
        public float XOrigin
        {
            get
            {
                return currentContext.XOrigin;
            }
            set
            {
                currentContext.XOrigin = value;
            }
        }

        /// <summary>
        /// Get or Set the y origin.
        /// </summary>
        public float YOrigin
        {
            get
            {
                return currentContext.YOrigin;
            }
            set
            {
                currentContext.YOrigin = value;
            }
        }

        /// <summary>
        /// Get or Set the x scale.
        /// </summary>
        public float XScale
        {
            get
            {
                return currentContext.XScale;
            }
            set
            {
                currentContext.XScale = value;
            }
        }

        /// <summary>
        /// Get or Set the y scale.
        /// </summary>
        public float YScale
        {
            get
            {
                return currentContext.YScale;
            }
            set
            {
                currentContext.YScale = value;
            }
        }

        /// <summary>
        /// Get the viewport x.
        /// </summary>
        public int ViewportX
        {
            get
            {
                return currentContext.ViewportX;
            }
        }

        /// <summary>
        /// Get the viewport y.
        /// </summary>
        public int ViewportY
        {
            get
            {
                return currentContext.ViewportY;
            }
        }

        /// <summary>
        /// Get the viewport width.
        /// </summary>
        public int ViewportWidth
        {
            get
            {
                return currentContext.ViewportWidth;
            }
        }

        /// <summary>
        /// Get the viewport height.
        /// </summary>
        public int ViewportHeight
        {
            get
            {
                return currentContext.ViewportHeight;
            }
        }

        /// <summary>
        /// Get or Set the rotation of all drawing operations.
        /// </summary>
        public double Rotation
        {
            get
            {
                return currentContext.Rotation;
            }
            set
            {
                currentContext.Rotation = value;
            }
        }

        /// <summary>
        /// Get or Set the blending operation used when rendering.
        /// </summary>
        public BlendMode BlendMode
        {
            get
            {
                return currentContext.BlendMode;
            }
            set
            {
                SetBlend(value);
            }
        }

        /// <summary>
        /// Get the card vendor name.
        /// </summary>
        public string Vendor
        {
            get
            {
                return Gl.glGetString(Gl.GL_VENDOR);
            }
        }

        /// <summary>
        /// Get the render name.
        /// </summary>
        public string Render
        {
            get
            {
                return Gl.glGetString(Gl.GL_RENDER);
            }
        }

        /// <summary>
        /// Get the opengl version.
        /// </summary>
        public string Version
        {
            get
            {
                return Gl.glGetString(Gl.GL_VERSION);
            }
        }
        #endregion

        /// <summary>
        /// Get all the supported graphic modes.
        /// </summary>
        public static GraphicsMode[] SupportedGraphics
        {
            get
            {
                int i = 0;
                List<GraphicsMode> modes = new List<GraphicsMode>(); ;
                Gdi.DEVMODE devMode = new Gdi.DEVMODE();

                while (User.EnumDisplaySettings(null, i, out devMode))
                {
                    GraphicsMode m = new GraphicsMode(devMode.dmPelsWidth,
                                                        devMode.dmPelsHeight,
                                                        devMode.dmBitsPerPel,
                                                        devMode.dmDisplayFrequency);
                    modes.Add(m);
                    i++;
                }

                return modes.ToArray();
            }
        }

        #region Methods
        #region Misc Methods

        /// <summary>
        /// Checks to see if a graphics mode is supported.
        /// </summary>
        /// <param name="width">Test width.</param>
        /// <param name="height">Test height.</param>
        /// <param name="bitdepth">Test bitdepth.</param>
        /// <returns></returns>
        public static bool ModeSupported(int width, int height, int bitdepth)
        {
            GraphicsMode[] modes = SupportedGraphics;
            foreach (GraphicsMode mode in modes)
            {
                if (mode.Width == width &&
                    mode.Height == height &&
                    mode.Bitdepth == bitdepth)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Add a context using a windows.forms form.
        /// </summary>
        /// <param name="form">The form to create the context for.</param>
        /// <returns></returns>
        public Context AddContext(Form form)
        {
            return AddContext(form.Handle, form.ClientSize.Width, form.ClientSize.Height);
        }

        /// <summary>
        /// Add a context using the given win32 handle.
        /// </summary>
        /// <param name="handle">The win32 handle.</param>
        /// <param name="width">Width of the context.</param>
        /// <param name="height">Height of the context.</param>
        /// <returns></returns>
        public Context AddContext(IntPtr handle, int width, int height)
        {
            IntPtr deviceContext, renderingContext;
            Gdi.PIXELFORMATDESCRIPTOR pdf = new Gdi.PIXELFORMATDESCRIPTOR();
            pdf.nSize = (short)Marshal.SizeOf(pdf);
            pdf.nVersion = 1;
            pdf.dwFlags = Gdi.PFD_DRAW_TO_WINDOW |
                            Gdi.PFD_SUPPORT_OPENGL |
                            Gdi.PFD_DOUBLEBUFFER;
            pdf.iPixelType = (byte)Gdi.PFD_TYPE_RGBA;
            pdf.cColorBits = 32;
            pdf.cDepthBits = 16;

            deviceContext = User.GetDC(handle);
            if (deviceContext == IntPtr.Zero)
                return null;

            int pixelFormat = Gdi.ChoosePixelFormat(deviceContext, ref pdf);
            Gdi.SetPixelFormat(deviceContext, pixelFormat, ref pdf);

            renderingContext = Wgl.wglCreateContext(deviceContext);
            if (renderingContext == IntPtr.Zero)
                return null;

            Context context = new Context(deviceContext, renderingContext, handle, width, height);
            contextList.Add(context);
            CurrentContext = context;

            SetBlend(BlendMode.ALPHA);
            SetClearColor(100, 100, 200);
            SetDrawColor(255, 255, 255);
            SetDrawAlpha(1.0f);
            SetOffset(0.0f, 0.0f);
            SetScale(1.0f, 1.0f);

            return context;
        }

        /// <summary>
        /// Remove a context from the context list.
        /// </summary>
        /// <param name="context"></param>
        public void RemoveContext(Context context)
        {
            contextList.Remove(context);
        }

        /// <summary>
        /// Resize a context.
        /// </summary>
        /// <param name="context">The context to be resized.</param>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        public void ResizeContext(Context context, int width, int height)
        {
            currentContext.Width = width;
            currentContext.Height = height;
            Setup2DProjection(context.Width, context.Height);
            Gl.glViewport(0, 0, width, height);
        }

        /// <summary>
        /// Setup a 2D projection using the given width and height.
        /// </summary>
        /// <param name="width">Width of the projection.</param>
        /// <param name="height">Height of the projection.</param>
        public void Setup2DProjection(int width, int height)
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Gl.glOrtho(0, width, height, 0, 1, -1);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glShadeModel(Gl.GL_SMOOTH);
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            SetBlend(BlendMode.ALPHA);
        }
        #endregion

        #region Set Methods
        /// <summary>
        /// Set the internal origin of drawing operations.
        /// </summary>
        /// <param name="s">x-axis scalar.</param>
        /// <param name="t">y-axis scalar.</param>
        public void SetOffset(float s, float t)
        {
            currentContext.Offset[0] = s;
            currentContext.Offset[1] = t;
        }


        /// <summary>
        /// Set the origin of all drawing operations.
        /// </summary>
        /// <param name="s">x-axis scalar.</param>
        /// <param name="t">y-axis scalar.</param>
        public void SetOrigin(float s, float t)
        {
            currentContext.Origin[0] = s;
            currentContext.Origin[1] = t;
        }

        /// <summary>
        /// Set the scale of all drawing operations.
        /// </summary>
        /// <param name="s">x-axis scalar.</param>
        /// <param name="t">y-axis scalar.</param>
        public void SetScale(float s, float t)
        {
            currentContext.Scale[0] = s;
            currentContext.Scale[1] = t;
        }

        /// <summary>
        /// Set the angle of rotation for drawing operations.
        /// </summary>
        /// <param name="angle">The angle of rotation.</param>
        public void SetRotation(double angle)
        {
            currentContext.Rotation = angle;
        }

        /// <summary>
        /// Set the draw color tint for drawing operations.
        /// </summary>
        /// <param name="red">Red value.</param>
        /// <param name="green">Green value.</param>
        /// <param name="blue">Blue value.</param>
        public void SetDrawColor(int red, int green, int blue)
        {
            Gl.glColor4f((float)red / 255.0f, (float)green / 255.0f, (float)blue / 255.0f, (float)currentContext.DrawColor[3] / 255.0f);
            currentContext.DrawColor[0] = red; currentContext.DrawColor[1] = green; currentContext.DrawColor[2] = blue;
        }

        /// <summary>
        /// Set the alpha value for all drawing commands.
        /// </summary>
        /// <param name="alpha"></param>
        public void SetDrawAlpha(float alpha)
        {
            Gl.glColor4f((float)currentContext.DrawColor[0] / 255.0f, (float)currentContext.DrawColor[1] / 255.0f, (float)currentContext.DrawColor[2] / 255.0f, alpha);
            currentContext.DrawColor[3] = (int)(alpha * 255.0f);
        }

        /// <summary>
        /// Set the color to clear the screen to.
        /// </summary>
        /// <param name="red">Red value.</param>
        /// <param name="green">Green value.</param>
        /// <param name="blue">Blue value.</param>
        public void SetClearColor(int red, int green, int blue)
        {
            Gl.glClearColor((float)red / 255.0f, (float)green / 255.0f, (float)blue / 255.0f, 1.0f);
            currentContext.ClearColor[0] = red; currentContext.ClearColor[1] = green; currentContext.ClearColor[2] = blue;
        }

        /// <summary>
        /// Set the color which will be masked when loading an image.
        /// </summary>
        /// <param name="red">Red value.</param>
        /// <param name="green">Green value.</param>
        /// <param name="blue">Blue value.</param>
        public void SetMaskColor(int red, int green, int blue)
        {
            currentContext.MaskColor[0] = red; currentContext.MaskColor[1] = green; currentContext.MaskColor[2] = blue;
        }

        /// <summary>
        /// Set the blend mode operation.
        /// </summary>
        /// <param name="mode">The mode to use for blending.</param>
        public void SetBlend(BlendMode mode)
        {
            currentContext.BlendMode = mode;

            switch (mode)
            {
                case BlendMode.DARK:
                    Gl.glEnable(Gl.GL_BLEND);
                    Gl.glBlendFunc(Gl.GL_DST_COLOR, Gl.GL_ZERO);
                    Gl.glDisable(Gl.GL_ALPHA_TEST);

                    break;

                case BlendMode.LIGHT:
                    Gl.glEnable(Gl.GL_BLEND);
                    Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);
                    Gl.glDisable(Gl.GL_ALPHA_TEST);

                    break;

                case BlendMode.ALPHA:
                    Gl.glEnable(Gl.GL_BLEND);
                    Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
                    Gl.glDisable(Gl.GL_ALPHA_TEST);

                    break;

                case BlendMode.SOLID:
                case BlendMode.NONE:
                    Gl.glDisable(Gl.GL_BLEND);
                    Gl.glDisable(Gl.GL_ALPHA_TEST);

                    break;

                
            }
        }

        /// <summary>
        /// Set the render viewport.
        /// </summary>
        /// <param name="x">X position of the viewport.</param>
        /// <param name="y">Y position of the viewport.</param>
        /// <param name="width">Width of the viewport.</param>
        /// <param name="height">Height of the viewport.</param>
        public void SetViewport(int x, int y, int width, int height)
        {
            if (width != currentContext.Width && height != currentContext.Height)
            {
                Gl.glEnable(Gl.GL_SCISSOR_TEST);
                Gl.glScissor(x, currentContext.Height - y - height, width, height);
            }
            else
            {
                Gl.glDisable(Gl.GL_SCISSOR_TEST);
            }

            currentContext.ViewportX = x;
            currentContext.ViewportY = y;
            currentContext.ViewportWidth = width;
            currentContext.ViewportHeight = height;
        }
        #endregion

        #region Loading Methods
        /// <summary>
        /// Load a shader from disk.
        /// </summary>
        /// <param name="filePath">Path to the shader.</param>
        /// <param name="type">Type of the shader.</param>
        /// <param name="compile">True to compile shader upon loading.</param>
        /// <returns>The loaded shader.</returns>
        public Shader LoadShader(string filePath, ShaderType type, bool compile)
        {
            Shader shader;
            File file = FileManager.OpenFile(filePath, AccessMode.READ);
            shader = new Shader(new File[] { file }, type, compile);
            FileManager.CloseFile(file);
            return shader;
        }

        /// <summary>
        /// Load an image from disk.
        /// </summary>
        /// <param name="filePath">The name of the image to be loaded.</param>
        /// <returns>The loaded image.</returns>
        public Image LoadImage(string filePath)
        {
            FallenGE.File_System.File file = FallenGE.File_System.FileManager.OpenFile(filePath, FallenGE.File_System.AccessMode.READ);
            Image image = new Image(file, currentContext.MaskColor[0], currentContext.MaskColor[1], currentContext.MaskColor[2]);
            FallenGE.File_System.FileManager.CloseFile(file);
            return image;
        }

        /// <summary>
        /// Load an image from disk and split it into frames of given size.
        /// </summary>
        /// <param name="filePath">The name of the image to be loaded.</param>
        /// <param name="frameWidth">The width of one frame.</param>
        /// <param name="frameHeight">The height of one frame.</param>
        /// <returns>The loaded image.</returns>
        public Image LoadImage(string filePath, int frameWidth, int frameHeight)
        {
            FallenGE.File_System.File file = FallenGE.File_System.FileManager.OpenFile(filePath, FallenGE.File_System.AccessMode.READ);
            Image image = new Image(file, frameWidth, frameHeight, currentContext.MaskColor[0], currentContext.MaskColor[1], currentContext.MaskColor[2]);
            FallenGE.File_System.FileManager.CloseFile(file);
            return image;
        }

        /// <summary>
        /// Loads a font from disk.
        /// </summary>
        /// <param name="filePath">The name of the font to be loaded.</param>
        /// <param name="metricsPath">Path to the metrics data (REQUIRED).</param>
        /// <returns>The loaded font.</returns>
        public Font LoadFont(string filePath, string metricsPath)
        {
            FallenGE.File_System.File file1 = FallenGE.File_System.FileManager.OpenFile(filePath, FallenGE.File_System.AccessMode.READ);
            FallenGE.File_System.File file2 = FallenGE.File_System.FileManager.OpenFile(metricsPath, FallenGE.File_System.AccessMode.READ);
            Font font = new Font(file1, file2);
            FallenGE.File_System.FileManager.CloseFile(file1);
            FallenGE.File_System.FileManager.CloseFile(file2);
            return font;
        }
        #endregion

        #region Creation Methods
        /// <summary>
        /// Create a shader program.
        /// </summary>
        /// <param name="shaderList">The list of shaders in the program.</param>
        /// <returns>The new shader program.</returns>
        public ShaderProgram CreateShaderProgram(Shader[] shaderList)
        {
            return new ShaderProgram(shaderList);
        }
        #endregion

        #region Destruction Methods
        /// <summary>
        /// Destroy a shader program.
        /// </summary>
        /// <param name="program">The program to destroy.</param>
        public void DestroyShaderProgram(ShaderProgram program)
        {
            program.Unbind();
            program.Unload();
        }
        #endregion

        #region Unloading Methods
        /// <summary>
        /// Unload a shader a free used resources.
        /// </summary>
        /// <param name="shader">The shader to unload.</param>
        public void UnloadShader(Shader shader)
        {
            shader.Unload();
        }

        /// <summary>
        /// Unloads an image an frees the resources.
        /// </summary>
        /// <param name="image">The image to be unloaded.</param>
        public void UnloadImage(Image image)
        {
            image.Unload();
        }

        /// <summary>
        /// Unloads a font and frees the resources,
        /// </summary>
        /// <param name="font">The font to unload.</param>
        public void UnloadFont(Font font)
        {
            font.Unload();
        }
        #endregion

        #region Render Methods
        /// <summary>
        /// Draw an image at the given position.
        /// </summary>
        /// <param name="image">The image to draw.</param>
        /// <param name="x">The x position to draw at.</param>
        /// <param name="y">The y position to draw at.</param>
        public void DrawImage(Image image, float x, float y)
        {
            DrawImage(image, x, y, 0);
        }

        /// <summary>
        /// Draw an image at the given position.
        /// </summary>
        /// <param name="image">The image to draw.</param>
        /// <param name="x">The x position to draw at.</param>
        /// <param name="y">The y position to draw at.</param>
        /// <param name="frame">The frame of the image to draw.</param>
        public void DrawImage(Image image, float x, float y, int frame)
        {
            float fx, fy;
            int u, v, s, t;
            fx = fy = u = v = s = t = 0;

            fx = image.Width / image.FrameWidth;
            fy = image.Height / image.FrameHeight;

            if (frame != 0)
                v = (int)(frame / fx);
            u = (int)(frame % fx);

            u = (u * image.FrameWidth);
            v = (v * image.FrameHeight);
            s = image.FrameWidth;
            t = image.FrameHeight;

            DrawImage(image, x, y, u, v, s, t);
        }

        /// <summary>
        /// Draw an image at the given position.
        /// </summary>
        /// <param name="image">The image to draw.</param>
        /// <param name="x">The x position to draw at.</param>
        /// <param name="y">The y position to draw at.</param>
        /// <param name="s">X position within the image to draw.</param>
        /// <param name="t">Y position within the image to draw.</param>
        /// <param name="u">X2 position within the image to draw.</param>
        /// <param name="v">Y2 position within the image to draw.</param>
        public void DrawImage(Image image, float x, float y, int u, int v, int s, int t)
        {
            Vector2 a, b, c, d;
            float xRatio, yRatio, widthRatio, heightRatio;
            float[] uv = new float[4];

            xRatio = (float)((float)u / (float)image.TextureWidth);
            yRatio = (float)((float)v / (float)image.TextureHeight);
            widthRatio = (float)((float)s / (float)image.TextureWidth);
            heightRatio = (float)((float)t / (float)image.TextureHeight);

            uv[0] = xRatio;
            uv[1] = yRatio;
            uv[2] = xRatio + widthRatio;
            uv[3] = yRatio + heightRatio;

            a = new Vector2(0.0f, 0.0f);
            b = new Vector2(s, 0.0f);
            c = new Vector2(s, t);
            d = new Vector2(0.0f, t);
            a[0] += ((image.FrameWidth) * currentContext.Offset[0]); a[1] += ((image.FrameHeight) * currentContext.Offset[1]);
            b[0] += ((image.FrameWidth) * currentContext.Offset[0]); b[1] += ((image.FrameHeight) * currentContext.Offset[1]);
            c[0] += ((image.FrameWidth) * currentContext.Offset[0]); c[1] += ((image.FrameHeight) * currentContext.Offset[1]);
            d[0] += ((image.FrameWidth) * currentContext.Offset[0]); d[1] += ((image.FrameHeight) * currentContext.Offset[1]);
            a.Rotate((float)currentContext.Rotation);
            b.Rotate((float)currentContext.Rotation);
            c.Rotate((float)currentContext.Rotation);
            d.Rotate((float)currentContext.Rotation);

            a[0] *= currentContext.Scale[0]; a[1] *= currentContext.Scale[1];
            b[0] *= currentContext.Scale[0]; b[1] *= currentContext.Scale[1];
            c[0] *= currentContext.Scale[0]; c[1] *= currentContext.Scale[1];
            d[0] *= currentContext.Scale[0]; d[1] *= currentContext.Scale[1];

            x += currentContext.XOrigin;
            y += currentContext.YOrigin;

            Gl.glActiveTexture(Gl.GL_TEXTURE0);
            image.Bind();
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glTexCoord2f(uv[0], uv[1]);
            Gl.glVertex2f(x + a[0], y + a[1]);
            Gl.glTexCoord2f(uv[2], uv[1]);
            Gl.glVertex2f(x + b[0], y + b[1]);
            Gl.glTexCoord2f(uv[2], uv[3]);
            Gl.glVertex2f(x + c[0], y + c[1]);
            Gl.glTexCoord2f(uv[0], uv[3]);
            Gl.glVertex2f(x + d[0], y + d[1]);
            Gl.glEnd();
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, -1);
        }

        /// <summary>
        /// Draws a rect to the screen.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="width">Width of rect.</param>
        /// <param name="height">Height of rect.</param>
        public void DrawRect(float x, float y, float width, float height)
        {
            width *= currentContext.Scale[0];
            height *= currentContext.Scale[1];

            Vector2 a = new Vector2(0.0f, 0.0f);
            Vector2 b = new Vector2(width, 0.0f);
            Vector2 c = new Vector2(width, height);
            Vector2 d = new Vector2(0.0f, height);
            a[0] += (width * currentContext.Offset[0]); a[1] += (height * currentContext.Offset[1]);
            b[0] += (width * currentContext.Offset[0]); b[1] += (height * currentContext.Offset[1]);
            c[0] += (width * currentContext.Offset[0]); c[1] += (height * currentContext.Offset[1]);
            d[0] += (width * currentContext.Offset[0]); d[1] += (height * currentContext.Offset[1]);
            a.Rotate((float)currentContext.Rotation);
            b.Rotate((float)currentContext.Rotation);
            c.Rotate((float)currentContext.Rotation);
            d.Rotate((float)currentContext.Rotation);

            x += currentContext.XOrigin;
            y += currentContext.YOrigin;

            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex2f(x + a[0], y + a[1]);
            Gl.glVertex2f(x + b[0], y + b[1]);
            Gl.glVertex2f(x + c[0], y + c[1]);
            Gl.glVertex2f(x + d[0], y + d[1]);
            Gl.glEnd();
        }

        public void DrawText(string text, Font font, float x, float y)
        {
            font.DrawText(this, text, x, y);
        }

        public int TextWidth(string text, Font font)
        {
            return font.TextWidth(text);
        }

        /// <summary>
        /// Clear the screen.
        /// </summary>
        public void Cls()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
        }

        /// <summary>
        /// Flip the screen buffers.
        /// </summary>
        public void Flip()
        {
            Gdi.SwapBuffers(currentContext.DeviceContext);
        }

        /// <summary>
        /// Bind a shader program.
        /// </summary>
        /// <param name="program">The program to bind.</param>
        public void BindShaderProgram(ShaderProgram program)
        {
            program.Bind();
        }

        /// <summary>
        /// Unbind shader program.
        /// </summary>
        /// <param name="program">The program to unbind.</param>
        public void UnbindShaderProgram(ShaderProgram program)
        {
            program.Unbind();
        }
        #endregion

        /// <summary>
        /// Set the target of the renderer to an image. If null is passed
        /// then the backbuffer will become the target.
        /// </summary>
        /// <param name="image">Image to target.</param>
        public void SetTarget(Image image)
        {
            if (image != null)
            {
                image.Bind();

                oldWidth = Width; oldHeight = Height;
                ResizeContext(currentContext, image.Width, image.Height);
                Gl.glPushMatrix();
                Gl.glLoadIdentity();
                Gl.glScalef(1.0f, -1.0f, 1.0f);
                Gl.glTranslatef(0.0f, -image.Height, 0.0f);
                Gl.glMatrixMode(Gl.GL_MODELVIEW);

                targetTexture = image;
            }
            else
            {
                targetTexture.Bind();
				Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
				Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

                Gl.glCopyTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, 0, 0, targetTexture.TextureWidth, targetTexture.TextureHeight, 0);
				
				Gl.glClear(Gl.GL_COLOR_BUFFER_BIT|Gl.GL_DEPTH_BUFFER_BIT);
					
				ResizeContext(currentContext, oldWidth, oldHeight);
                Gl.glPopMatrix();
                Gl.glLoadIdentity();
				
				targetTexture = null;
            }
        }

        /// <summary>
        /// Set an float uniform in a shader.
        /// </summary>
        /// <param name="program">The program containing the uniform.</param>
        /// <param name="variable">Name of the variable/uniform.</param>
        /// <param name="values">Value to be set to.</param>
        public void SetShaderUniformf(ShaderProgram program, string variable, float[] values)
        {
            int location = Gl.glGetUniformLocation(program.ID, variable);

            switch (values.Length)
            {
                case 1:
                    Gl.glUniform1f(location, values[0]);
                    break;

                case 2:
                    Gl.glUniform2f(location, values[0], values[1]);
                    break;

                case 3:
                    Gl.glUniform3f(location, values[0], values[1], values[2]);
                    break;

                case 4:
                    Gl.glUniform4f(location, values[0], values[1], values[2], values[3]);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Set an interger uniform in a shader.
        /// </summary>
        /// <param name="program">The program containing the uniform.</param>
        /// <param name="variable">Name of the variable/uniform.</param>
        /// <param name="values">Value to be set to.</param>
        public void SetShaderUniformi(ShaderProgram program, string variable, int[] values)
        {
            int location = Gl.glGetUniformLocation(program.ID, variable);

            switch (values.Length)
            {
                case 1:
                    Gl.glUniform1i(location, values[0]);
                    break;

                case 2:
                    Gl.glUniform2i(location, values[0], values[1]);
                    break;

                case 3:
                    Gl.glUniform3i(location, values[0], values[1], values[2]);
                    break;

                case 4:
                    Gl.glUniform4i(location, values[0], values[1], values[2], values[3]);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Bind an image to a texture layer.
        /// </summary>
        /// <param name="image">The image to bind.</param>
        /// <param name="layer">Integer layer to bind to.</param>
        public void BindTexture(Image image, int layer)
        {
            if (image != null)
            {
                Gl.glActiveTexture(Gl.GL_TEXTURE0 + layer);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, image.Texture);
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
                Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            }
            else
            {
                Gl.glActiveTexture(Gl.GL_TEXTURE0 + layer);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, -1);
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
                Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            }
        }
        #endregion
    }
}
