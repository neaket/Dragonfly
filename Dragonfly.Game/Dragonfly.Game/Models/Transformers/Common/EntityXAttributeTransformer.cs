using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.Common
{
    abstract class EntityXAttributeTransformer<T> : IEntityXElementTransformer<T> where T : new()
    {
        public abstract void FromEntity(T entity, XElement xElement);

        public XElement FromEntity(T entity, string name)
        {
            throw new NotImplementedException();
            //XElement xElement = new XElement(name, entity.ToString);

            //FromEntity(entity, xElement);

            //return xElement;
        }


        public abstract void XElementToEntity(XElement xElement, T entity);

        public T ToEntity(XElement xElement)
        {
            T entity = new T();

            XElementToEntity(xElement, entity);

            return entity;
        }
    }
}
