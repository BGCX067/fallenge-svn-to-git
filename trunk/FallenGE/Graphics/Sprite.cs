using System;
using System.Collections.Generic;
using System.Text;

using FallenGE.Math;

namespace FallenGE.Graphics
{
    /// <summary>
    /// Represents a sprite to be displayed by a sprite manager.
    /// </summary>
    [Serializable]
    public class Sprite
    {
        #region Members
        private Image image;
        private int[] color;
        private float alpha;
        private float rotation;
        private float[] scale;
        private float[] origin;
        private int z;
        private Vector2 position;
        private Vector2 velocity;
        private Animation animation;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new sprite from an image at the given location.
        /// </summary>
        /// <param name="image">The image to use for the sprite.</param>
        /// <param name="x">X position of the sprite.</param>
        /// <param name="y">Y position of the sprite.</param>
        public Sprite(Image image, float x, float y)
        {
            this.image = image;
            this.position = new Vector2(x, y);
            this.velocity = new Vector2();
            this.color = new int[3];
            this.animation = new Animation();
            this.origin = new float[2];
            this.scale = new float[2];

            SetScale(1.0f, 1.0f);
            SetOffset(0.0f, 0.0f);
            SetColor(255, 255, 255);
            SetAlpha(1.0f);
        }

        /// <summary>
        /// Create a new sprite from an image at the given location.
        /// </summary>
        /// <param name="image">The image to use for the sprite.</param>
        /// <param name="x">X position of the sprite.</param>
        /// <param name="y">Y position of the sprite.</param>
        /// <param name="z">Z position of the sprite, this is for render ordering.</param>
        public Sprite(Image image, float x, float y, int z)
        {
            this.image = image;
            this.z = z;
            this.position = new Vector2(x, y);
            this.velocity = new Vector2();
            this.color = new int[3];
            this.animation = new Animation();
            this.origin = new float[2];
            this.scale = new float[2];

            SetScale(1.0f, 1.0f);
            SetOffset(0.0f, 0.0f);
            SetColor(255, 255, 255);
            SetAlpha(1.0f);
        }

        /// <summary>
        /// Create a new sprite from an image at the given location.
        /// </summary>
        /// <param name="image">The image to use for the sprite.</param>
        /// <param name="x">X position of the sprite.</param>
        /// <param name="y">Y position of the sprite.</param>
        /// <param name="z">Z position of the sprite, this is for render ordering.</param>
        /// <param name="animationStart">Index of the starting frame.</param>
        /// <param name="animationEnd">Index of the ending frame.</param>
        /// <param name="animtionSpeed">Speed in milliseconds of the animation.</param>
        public Sprite(Image image, float x, float y, int z, int animationStart, int animationEnd, int animtionSpeed)
        {
            this.image = image;
            this.z = z;
            this.position = new Vector2(x, y);
            this.velocity = new Vector2();
            this.color = new int[3];
            this.animation = new Animation(animationStart, animationEnd, animtionSpeed);
            this.origin = new float[2];
            this.scale = new float[2];

            SetScale(1.0f, 1.0f);
            SetOffset(0.0f, 0.0f);
            SetColor(255, 255, 255);
            SetAlpha(1.0f);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set the rotation of the sprite.
        /// </summary>
        /// <param name="r">Rotation to be set to.</param>
        public void SetRotation(float r)
        {
            this.rotation = r;
        }

        /// <summary>
        /// Set the sprite scale.
        /// </summary>
        /// <param name="x">X scalar.</param>
        /// <param name="y">Y scalar.</param>
        public void SetScale(float x, float y)
        {
            this.scale[0] = x;
            this.scale[1] = y;
        }

        /// <summary>
        /// Set the internal offset of the sprite.
        /// </summary>
        /// <param name="x">X offset.</param>
        /// <param name="y">Y offset.</param>
        public void SetOffset(float x, float y)
        {
            this.origin[0] = x;
            this.origin[1] = y;
        }

        /// <summary>
        /// Rotate the sprite by a given amount.
        /// </summary>
        /// <param name="r">The amount to rotate by.</param>
        public void Rotate(float r)
        {
            this.rotation += r;
        }

        /// <summary>
        /// Set the color of the sprite.
        /// </summary>
        /// <param name="red">Red color value.</param>
        /// <param name="green">Green color value.</param>
        /// <param name="blue">Blue color value.</param>
        public void SetColor(int red, int green, int blue)
        {
            this.color[0] = red;
            this.color[1] = green;
            this.color[2] = blue;
        }

        /// <summary>
        /// Set the alpha value of the sprite.
        /// </summary>
        /// <param name="alpha">The new alpha value.</param>
        public void SetAlpha(float alpha)
        {
            this.alpha = alpha;
        }

        /// <summary>
        /// Render the sprite using the given renderer.
        /// </summary>
        /// <param name="renderer">The renderer to use to draw the sprite.</param>
        public void Render(Renderer renderer)
        {
            float oldRotation, oldScaleX, oldScaleY, oldOffsetX, oldOffsetY;
            int oldRed, oldGreen, oldBlue;

            oldRed = renderer.DrawRedValue;
            oldGreen = renderer.DrawGreenValue;
            oldBlue = renderer.DrawBlueValue;

            oldRotation = (float)renderer.Rotation;

            oldScaleX = renderer.XScale;
            oldScaleY = renderer.YScale;

            oldOffsetX = renderer.XOffset;
            oldOffsetY = renderer.YOffset;

            renderer.SetRotation(this.rotation);
            renderer.SetScale(this.scale[0], this.scale[1]);
            renderer.SetOffset(this.origin[0], this.origin[1]);
            renderer.SetDrawColor(color[0], color[1], color[2]);
            renderer.DrawImage(image, position[0], position[1], animation.Frame);
            renderer.SetDrawColor(oldRed, oldGreen, oldBlue);
            renderer.SetOffset(oldOffsetX, oldOffsetY);
            renderer.SetScale(oldScaleX, oldScaleY);
            renderer.SetRotation(oldRotation);
        }

        /// <summary>
        /// Tests if this sprite overlaps (rect) another sprite.
        /// </summary>
        /// <param name="other">The other sprite to test.</param>
        /// <returns>True if sprites overlap.</returns>
        public bool Collide(Sprite other)
        {
            if ((other.X < this.X + this.Width) && (other.X + other.Width > this.X) &&
                 ((other.Y + other.Height > this.Y) && (other.Y < this.Y + this.Height))
                )
                return true;

            return false;
        }

        /// <summary>
        /// Used to compare to sprites z values.
        /// </summary>
        /// <param name="a">The first sprite.</param>
        /// <param name="b">The second sprite.</param>
        /// <returns>The value.</returns>
        public static int Compare(Sprite a, Sprite b)
        {
            if (a.Z < b.Z)
                return -1;
            else if (a.Z > b.Z)
                return 1;
            return 0;
        }

        /// <summary>
        /// Update the sprite.
        /// </summary>
        /// <param name="delta">Current delta time.</param>
        public void Update(float delta)
        {
            this.position += velocity * delta;
            this.animation.Update();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get or Set the z value.
        /// </summary>
        public int Z
        {
            get
            {
                return this.z;
            }
            set
            {
                this.z = value;
            }
        }

        /// <summary>
        /// Get the width of the sprite.
        /// </summary>
        public int Width
        {
            get
            {
                return this.image.FrameWidth;
            }
        }

        /// <summary>
        /// Get the height of the sprite.
        /// </summary>
        public int Height
        {
            get
            {
                return this.image.FrameHeight;
            }
        }

        /// <summary>
        /// Get or Set the x position.
        /// </summary>
        public float X
        {
            get
            {
                return position.X;
            }
            set
            {
                position.X = value;
            }
        }

        /// <summary>
        /// Get or Set the y position.
        /// </summary>
        public float Y
        {
            get
            {
                return position.Y;
            }
            set
            {
                position.Y = value;
            }
        }

        /// <summary>
        /// Get or Set the x velocity.
        /// </summary>
        public float VelocityX
        {
            get
            {
                return velocity.X;
            }
            set
            {
                velocity.X = value;
            }
        }

        /// <summary>
        /// Get or Set the y velocity.
        /// </summary>
        public float VelocityY
        {
            get
            {
                return velocity.Y;
            }
            set
            {
                velocity.Y = value;
            }
        }

        /// <summary>
        /// Get or Set the red color.
        /// </summary>
        public int Red
        {
            get { return color[0]; }
            set { color[0] = value; }
        }

        /// <summary>
        /// Get or Set the green color.
        /// </summary>
        public int Green
        {
            get { return color[1]; }
            set { color[1] = value; }
        }

        /// <summary>
        /// Get or Set the blue color.
        /// </summary>
        public int Blue
        {
            get { return color[2]; }
            set { color[2] = value; }
        }

        /// <summary>
        /// Get or Set the x scale.
        /// </summary>
        public float XScale
        {
            get { return scale[0]; }
            set { scale[0] = value; }
        }

        /// <summary>
        /// Get or Set the y scale.
        /// </summary>
        public float YScale
        {
            get { return scale[1]; }
            set { scale[1] = value; }
        }

        /// <summary>
        /// Get or Set the x offset.
        /// </summary>
        public float XOffset
        {
            get { return origin[0]; }
            set { origin[0] = value; }
        }

        /// <summary>
        /// Get or Set the y offset.
        /// </summary>
        public float YOffset
        {
            get { return origin[1]; }
            set { origin[1] = value; }
        }

        /// <summary>
        /// Get or Set the rotation.
        /// </summary>
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        /// <summary>
        /// Get or Set the alpha.
        /// </summary>
        public float Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        #endregion
    }
}
