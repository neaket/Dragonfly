using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dragonfly.Models.Transformers.World;
using System.Xml.Linq;
using Dragonfly.Models.Entities.World;
using FarseerPhysics.Dynamics;
using Dragonfly.Models.Entities.WorldElements;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Dragonfly.Engine.Renderer;
using System.Diagnostics;
using Dragonfly.Engine.ScreenManager;
using Dragonfly.Models.Entities.Physics;
using Dragonfly.Engine.Levels;
using Microsoft.Xna.Framework.Graphics;

namespace Dragonfly.Module.Levels
{
    class TestLevel1 : GameLevel
    {

        public World World;
        protected WorldEntity _WorldEntity;
        public float TimeLeftOver;

        private RectangleElementEntity TheCoolOne;

        protected WorldRenderer _WorldRenderer;

        public TestLevel1(Dictionary<string, Texture2D> materials) 
            : base("Content/Levels/TestLevel1.xml", materials)
        {
            

        }

        public override void LoadContent()
        {
            base.LoadContent();

            TheCoolOne = WorldElements["The Cool One"] as RectangleElementEntity;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            
        }

        public override void HandleInput(InputState input)
        {
            base.HandleInput(input);
        }


        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
            TheCoolOne.Body.ApplyForce(new Vector2(1, 0));
        }
    }
}
