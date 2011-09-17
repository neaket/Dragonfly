using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Indicle.Dragonfly.Models.Transformers.Common
{
    public interface IEntityXElementTransformer<E> 
    {
        void ToXElement(E entity, XElement xElement);

        void ToEntity(XElement xElement, E entity);
    }

}
