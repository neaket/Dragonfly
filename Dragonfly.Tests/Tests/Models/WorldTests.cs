using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Schema;
using Dragonfly.Models.Entities.Physics;
using Dragonfly.Models.Entities.World;
using Dragonfly.Models.Transformers.World;
using Microsoft.Xna.Framework;
using NUnit.Framework;
using Dragonfly.Models.Entities.WorldElements;

namespace Dragonfly.Tests.Models
{
    [TestFixture]
    public class WorldTests
    {
        [Test]
        public void ValidateSave()
        {
            WorldEntity world = createTestWorld();

            XElement xElement = WorldTransformer.Instance.ToXElement(world, "World");
            
         

            xElement.Save("unittestsave.xml");

            XmlSchemaSet schemaSet = new XmlSchemaSet();

            schemaSet.Add(null, "WorldSchema1.xsd");

            XDocument xDocument = new XDocument(xElement);


            string val = "";
            xDocument.Validate(schemaSet, (o, vea) => {
                val += o.GetType().Name + "\n";
                val += vea.Message + "\n";
            }, true);

            Assert.AreEqual("", val);
            
        }

        [Test]
        public void SaveAndLoad()
        {
            WorldEntity world = createTestWorld();

            XElement xElement = WorldTransformer.Instance.ToXElement(world, "World");

            WorldEntity world2 = WorldTransformer.Instance.ToEntity(xElement);
           
 
           
        }

        private WorldEntity createTestWorld()
        {
            WorldEntity world = new WorldEntity();

            world.WorldInfo = new WorldInfoEntity();
            world.WorldInfo.Language = "en";
            world.WorldInfo.Name = "UnitTestLevel";
            world.WorldInfo.Description = "Test \n \"Description";

            world.PhysicsSettings = new PhysicsSettingsEntity();
            world.PhysicsSettings.Gravity = Vector2.Zero;

            RectangleElementEntity rectangle = new RectangleElementEntity();
            rectangle.Color = Color.Wheat;
            rectangle.Positon = new Vector2(5, 5);
            rectangle.Size = new Vector2(5, 5);

            world.WorldElements.Add(rectangle);

            return world;
        }
    }
}