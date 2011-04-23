using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.Common
{
    public abstract class EntityXElementTransformer<T> : IEntityXElementTransformer<T> where T : new()
    {
        public abstract void ToXElement(T entity, XElement xElement);

        public XElement ToXElement(T entity, string elementName)
        {
            XElement xElement = new XElement(elementName);

            ToXElement(entity, xElement);

            return xElement;
        }


        public abstract void ToEntity(XElement xElement, T entity);

        public T ToEntity(XElement xElement)
        {
            T entity = new T();

            ToEntity(xElement, entity);

            return entity;
        }


   
    }
}
