using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Xml.Linq;
using Dragonfly.Models.Transformers.Common;
using Microsoft.Xna.Framework;

namespace Dragonfly.Tests.Tests.Models.Common
{
    [TestFixture]
    class ColorTests
    {
        [Test]
        public void TestAlphaColorConvert()
        {
            XAttribute xAttribute = new XAttribute("test_color", "#01020304");

            Color color = ColorTransformer.Instance.ToEntity(xAttribute);

            Assert.AreEqual(1, color.A);
            Assert.AreEqual(2, color.R);
            Assert.AreEqual(3, color.G);
            Assert.AreEqual(4, color.B);
        }

        [Test]
        public void TestAlphaColorToStringConvert()
        {
            Color color = new Color(2, 3, 4, 1);

            XAttribute xAttribute = ColorTransformer.Instance.ToXAttribute(color, "test_color");

            Assert.AreEqual("#01020304", xAttribute.Value);
        }
        
    }
}
