using System;
using System.Collections.Generic;
using System.Text;

namespace FallenGE.Math
{
    /// <summary>
    /// Represents a 3d vector.
    /// </summary>
    public class Vector3 : Vector2
    {
        #region Members
        private float z;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a vector based on x, y and z coords.
        /// </summary>
        /// <param name="x">Length along the x axis.</param>
        /// <param name="y">Length along the y axis.</param>
        /// <param name="z">Length along the z axis.</param>
        public Vector3(float x, float y, float z)
        {
            this[0] = x;
            this[1] = y;
            this[2] = z;
        }

        /// <summary>
        /// Creates a new vector by copying an old vector.
        /// </summary>
        /// <param name="copy">The vector to copy.</param>
        public Vector3(Vector3 copy)
        {
            this[0] = copy[0];
            this[1] = copy[1];
            this[2] = copy[2];
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get or Set the length along the x axis.
        /// </summary>
        public override float X { get { return x; } set { x = value; } }

        /// <summary>
        /// Get or Set the length along the y axis.
        /// </summary>
        public override float Y { get { return y; } set { y = value; } }

        /// <summary>
        /// Get or Set the length along the z axis.
        /// </summary>
        public float Z { get { return z; } set { z = value; } }

        /// <summary>
        /// Get or Set an index scalar.
        /// </summary>
        /// <param name="index">The index of the scalar to Get or Set.</param>
        /// <returns></returns>
        public override float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
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
                    case 2:
                        z = value; break;
                }
            }
        }

        /// <summary>
        /// Get the length ^2 of the vector.
        /// </summary>
        public override float LengthSquared
        {
            get
            {
                return (x * x) + (y * y) + (z * z);
            }
        }

        /// <summary>
        /// Get the dot product of the vector.
        /// </summary>
        public override float DotProduct
        {
            get { return LengthSquared; }
        }

        /// <summary>
        /// Get a vector normal to this instance.
        /// </summary>
        public Vector3 Normal
        {
            get {
                return new Vector3(x * (1.0f / Length),
                                   y * (1.0f / Length),
                                   z * (1.0f / Length));
            }
        }
        #endregion

        #region Operator Overloads
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a[0] + b[0], a[1] + b[1], a[2] + b[2]);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a[0] - b[0], a[1] - b[1], a[2] - b[2]);
        }

        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a[0], -a[1], -a[2]);
        }

        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a[0] * b[0], a[1] * b[1], a[2] * b[2]);
        }

        public static Vector3 operator *(Vector3 a, float b)
        {
            return new Vector3(a[0] * b, a[1] * b, a[2] * b);
        }

        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return new Vector3(a[0] / b[0], a[1] / b[1], a[2] / b[2]);
        }

        public static Vector3 operator /(Vector3 a, float b)
        {
            return new Vector3(a[0] / b, a[1] / b, a[2] / b);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Zeros all members of the vector.
        /// </summary>
        public override void Zero()
        {
            this[0] = this[1] = this[2] = 0.0f;
        }

        /// <summary>
        /// Resolves vectors length to 1 keeping direction the same (Creates a direction vector).
        /// </summary>
        public override void Normalize()
        {
            x *= (1.0f / Length);
            y *= (1.0f / Length);
            z *= (1.0f / Length);
        }

        /// <summary>
        /// Calculates the dot product between this vector and another.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The dot product between the two vectors.</returns>
        public override float Dot(Vector2 other)
        {
            return (this[0] * other[0] + this[1] * other[1] + this[2] * other[2]);
        }

        /// <summary>
        /// Calculates the cross product of a vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The cross product of the two vectors.</returns>
        public virtual Vector3 Cross(Vector3 other)
        {
            return new Vector3(this[1] * other[2] - other[1] * this[2],
                                this[2] * other[0] - other[2] * this[0],
                                this[0] * other[1] - other[0] * this[1]);
        }

        #endregion
    }
}
