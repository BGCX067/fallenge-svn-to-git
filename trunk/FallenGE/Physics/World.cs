using System;
using System.Collections.Generic;
using System.Text;
using Scalar = System.Single;

using Physics2DDotNet;
using Physics2DDotNet.Math2D;

using AdvanceMath;
using AdvanceMath.Geometry2D;

namespace FallenGE.Physics
{
    public class World
    {
        private List<Body> bodyList;
        private PhysicsEngine engine;
        private PhysicsTimer timer;

        public World()
        {
            float w, h;
            w = 640.0f; h = 480.0f;
            bodyList = new List<Body>();

            engine = new PhysicsEngine();
            engine.BroadPhase = new Physics2DDotNet.Detectors.BruteForceDetector();
            engine.Solver = new Physics2DDotNet.Solvers.SequentialImpulsesSolver();
            engine.AddLogic(new GravityField(new Vector2D(0, 500), new Lifespan()));

            Coefficients coffecients = new Coefficients(.8f, .5f);
            Shape floor = new Polygon(Polygon.CreateRectangle(100.0f, w), 2.0f);
            Shape left = new Polygon(Polygon.CreateRectangle(h, 100.0f), 2.0f);
            Shape right = new Polygon(Polygon.CreateRectangle(h, 100.0f), 2.0f);
            Physics2DDotNet.Body floorData = new Physics2DDotNet.Body(new PhysicsState(new ALVector2D(0.0f, w / 2.0f, h + 50.0f)), floor, new MassInfo(Scalar.PositiveInfinity, Scalar.PositiveInfinity), coffecients, new Lifespan());
            Physics2DDotNet.Body leftData = new Physics2DDotNet.Body(new PhysicsState(new ALVector2D(0.0f, -50.0f, h / 2.0f)), left, new MassInfo(Scalar.PositiveInfinity, Scalar.PositiveInfinity), coffecients, new Lifespan());
            Physics2DDotNet.Body rightData = new Physics2DDotNet.Body(new PhysicsState(new ALVector2D(0.0f, w + 50.0f, h / 2.0f)), right, new MassInfo(Scalar.PositiveInfinity, Scalar.PositiveInfinity), coffecients, new Lifespan());
            floorData.IgnoresGravity = true;
            leftData.IgnoresGravity = true;
            rightData.IgnoresGravity = true;
            engine.AddBody(floorData);
            engine.AddBody(leftData);
            engine.AddBody(rightData);
        }

        public void AddBody(Body body)
        {
            bodyList.Add(body);
            
            engine.AddBody(body.Data);
        }

        public void Update(float delta)
        {
            engine.Update(delta);
        }

        public List<Body> Bodies
        {
            get
            {
                return bodyList;
            }
        }
    }
}
