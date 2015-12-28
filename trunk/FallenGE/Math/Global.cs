using System;
using System.Collections.Generic;
using System.Text;

namespace FallenGE.Math
{
    class Global
    {
        public static float ZERO = 0.0001f;
        public static float EPSILON = 0.0000001f;

        public static int NextPow2(int i)
        {
            int x = 1;

            while (x < i)
                x <<= 1;

            return x;
        }

        public static float Target(Vector2 origin, Vector2 target)
        {
            return (float)System.Math.Atan2(origin[1] - target[1], origin[0] - target[0]);
        }

        public static float Distance(Vector2 origin, Vector2 target)
        {
            return (float)System.Math.Sqrt(((origin[0] - target[0]) * (origin[0] - target[0])) + ((origin[1] - target[1]) * (origin[1] - target[1])));
        }

        public static bool IsZero(float value)
        {
            return (value < ZERO && value > -ZERO);
        }

        public static void GetEuler(float[] matrix, ref float kx, ref float ky, ref float kz)
        {
            if (matrix[0] < 1.0f - EPSILON && matrix[0] > -1.0f + EPSILON)
            {
                ky = -(float)System.Math.Asin(matrix[0]);
                float c = (float)System.Math.Cos(ky);
                kx = (float)System.Math.Atan2(matrix[3] / c, matrix[7] / c);
                kz = (float)System.Math.Atan2(matrix[1] / c, matrix[0] / c);
            }
            else
            {
                kz = 0.0f;
                ky = -(float)System.Math.Atan2(matrix[0], 0);
                kx = (float)System.Math.Atan2(-matrix[6], matrix[3]);
            }
        } 
    }
}
