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

namespace Dragonfly.DragonflyGame.Levels
{
    class TestLevel1
    {
        public World World;
        WorldEntity WorldEntity;
        public float TimeLeftOver;

        public TestLevel1()
        {
            XElement xElement = XElement.Load("TestLevel1.xml");
            WorldEntity WorldEntity = WorldTransformer.Instance.ToEntity(xElement);

            World = new World(WorldEntity.PhysicsSettings.Gravity);

            foreach (var entity in WorldEntity.WorldElements)
            {
                Body body;
                switch (entity.ElementType)
                {
                    case ElementType.Circle:
                        var circleEntity = entity as CircleElementEntity;
                        body = BodyFactory.CreateCircle(World, circleEntity.Radius, circleEntity.Density);
                        break;
                    case ElementType.Elipsis:
                        var elipsisEntity = entity as ElipsisElementEntity;
                        body = BodyFactory.CreateEllipse(World, elipsisEntity.Radius.X, elipsisEntity.Radius.Y, 8, elipsisEntity.Density);
                        break;
                    case ElementType.Polygon:
                        var polygonEntity = entity as PolygonElementEntity;
                        body = BodyFactory.CreatePolygon(World, polygonEntity.Vertices, polygonEntity.Density);
                        break;
                    case ElementType.Rectangle:
                    default:
                        var rectangleEntity = entity as RectangleElementEntity;
                        body = BodyFactory.CreateRectangle(World, rectangleEntity.Size.X, rectangleEntity.Size.Y, rectangleEntity.Density);
                        break;
                }
                body.Position = entity.Positon;
                entity.Body = body;
            }
        }

        public void Draw(GameTime gameTime)
        {
            
        }


        public void Update(GameTime gameTime)
        {
            World.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
