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
using Dragonfly.Models.Transformers.Common;

namespace Dragonfly.Tests.Models
{
    [TestFixture]
    public class WorldTests
    {
        [Test]
        public void ValidateSave()
        {
            WorldEntity world = createTestWorld();

            XElement xElement = WorldTransformer.Instance.ToXElement(world, TransformerSettings.WorldNamespace + "World");
            
         

            xElement.Save("unittestsave.xml", SaveOptions.OmitDuplicateNamespaces);

            XmlSchemaSet schemaSet = new XmlSchemaSet();

            schemaSet.Add(null, "WorldSchema1.xsd");

            XDocument xDocument = new XDocument(xElement);
            xDocument.AddAnnotation(SaveOptions.OmitDuplicateNamespaces);
            xDocument.Save("unittest2.xml", SaveOptions.OmitDuplicateNamespaces);

            XElement x1 = new XElement(TransformerSettings.WorldNamespace + "Outer");
            x1.Add(new XElement(TransformerSettings.WorldNamespace + "Inner"));
            x1.Save("unittest3.xml", SaveOptions.OmitDuplicateNamespaces);
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

        [Test]
        public void LoadTestLevel()
        {
            //var level = XDocument.Load("TestResources\\TestLevel1.xml");
            //foreach (var e in level.Elements())
            //{
            //    System.Console.WriteLine(e.Name);
            //}

            //XNamespace nsc = "http://eaket.com/games/dragonfly/WorldSchema1";
            //var test = nsc + WorldInfoTransformer.STR_Name;
            //Assert.IsNotNull(level.Element(nsc + WorldInfoTransformer.STR_WorldInfo));
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