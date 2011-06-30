using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Indicle.Dragonfly.Models.Transformers.Common
{
    public abstract class EntityXAttributeTransformer<E> : IEntityXAttributeTransformer<E> where E : new()
    {
        public abstract void ToEntity(XAttribute attribute, E entity);

        public E ToEntity(XAttribute xElement)
        {
            E entity = new E();

            ToEntity(xElement, entity);

            return entity;
        }

        public abstract XAttribute ToXAttribute(E entity, XName name);

    }
}
