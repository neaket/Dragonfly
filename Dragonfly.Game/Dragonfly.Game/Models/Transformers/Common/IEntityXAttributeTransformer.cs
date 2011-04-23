using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.Common
{
    public interface IEntityXAttributeTransformer<E>
    {
        void ToEntity(XAttribute attribute, E entity);
        E ToEntity(XAttribute attribute);
        XAttribute ToXAttribute(E entity, string name);
    }
}
