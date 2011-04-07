using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dragonfly.Models.Levels
{
    public interface IXmlContent : IXmlSerializable
    {
        XElement WriteToXElement();

        [XmlElement("XmlConent")]
        IXmlContent XmlContent { get; set; }
    }
}
