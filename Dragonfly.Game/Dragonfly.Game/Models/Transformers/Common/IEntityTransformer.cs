using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.Common
{
    class IEntityTransformer<E, O> 
    {

        void FromEntity(E entity, O xElement);
        void ToEntity(O xElement, E entity);
    }

    public interface IEntityXElementTransformer<E> : IEntityTransformer<E, XElement> { }
    public interface IEntityXAttributeTransformer<E> : IEntityTransformer<E, XAttribute> { } 
}
