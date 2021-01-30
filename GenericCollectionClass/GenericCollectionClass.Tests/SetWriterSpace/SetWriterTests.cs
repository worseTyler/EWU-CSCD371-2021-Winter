using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericCollectionClass.SetWriterSpace;

namespace GenericCollectionClass.Tests.SetWriterSpace
{
    [TestClass]
    public class SetWriterTests
    {
        [TestMethod]
        public void Create_GivenValidFilePath_CreateSetWriter()
        {
            string filePath = Path.GetTempFileName();
        }
    }
}
