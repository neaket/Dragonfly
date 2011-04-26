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

namespace Dragonfly.Module.Levels
{
    class TestLevel1 : GameScreen
    {
        public World World;
        protected WorldEntity _WorldEntity;
        public float TimeLeftOver;

        protected WorldRenderer _WorldRenderer;

        public TestLevel1()
        {
            XElement xElement = XElement.Load(@"Content\Levels\TestLevel1.xml");
            var test =             xElement.Elements();
            foreach (var t in test)
            {
                System.Console.WriteLine(t.Name);
            }

            _WorldEntity = WorldTransformer.Instance.ToEntity(xElement);

            Debug.Assert(_WorldEntity != null);

            _WorldRenderer = new WorldRenderer(_WorldEntity);

            World = new World(_WorldEntity.PhysicsSettings.Gravity);


            foreach (var entity in _WorldEntity.WorldElements)
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

        public override void Draw(GameTime gameTime)
        {
            _WorldRenderer.Draw(gameTime);
            
        }


        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            if (IsActive)
            {
                World.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }
    }
}
