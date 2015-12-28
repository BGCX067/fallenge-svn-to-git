using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using FallenGE.Utility;
using FallenGE.Input;
using FallenGE.Math;
using FallenGE.Graphics;
using FallenGE.Audio;
using FallenGE.Win32;

namespace FallenGE.Game
{
    /// <summary>
    /// Represents a game.
    /// </summary>
    public class GameManager
    {
        protected GameWindow window;
        protected Utility.Timer timer;
        protected bool running;

        protected Engine engine;
        protected Context context;

        protected Screen currentScreen;
        protected List<KeyValuePair<string, Screen>> screenList;

        protected bool pause;

        /// <summary>
        /// Create a new game.
        /// </summary>
        public GameManager()
        {
            screenList = new List<KeyValuePair<string, Screen>>();
        }

        /// <summary>
        /// Run the game and begin the main loop.
        /// </summary>
        /// <param name="startScreen">The screen to show on startup.</param>
        public void Run(string startScreen)
        {
            float delta = 0.0f;

            Startup();

            running = true;
            timer = new  FallenGE.Utility.Timer();
            if (startScreen != "")
                ChangeScreen(startScreen);

            while (running == true)
            {
                timer.Start();

                running = Core.Update();
                engine.KeyboardManager.Capture();
                engine.GamepadManager.Capture();

                Render();
                Update(delta);

                timer.Stop();

                delta = timer.Delta;
                if (pause)
                    delta = 0;
            }

            if (currentScreen != null)
            {
                currentScreen.TransOut();
                currentScreen.Unload();
            }
            Shutdown();
        }

        /// <summary>
        /// Change from current screen to another.
        /// </summary>
        /// <param name="screen">The new screen.</param>
        public void ChangeScreen(string screen)
        {
            if (this.currentScreen != null)
            {
                this.currentScreen.TransOut();
                this.currentScreen.Unload();
            }

            this.currentScreen = GetScreen(screen);
            this.currentScreen.Load();
            this.currentScreen.TransIn();
        }

        /// <summary>
        /// Add a screen to screen list.
        /// </summary>
        /// <param name="name">Name of the screen.</param>
        /// <param name="screen">Screen to be added.</param>
        public void AddScreen(string name, Screen screen)
        {
            screenList.Add(new KeyValuePair<string, Screen>(name, screen));
        }

        /// <summary>
        /// Get a screen from the screen list.
        /// </summary>
        /// <param name="name">Name of the screen to get.</param>
        /// <returns>The screen if found.</returns>
        public Screen GetScreen(string name)
        {
            foreach (KeyValuePair<string, Screen> pair in screenList)
            {
                if (pair.Key == name)
                    return pair.Value;
            }

            return null;
        }

        /// <summary>
        /// Create the game engine.
        /// </summary>
        public void CreateEngine()
        {
            this.engine = new Engine
            (
            new Renderer(),
            new AudioPlayer(),
            new Mouse(),
            new Keyboard(),
            new GamepadManager()
            );
        }

        /// <summary>
        /// Destroy the game engine.
        /// </summary>
        public void DestroyEngine()
        {
            engine.AudioManager.Destroy();

            File_System.FileManager.Destroy();
        }

        /// <summary>
        /// Create a default context.
        /// </summary>
        /// <param name="title">Title of the context.</param>
        /// <param name="width">Width of the context.</param>
        /// <param name="height">Height of the context.</param>
        /// <param name="bitdepth">Bitdepth of the context.</param>
        /// <param name="fullscreen">True to go into fullscreen mode.</param>
        public void CreateContext(string title, int width, int height, int bitdepth, bool fullscreen)
        {
            window = new GameWindow(title, width, height, bitdepth, fullscreen);

            context = engine.RenderManager.AddContext(window);
        }

        /// <summary>
        /// Create a default game.
        /// </summary>
        /// <param name="title">Title of the game.</param>
        /// <param name="dataPath">Path to game data.</param>
        /// <param name="width">Width of the game window.</param>
        /// <param name="height">Height of the game window.</param>
        /// <param name="bitdepth">Bitdepth of the context.</param>
        /// <param name="fullscreen">True if the game is fullscreen.</param>
        public void CreateGame(string title, string dataPath, int width, int height, int bitdepth, bool fullscreen)
        {
            CreateContext(title, width, height, bitdepth, fullscreen);
            File_System.FileManager.Init(new string[] { dataPath });
        }

        /// <summary>
        /// Called when the game is started.
        /// </summary>
        public virtual void Startup() { }

        /// <summary>
        /// Called when the game is shutdown.
        /// </summary>
        public virtual void Shutdown() { }

        /// <summary>
        /// Called when the game is rendered.
        /// </summary>
        public virtual void Render() { }

        /// <summary>
        /// Called when the game is updated.
        /// </summary>
        /// <param name="delta">The delta time (think tweening).</param>
        public virtual void Update(float delta) { }

        /// <summary>
        /// Get the engine used by the game.
        /// </summary>
        public Engine Engine
        {
            get { return engine; }
        }
    }
}
