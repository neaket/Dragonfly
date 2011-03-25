using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Dragonfly.Models.Transformers.Common
{
    public interface IEntityXElementTransformer<T>
    {
        void EntityToXElement(T entity, XElement xElement);
        void XElementToEntity(XElement xElement, T entity);
    }
}
