using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Tao.DevIl;
using Tao.OpenGl;

using FallenGE.File_System;

namespace FallenGE.Graphics
{
    /// <summary>
    /// Represents an image.
    /// </summary>
    [Serializable]
    public class Image
    {
        #region Members
        private int width, height;
        private int frameWidth, frameHeight;
        private int textureWidth, textureHeight;
        private float widthRatio, heightRatio;
        private int frameCount;

        private int ilName;
        private int glName = -1;

        private IntPtr imageData;
        private byte[] tmpData;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new blank image.
        /// </summary>
        /// <param name="width">Width of the image.</param>
        /// <param name="height">Height of the image.</param>
        public Image(int width, int height)
        {
            int[] textures = new int[1];
            Gl.glGenTextures(1, textures);
            glName = textures[0];

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, glName);

            this.width = width;
            this.height = height;

            this.frameWidth = width;
            this.frameHeight = height;

            this.textureWidth = Math.Global.NextPow2(width);
            this.textureHeight = Math.Global.NextPow2(height);

            this.widthRatio = (float)width / textureWidth;
            this.heightRatio = (float)height / textureHeight;

            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, 4, textureWidth, textureHeight, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, null);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, -1);
        }

        /// <summary>
        /// Create a new image.
        /// </summary>
        /// <param name="file">The file that contains image data.</param>
        /// <param name="redMask">The red value of the color to be masked.</param>
        /// <param name="greenMask">The green value of the color to be masked.</param>
        /// <param name="blueMask">The blue value of the color to be masked.</param>
        public Image(File file, int redMask, int greenMask, int blueMask)
        {
            Il.ilGenImages(1, out ilName);

            Il.ilBindImage(ilName);

            FallenGE.Utility.Buffer buffer = new FallenGE.Utility.Buffer();

            uint size = Convert.ToUInt32(FallenGE.File_System.FileManager.FileSize(file));

            FallenGE.File_System.FileManager.Read(file, buffer, size, 1);

            Il.ilLoadL(Il.IL_TYPE_UNKNOWN, buffer.Data, Convert.ToInt32(size));

            Il.ilConvertImage(Il.IL_RGBA, Il.IL_UNSIGNED_BYTE);

            int[] textures = new int[1];
            Gl.glGenTextures(1, textures);
            glName = textures[0];

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, glName);

            width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

            frameWidth = width;
            frameHeight = height;

            textureWidth = Math.Global.NextPow2(width);
            textureHeight = Math.Global.NextPow2(height);

            widthRatio = (float)width / textureWidth;
            heightRatio = (float)height / textureHeight;

            int xFrames, yFrames;
            xFrames = width / frameWidth;
            yFrames = height / frameHeight;
            frameCount = xFrames * yFrames;

            if (textureWidth != width || textureHeight != height)
            {
                imageData = Marshal.AllocHGlobal(textureWidth * textureHeight * 4);
                Il.ilCopyPixels(0, 0, 0, textureWidth, textureHeight, 1, Il.IL_RGBA, Il.IL_UNSIGNED_BYTE, imageData);
            }
            else
            {
                imageData = Il.ilGetData();
            }

            tmpData = new byte[textureWidth * textureHeight * 4];
            Marshal.Copy(imageData, tmpData, 0, tmpData.Length);
            for (int i = 0; i < tmpData.Length; i += 4)
            {
                if (tmpData[i + 0] == redMask && tmpData[i + 1] == greenMask && tmpData[i + 2] == blueMask)
                    tmpData[i + 3] = 0;
            }
            Marshal.Copy(tmpData, 0, imageData, tmpData.Length);

            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Il.ilGetInteger(Il.IL_IMAGE_BPP), textureWidth, textureHeight, 0, Il.ilGetInteger(Il.IL_IMAGE_FORMAT), Gl.GL_UNSIGNED_BYTE, imageData);

            string ext = file.Path.Substring(file.Path.Length - 3, 3);
            /*if (ext == "bmp")
            {
                Gl.glMatrixMode(Gl.GL_TEXTURE);
                Gl.glTranslatef(0.5f, 0.5f, 0.0f);
                Gl.glScalef(-1.0f, 1.0f, 1.0f);
                Gl.glRotatef(180.0f, 0.0f, 0.0f, 1.0f);
                Gl.glTranslatef(-0.5f, -0.5f, 0.0f);
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
            }*/

            Il.ilDeleteImages(1, ref ilName);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, -1);

            buffer.Destroy();
        }

        /// <summary>
        /// Create a new image.
        /// </summary>
        /// <param name="file">The file that contains image data.</param>
        /// <param name="frameWidth">Width of an image frame.</param>
        /// <param name="frameHeight">Height of an image frame.</param>
        /// <param name="redMask">The red value of the color to be masked.</param>
        /// <param name="greenMask">The green value of the color to be masked.</param>
        /// <param name="blueMask">The blue value of the color to be masked.</param>
        public Image(File file, int frameWidth, int frameHeight, int redMask, int greenMask, int blueMask)
        {
            Il.ilGenImages(1, out this.ilName);

            Il.ilBindImage(this.ilName);

            FallenGE.Utility.Buffer buffer = new FallenGE.Utility.Buffer();

            uint size = Convert.ToUInt32(FallenGE.File_System.FileManager.FileSize(file));

            FallenGE.File_System.FileManager.Read(file, buffer, size, 1);

            Il.ilLoadL(Il.IL_TYPE_UNKNOWN, buffer.Data, Convert.ToInt32(size));

            Il.ilConvertImage(Il.IL_RGBA, Il.IL_UNSIGNED_BYTE);

            int[] textures = new int[1];
            Gl.glGenTextures(1, textures);
            this.glName = textures[0];

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, glName);

            this.width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            this.height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;

            this.textureWidth = Math.Global.NextPow2(this.width);
            this.textureHeight = Math.Global.NextPow2(this.height);

            this.widthRatio = (float)this.width / this.textureWidth;
            this.heightRatio = (float)this.height / this.textureHeight;

            int xFrames, yFrames;
            xFrames = width / frameWidth;
            yFrames = height / frameHeight;
            frameCount = xFrames * yFrames;

            if (this.textureWidth != this.width || this.textureHeight != this.height)
            {
                this.imageData = Marshal.AllocHGlobal(this.textureWidth * this.textureHeight * 4);
                Il.ilCopyPixels(0, 0, 0, this.textureWidth, this.textureHeight, 1, Il.IL_RGBA, Il.IL_UNSIGNED_BYTE, this.imageData);
            }
            else
            {
                this.imageData = Il.ilGetData();
            }

            tmpData = new byte[this.textureWidth * this.textureHeight * 4];
            Marshal.Copy(this.imageData, tmpData, 0, tmpData.Length);
            for (int i = 0; i < tmpData.Length; i += 4)
            {
                if (tmpData[i + 0] == redMask && tmpData[i + 1] == greenMask && tmpData[i + 2] == blueMask)
                    tmpData[i + 3] = 0;
            }
            Marshal.Copy(tmpData, 0, imageData, tmpData.Length);

            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Il.ilGetInteger(Il.IL_IMAGE_BPP), this.textureWidth, this.textureHeight, 0, Il.ilGetInteger(Il.IL_IMAGE_FORMAT), Gl.GL_UNSIGNED_BYTE, this.imageData);

            string ext = file.Path.Substring(file.Path.Length - 3, 3);
            /*if (ext == "bmp")
            {
                Gl.glMatrixMode(Gl.GL_TEXTURE);
                Gl.glTranslatef(0.5f, 0.5f, 0.0f);
                Gl.glScalef(-1.0f, 1.0f, 1.0f);
                Gl.glRotatef(180.0f, 0.0f, 0.0f, 1.0f);
                Gl.glTranslatef(-0.5f, -0.5f, 0.0f);
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
            }*/

            Il.ilDeleteImages(1, ref this.ilName);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, -1);

            buffer.Destroy();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get the width of the image.
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }
        }

        /// <summary>
        /// Get the height of the image.
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }
        }

        /// <summary>
        /// Get the frame width of the image.
        /// </summary>
        public int FrameWidth
        {
            get
            {
                return frameWidth;
            }
        }

        /// <summary>
        /// Get the frame height of the image.
        /// </summary>
        public int FrameHeight
        {
            get
            {
                return frameHeight;
            }
        }

        /// <summary>
        /// Get the texture width of the image.
        /// </summary>
        public int TextureWidth
        {
            get
            {
                return textureWidth;
            }
        }

        /// <summary>
        /// Get the texture height of the image.
        /// </summary>
        public int TextureHeight
        {
            get
            {
                return textureHeight;
            }
        }

        /// <summary>
        /// Get the number of frames in the image.
        /// </summary>
        public int FrameCount
        {
            get
            {
                return frameCount;
            }
        }

        /// <summary>
        /// Get the image data.
        /// </summary>
        public byte[] Data
        {
            get
            {
                return tmpData;
            }
        }

        /// <summary>
        /// Get the opengl texture name.
        /// </summary>
        public int Texture
        {
            get
            {
                return glName;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Unload the image and free its resources.
        /// </summary>
        public void Unload()
        {
            int[] textures = { glName };
            Gl.glDeleteTextures(1, textures);
        }

        /// <summary>
        /// Bind the texture used by the image.
        /// </summary>
        public void Bind()
        {
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, glName);
        }

        /// <summary>
        /// Open the image to be painted onto.
        /// </summary>
        public void BeginPaint()
        {
            Bind();
            imageData = Marshal.AllocHGlobal(textureWidth * textureHeight * 4);
            Gl.glGetTexImage(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, imageData);

            tmpData = new byte[textureWidth * textureHeight * 4];
            Marshal.Copy(imageData, tmpData, 0, tmpData.Length);
        }

        /// <summary>
        /// Close the image and upload the resulting texture.
        /// </summary>
        public void EndPaint()
        {
            Marshal.Copy(tmpData, 0, imageData, tmpData.Length);

            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, textureWidth, textureHeight, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, imageData);

            Marshal.FreeHGlobal(imageData);
        }

        /// <summary>
        /// Paint a pixel onto the image.
        /// </summary>
        /// <param name="x">X position of the pixel.</param>
        /// <param name="y">Y position of the pixel.</param>
        /// <param name="red">Red color of the pixel.</param>
        /// <param name="green">Green color of the pixel.</param>
        /// <param name="blue">Blue color of the pixel.</param>
        /// <param name="alpha">Alpha value of the pixel.</param>
        public void PaintPixel(int x, int y, byte red, byte green, byte blue, float alpha)
        {
            int i = (x + (y * textureWidth)) * 4;
            if (i < tmpData.Length && i > 0)
            {
                tmpData[i + 0] = red;
                tmpData[i + 1] = green;
                tmpData[i + 2] = blue;
                tmpData[i + 3] = (byte)(alpha * 255.0f);
            }
        }

        /// <summary>
        /// Paints a pixel by combing alpha values.
        /// </summary>
        /// <param name="x">X position of the pixel.</param>
        /// <param name="y">Y position of the pixel.</param>
        /// <param name="red">Red color of the pixel.</param>
        /// <param name="green">Green color of the pixel.</param>
        /// <param name="blue">Blue color of the pixel.</param>
        /// <param name="alpha">Alpha value of the pixel.</param>
        public void AddPixel(int x, int y, byte red, byte green, byte blue, float alpha)
        {
            int i = (x + (y * textureWidth)) * 4;
            if (i < tmpData.Length && i > 0)
            {
                tmpData[i + 0] = red;
                tmpData[i + 1] = green;
                tmpData[i + 2] = blue;

                if (tmpData[i + 3] + (byte)(alpha * 255.0f) > 255)
                    tmpData[i + 3] = 255;
                else
                    tmpData[i + 3] += (byte)(alpha * 255.0f);
            }
        }

        /// <summary>
        /// Get the textures width ratio.
        /// </summary>
        public float WidthRatio
        {
            get { return widthRatio; }
        }

        /// <summary>
        /// Get the textures height ratio.
        /// </summary>
        public float HeightRatio
        {
            get { return heightRatio; }
        }
        #endregion
    }
}
