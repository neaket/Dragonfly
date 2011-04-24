using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Dragonfly.Models.Transformers.World;
using System.Xml.Linq;
using Dragonfly.Models.Entities.WorldElements;
using FarseerPhysics.Factories;

namespace Dragonfly.Module.Levels
{
    class Level1
    {
        protected World World = null;

        protected Level1()
        {

        }

        public void LoadContent()
        {
            if (World == null)
            {
                World = new World(Vector2.Zero);
            }
            else
            {
                World.Clear();
            }

            var lev = XElement.Load("level1.xml");

            var worldEntity = WorldTransformer.Instance.ToEntity(lev);
            

            //load physics settings
            World.Gravity = worldEntity.PhysicsSettings.Gravity;

            foreach (WorldElementEntity worldElement in worldEntity.WorldElements) 
            {
                Body body;
                if (worldElement is RectangleElementEntity)
                {
                    var rect = worldElement as RectangleElementEntity;                    
                    body = BodyFactory.CreateRectangle(World, rect.Size.X, rect.Size.Y, 1.0f);
                    
                    
                }
                else if (worldElement is CircleElementEntity)
                {
                    var circle = worldElement as CircleElementEntity;
                    body = BodyFactory.CreateCircle(World, circle.Radius, 1.0f);
                }
                else
                {
                    throw new Exception(String.Format("World Element of type '{0}' not supported ", worldElement.GetType()));
                }

                body.Position = worldElement.Positon;


            }
            

            // force a garbage collect
            GC.Collect();
        }

        public void UnloadContent()
        {

        }

    }
}
