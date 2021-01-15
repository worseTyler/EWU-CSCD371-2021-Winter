using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    public class SampleThing
    {

        public string NonVirtualMethod() =>
            $"{nameof(SampleThing)}: {Name}";

        public virtual string VirtualMethod() =>
            $"{nameof(SampleThing)}: {Name}";

        public SampleThing(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    public class SpecialSampleThing : SampleThing
    {
        public new string NonVirtualMethod() => 
            $"{nameof(SpecialSampleThing)}: {Name}";

        public override string VirtualMethod() =>
            $"{nameof(SpecialSampleThing)}: {Name}";

        public SpecialSampleThing(string name, string? text = null)
            :base(name)
        {
            Text = text;
        }

        public string? Text { get; set; }
    }



}
