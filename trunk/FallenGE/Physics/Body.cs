using System;
using System.Collections.Generic;
using System.Text;

using Physics2DDotNet;
using Physics2DDotNet.Math2D;

using AdvanceMath;
using AdvanceMath.Geometry2D;

namespace FallenGE.Physics
{
    public class Body
    {
        private Physics2DDotNet.PhysicsState state;
        private Physics2DDotNet.Body data;

        public Body(float x, float y, float radius, float bounce, float friction, float mass)
        {
            Coefficients coffecients = new Coefficients(bounce, friction);
            Shape shape = new Circle(radius, 16);
            state = new PhysicsState(new ALVector2D(0.0f, x, y));
            data = new Physics2DDotNet.Body(state, shape, mass, coffecients, new Lifespan());
        }

        public Body(float x, float y, float width, float height, float bounce, float friction, float mass)
        {
            Coefficients coffecients = new Coefficients(bounce, friction);
            Shape shape = new Polygon(Polygon.CreateRectangle(height, width), 3.0f);
            state = new PhysicsState(new ALVector2D(0.0f, x, y));
            data = new Physics2DDotNet.Body(state, shape, mass, coffecients, new Lifespan());
        }

        public void ApplyForce(float x, float y)
        {
            data.ApplyForce(new Vector2D(x, y)); 
            
        }

        public Physics2DDotNet.Body Data
        {
            get
            {
                return data;
            }
        }

        public bool IsResting
        {
            get
            {
                return !Convert.ToBoolean(((int)data.KineticEnergy));
            }
        }

        public float X
        {
            get
            {
                return data.State.Position.Linear.X;
            }
        }

        public float Y
        {
            get
            {
                return data.State.Position.Linear.Y;
            }
        }

        public float Rotation
        {
            get
            {
                return data.State.Position.Angular;
            }
        }
    }
}
