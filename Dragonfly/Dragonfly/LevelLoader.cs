using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;
using System.IO;
using Dragonfly.Models.Levels;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Dragonfly
{
    class LevelLoader
    {
        public class LevelDirectory {
            
        }

        public static void SaveLevel()
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("1234.lev", FileMode.Create, isf))
                {
                    LevelModel level = new LevelModel();
                    //level.Save(stream);

                }
            }
        }

        public static void LoadLevel()
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("1234.lev", FileMode.Open, isf))
                {
                    if (stream.Length > 10240)
                    {
                        throw new ArgumentOutOfRangeException("The file specified is too large");
                    }

                    XDocument document = XDocument.Load(stream);
                    

                     
                   

                }
            }
        }
    }
}
