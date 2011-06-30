using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indicle.Dragonfly.Models.Entities.WorldElements;
using System.Xml.Linq;

namespace Indicle.Dragonfly.Models.Transformers.WorldElements
{
    public interface IWorldElementTransformer
    {
        string EntityName { get; }
        Type Type { get; }
        IWorldElementEntity ToWorldElementEntity(XElement xElement);
        XElement FromWorldElementEntity(IWorldElementEntity entity);
    }
}
