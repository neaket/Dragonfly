using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.Common
{
    abstract class EntityXElementTransformer<T> : IEntityXElementTransformer<T> where T : new()
    {
        public abstract void EntityToXElement(T entity, XElement xElement);

        public XElement EntityToXElement(T entity, string elementName)
        {
            XElement xElement = new XElement(elementName);

            EntityToXElement(entity, xElement);

            return xElement;
        }


        public abstract void XElementToEntity(XElement xElement, T entity);

        public T XElementToEntity(XElement xElement)
        {
            T entity = new T();

            XElementToEntity(xElement, entity);

            return entity;
        }
    }
}
