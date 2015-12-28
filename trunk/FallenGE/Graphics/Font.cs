using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FallenGE.Graphics
{
    /// <summary>
    /// Represents a font.
    /// </summary>
    [Serializable]
    public class Font
    {
        #region Members
        private Image texture;
        private int[] width;
        private int height;
        #endregion

        #region Properties
        /// <summary>
        /// Get the fonts texture sheet.
        /// </summary>
        public Image Texture
        {
            get { return texture; }
        }

        /// <summary>
        /// Get the height of the font (Normally 32).
        /// </summary>
        public int Height
        {
            get { return height; }
        }

        /// <summary>
        /// Get the width of a character.
        /// </summary>
        public int[] Width
        {
            get { return width; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Create a font from a font bitmap and font metrics data.
        /// </summary>
        /// <param name="file">File that contains font data.</param>
        /// <param name="metrics">File that contains metrics data.</param>
        public Font(File_System.File file, File_System.File metrics)
        {
            texture = new Image(file, 32, 32, 0, 0, 0);

            FallenGE.Utility.Buffer buffer = new FallenGE.Utility.Buffer(512);
            FallenGE.File_System.FileManager.Read(metrics, buffer, 1, 512);

            width = new int[512];
            for (int i = 0; i < 512; i += 2)
            {
                width[i / 2] = (int)Marshal.ReadByte(buffer.Data, i);
            }

            height = 32;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calculate the text with based on the font.
        /// </summary>
        /// <param name="text">The text to be calculated.</param>
        /// <returns>The width in pixels of the text.</returns>
        public int TextWidth(string text)
        {
            int total = 0;
            foreach (char c in text)
            {
                total += Width[(int)c];
            }
            return total;
        }
        
        /// <summary>
        /// Unload a font and free used resources.
        /// </summary>
        public void Unload()
        {
            texture.Unload();
        }

        /// <summary>
        /// Draws some text to the screen using the given renderer.
        /// </summary>
        /// <param name="renderer">Render which performs the draw.</param>
        /// <param name="text">Text to draw.</param>
        /// <param name="x">X position of the text.</param>
        /// <param name="y">Y position of the text.</param>
        public void DrawText(Renderer renderer, string text, float x, float y)
        {
            int u, v, s, t;
            float ox, oy;

            ox = renderer.CurrentContext.Offset[0]; oy = renderer.CurrentContext.Offset[1];
            x += ((float)renderer.TextWidth(text, this) * renderer.CurrentContext.Offset[0]);
            y += (32.0f * renderer.CurrentContext.Offset[1]);

            renderer.SetOffset(0.0f, 0.0f);
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    u = v = s = t = 0;

                    float fx = texture.Width / texture.FrameWidth;
                    float fy = texture.Height / texture.FrameHeight;

                    if ((int)text[i] != 0)
                        v = (int)((int)text[i] / fx);
                    u = (int)((int)text[i] % fx);

                    u = (u * texture.FrameWidth);
                    v = (v * texture.FrameHeight);
                    s = this.Width[(int)text[i]];
                    t = texture.FrameHeight;

                    renderer.DrawImage(this.Texture, x, y, u, v, s, t);
                }
                int w = this.Width[(int)text[i]];
                x += w;
            }
            renderer.SetOffset(ox, oy);
        }
        #endregion
    }
}
