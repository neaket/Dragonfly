using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Indicle.Dragonfly.Models.Entities.World;
using Indicle.Dragonfly.Models.Transformers.World;
using Indicle.Dragonfly.Engine.Renderer;
using FarseerPhysics.Dynamics;
using System.Diagnostics;
using Indicle.Dragonfly.Models.Entities.WorldElements;
using FarseerPhysics.Factories;
using Indicle.Dragonfly.Engine.Generators;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Indicle.Dragonfly.Engine.ScreenManager;

namespace Indicle.Dragonfly.Engine.Levels
{
    class GameLevel : GameScreen
    {
        protected string _levelXml;
        protected WorldEntity _worldEntity;
        protected WorldRenderer _worldRenderer;
        protected World _world;
        protected Dictionary<string, Texture2D> _materials;
        protected TextureGenerator _textureGenerator;
        protected Dictionary<string, IWorldElementEntity> WorldElements;


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

            WorldElements = new Dictionary<string, IWorldElementEntity>(_worldEntity.WorldElements.Count);
            foreach (var entity in _worldEntity.WorldElements)
            {

                if (entity is PhysicsWorldElementEntity)
                {
                    PhysicsWorldElementEntity physicsEntity = entity as PhysicsWorldElementEntity;
                    physicsEntity.Texture2D = _textureGenerator.TextureFromWorldElement(physicsEntity);
                    Body body;
                    switch (physicsEntity.ElementType)
                    {
                        case ElementType.Circle:
                            var circleEntity = physicsEntity as CircleElementEntity;
                            body = BodyFactory.CreateCircle(_world, circleEntity.Radius, circleEntity.Density, physicsEntity.Position);
                            break;
                        case ElementType.Elipsis:
                            var elipsisEntity = physicsEntity as ElipsisElementEntity;
                            body = BodyFactory.CreateEllipse(_world, elipsisEntity.Radius.X, elipsisEntity.Radius.Y, 8, elipsisEntity.Density, physicsEntity.Position);
                            break;
                        case ElementType.Polygon:
                            var polygonEntity = physicsEntity as PolygonElementEntity;
                            body = BodyFactory.CreatePolygon(_world, polygonEntity.Vertices, polygonEntity.Density, physicsEntity.Position);
                            break;
                        case ElementType.Rectangle:
                            var rectangleEntity = physicsEntity as RectangleElementEntity;
                            body = BodyFactory.CreateRectangle(_world, rectangleEntity.Width, rectangleEntity.Height, rectangleEntity.Density, physicsEntity.Position);
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                    body.BodyType = physicsEntity.BodyType;
                    //body.Position = physicsEntity.Position;
                    body.Rotation = physicsEntity.Rotation;
                    
                    //body.Inertia = 0.1f;
                    physicsEntity.Body = body;

                    if (physicsEntity.Name != null)
                    {
                        //TODO prevent duplicate names... or something else
                        WorldElements.Add(physicsEntity.Name, physicsEntity);
                    }
                }
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
