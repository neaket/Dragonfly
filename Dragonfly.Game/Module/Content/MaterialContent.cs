using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Dragonfly.Module.Content
{
    class MaterialContent
    {
        public static Dictionary<string, Texture2D> Materials = new Dictionary<string, Texture2D>();

        public static void LoadContent(ContentManager contentManager, List<string> materialNames) 
        {
            foreach (var name in materialNames)
            {
                Materials[name] = contentManager.Load<Texture2D>("Materials/" + name);
            }
        
        }
    }
}
