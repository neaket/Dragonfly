using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Dragonfly.Module.Content
{
    static class MenuResources
    {
        private static string SubDir = @"menu\";
        public static SpriteFont MenuFont { get; private set; }

        public static void LoadContent(ContentManager content)
        {            
            MenuFont = content.Load<SpriteFont>(SubDir + "menufont");
        }

        public static void UnloadContent()
        {
            MenuFont = null;
        }
    }
}
