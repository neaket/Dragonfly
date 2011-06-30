using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indicle.Dragonfly.Models.Transformers.World;
using System.Xml.Linq;
using Indicle.Dragonfly.Models.Entities.World;
using FarseerPhysics.Dynamics;
using Indicle.Dragonfly.Models.Entities.WorldElements;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Indicle.Dragonfly.Engine.Renderer;
using System.Diagnostics;
using Indicle.Dragonfly.Engine.ScreenManager;
using Indicle.Dragonfly.Models.Entities.Physics;
using Indicle.Dragonfly.Engine.Levels;
using Microsoft.Xna.Framework.Graphics;

namespace Indicle.Dragonfly.Module.Levels
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
