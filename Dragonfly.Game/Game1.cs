using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Dragonfly.Engine.ScreenManager;
using Dragonfly.Module.Screens;

namespace Dragonfly.Module
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        ScreenController screenController;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            
#if WINDOWS_PHONE            
            graphics.IsFullScreen = true;
#endif
            screenController = new ScreenController(this);

            Components.Add(screenController);

            screenController.AddScreen(new BackgroundScreen(), null);
            screenController.AddScreen(new MainMenuScreen(), null);
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
#if WINDOWS_PHONE
            screenController.SerializeState();
#endif

            base.OnExiting(sender, args);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }
    }
}
