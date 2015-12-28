using System;
using System.Collections.Generic;
using System.Text;

namespace FallenGE.Math
{
    /// <summary>
    /// Represents a 2D vector.
    /// </summary>
    public class Vector2
    {
        #region Members
        protected float x, y;
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a zero vector2.
        /// </summary>
        public Vector2()
        {
            Zero();
        }

        /// <summary>
        /// Creates a vector based on x and y coords.
        /// </summary>
        /// <param name="x">Length along the x axis.</param>
        /// <param name="y">Length along the y axis.</param>
        public Vector2(float x, float y)
        {
            this[0] = x;
            this[1] = y;
        }

        /// <summary>
        /// Creates a new vector by copying an old vector.
        /// </summary>
        /// <param name="copy">The vector to copy.</param>
        public Vector2(Vector2 copy)
        {
            this[0] = copy[0];
            this[1] = copy[1];
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get or Set the length along the x axis.
        /// </summary>
        public virtual float X { get { return x; } set { x = value; } }

        /// <summary>
        /// Get or Set the length along the y axis.
        /// </summary>
        public virtual float Y { get { return y; } set { y = value; } }

        /// <summary>
        /// Get or Set an index scalar.
        /// </summary>
        /// <param name="index">The index of the scalar to Get or Set.</param>
        /// <returns></returns>
        public virtual float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        return 0.0f;
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value; break;
                    case 1:
                        y = value; break;
                }
            }
        }

        /// <summary>
        /// Get or Set the length of the vector.
        /// </summary>
        public virtual float Length
        {
            get
            {
                return (float)System.Math.Sqrt(LengthSquared);
            }

            set
            {
                float angle = this.Angle;

                this[0] = (float)System.Math.Cos(angle) * (float)value;
                this[1] = (float)-System.Math.Sin(angle) * (float)value;
            }
        }

        /// <summary>
        /// Get or Set the angle or direction of the vector.
        /// </summary>
        public virtual float Angle
        {
            get
            {
                return (float)(System.Math.PI - System.Math.Atan2(y, x));
            }

            set
            {
                float length = this.Length;

                this[0] = (float)System.Math.Cos(Angle) * (float)value;
                this[1] = (float)-System.Math.Sin(Angle) * (float)value;
            }
        }

        /// <summary>
        /// Get the length ^2 of the vector.
        /// </summary>
        public virtual float LengthSquared
        {
            get
            {
                return (x * x) + (y * y);
            }
        }

        /// <summary>
        /// Get the dot product of the vector.
        /// </summary>
        public virtual float DotProduct
        {
            get { return LengthSquared; }
        }

        /// <summary>
        /// Get a vector normal to this instance.
        /// </summary>
        public Vector2 Normal
        {
            get {
                return new Vector2(x * (1.0f / Length),
                                   y * (1.0f / Length));
            }
        }
        
        /// <summary>
        /// Rotates a vector.
        /// </summary>
        /// <param name="rot">Rotation of vector.</param>
        public void Rotate(float rot)
        {

            Vector2 result = new Vector2(this);//.Normalize();
            //Cos(Angle#)*X# - Sin(Angle#)*Y
            //Cos(Angle#)*Y# + Sin(Angle#)*X
            this[0] = ((float)System.Math.Cos(rot) * result[0]) - ((float)System.Math.Sin(rot) * result[1]);
            this[1] = ((float)System.Math.Sin(rot) * result[0]) + ((float)System.Math.Cos(rot) * result[1]);

            //this[0] = result[0];
            // this[1] = result[1];
        }
        #endregion

        #region Operator Overloads
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a[0] + b[0], a[1] + b[1]);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a[0] - b[0], a[1] - b[1]);
        }

        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(-a[0], -a[1]);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a[0] * b[0], a[1] * b[1]);
        }

        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a[0] * b, a[1] * b);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a[0] / b[0], a[1] / b[1]);
        }

        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a[0] / b, a[1] / b);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Zeros all members of the vector.
        /// </summary>
        public virtual void Zero()
        {
            this[0] = this[1] = 0.0f;
        }

        /// <summary>
        /// Resolves vectors length to 1 keeping direction the same (Creates a direction vector).
        /// </summary>
        public virtual void Normalize()
        {
            x *= (1.0f / Length);
            y *= (1.0f / Length);
        }

        /// <summary>
        /// Calculates the dot product between this vector and another.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The dot product between the two vectors.</returns>
        public virtual float Dot(Vector2 other)
        {
            return (this[0] * other[0] + this[1] * other[1]);
        }

        #endregion
    }
}
