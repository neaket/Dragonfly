using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Indicle.Dragonfly.Engine.Levels;
using Indicle.Dragonfly.Engine.Renderer;
using Indicle.Dragonfly.Engine.ScreenManager;
using Indicle.Dragonfly.Models.Entities.Physics;
using Indicle.Dragonfly.Models.Entities.World;
using Indicle.Dragonfly.Models.Entities.WorldElements;
using Indicle.Dragonfly.Models.Transformers.World;
using Microsoft.Xna.Framework;
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

        public override void Draw(GameTimerEventArgs gameTime)
        {
            base.Draw(gameTime);
            
        }

        //public override void HandleInput(InputState input)
        //{
        //    base.HandleInput(input);
        //}


        public override void Update(GameTimerEventArgs gameTime)
        {
            base.Update(gameTime);
            TheCoolOne.Body.ApplyForce(new Vector2(1, 0));
        }
    }
}
