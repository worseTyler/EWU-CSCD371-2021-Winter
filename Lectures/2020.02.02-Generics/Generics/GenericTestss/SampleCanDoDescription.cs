using Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTestss
{
    class SampleCanDoDescription : IDescription
    {
        public string Description => typeof(SampleCanDoDescription).ToString();
    }
}
