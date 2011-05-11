using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Dragonfly.Models.Entities.World;
using Dragonfly.Models.Transformers.World;
using Dragonfly.Engine.Renderer;
using FarseerPhysics.Dynamics;
using System.Diagnostics;
using Dragonfly.Models.Entities.WorldElements;
using FarseerPhysics.Factories;
using Dragonfly.Engine.Generators;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Dragonfly.Engine.ScreenManager;

namespace Dragonfly.Engine.Levels
{
    class GameLevel : GameScreen
    {
        protected string _levelXml;
        protected WorldEntity _worldEntity;
        protected WorldRenderer _worldRenderer;
        protected World _world;
        protected Dictionary<string, Texture2D> _materials;
        protected TextureGenerator _textureGenerator;

#if DEBUG
        private WeakReference gcTest;
        private int gcCount = 0;
#endif

        public GameLevel(string levelXml, Dictionary<string, Texture2D> materials)
        {
            if (String.IsNullOrEmpty(levelXml))
            {
                throw new ArgumentException("levelXml cannot be null or empty");
            }
            _levelXml = levelXml;

            if (materials == null)
            {
                throw new ArgumentNullException("materials");
            }
            _materials = materials;            
        }

        public override void LoadContent()
        {
            base.LoadContent();

            XElement xElement = XElement.Load(_levelXml);
            var test = xElement.Elements();
            foreach (var t in test)
            {
                System.Console.WriteLine(t.Name);
            }

            _worldEntity = WorldTransformer.Instance.ToEntity(xElement);

            Debug.Assert(_worldEntity != null);

            _worldRenderer = new WorldRenderer(ScreenManager.GraphicsDevice, _worldEntity);
            _textureGenerator = new TextureGenerator(ScreenManager.GraphicsDevice, _materials);
            _world = new World(_worldEntity.PhysicsSettings.Gravity);


            foreach (var entity in _worldEntity.WorldElements)
            {
                entity.Texture2D = _textureGenerator.TextureFromWorldElement(entity);
                Body body;
                switch (entity.ElementType)
                {
                    case ElementType.Circle:
                        var circleEntity = entity as CircleElementEntity;
                        body = BodyFactory.CreateCircle(_world, circleEntity.Radius, circleEntity.Density);
                        break;
                    case ElementType.Elipsis:
                        var elipsisEntity = entity as ElipsisElementEntity;
                        body = BodyFactory.CreateEllipse(_world, elipsisEntity.Radius.X, elipsisEntity.Radius.Y, 8, elipsisEntity.Density);
                        break;
                    case ElementType.Polygon:
                        var polygonEntity = entity as PolygonElementEntity;
                        body = BodyFactory.CreatePolygon(_world, polygonEntity.Vertices, polygonEntity.Density);
                        break;
                    case ElementType.Rectangle:
                        var rectangleEntity = entity as RectangleElementEntity;
                        body = BodyFactory.CreateRectangle(_world, rectangleEntity.Width, rectangleEntity.Height, rectangleEntity.Density);
                        break;
                    default:
                        throw new NotSupportedException();
                }
                body.Position = entity.Position;
                body.BodyType = entity.BodyType;
                entity.Body = body;
            }
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

            _world.Clear();
            _world = null;
            _worldRenderer = null;
            _textureGenerator = null;
        }

        public override void HandleInput(InputState input)
        {
            base.HandleInput(input);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            #region garbage collection testing
#if DEBUG            
            if (gcTest == null)
            {
                gcTest = new WeakReference(new object());
            }
            if (!gcTest.IsAlive)
            {
                gcCount++;
                Debug.WriteLine(String.Format("Garbage has been collected {0} times.", gcCount));

                gcTest = new WeakReference(new object());
            }

            var g = (gameTime).ToString();
            g += "a";            
#endif
            #endregion

            if (!IsActive || otherScreenHasFocus || coveredByOtherScreen)
            {
                return;
            }

            _world.Step((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _worldRenderer.Draw(gameTime, ScreenManager.SpriteBatch);

            
        }
    }
}
