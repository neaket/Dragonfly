using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Indicle.Dragonfly.Models.Levels
{
    
    [XmlRootAttribute(ElementName = LevelConstants.DocumentNode, IsNullable = false)]
    public class LevelModel
    {
        [XmlArray(LevelConstants.GameElementsNode)]
        public List<IXmlContent> GameElements = new List<IXmlContent>();

        public XDocument CreateDocument()
        {
            XDocument document = new XDocument();

            
            document.Declaration = new XDeclaration("1.0", "UTF-8", null);

            XElement level = new XElement(LevelConstants.DocumentNode);
            document.Add(level);

            XElement gameElements = new XElement(LevelConstants.GameElementsNode);
            level.Add(gameElements);

            foreach (var element in GameElements)
            {
                gameElements.Add(element.WriteToXElement());
            }
            return document;
        }



        
    }
}
