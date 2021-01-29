using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    [Serializable]
    public class WaffleException : Exception
    {
        public WaffleException()
            : this("<Invalid Topping>")
        { }

        public WaffleException(string topping)
            : base($"'{topping ?? throw new ArgumentNullException(nameof(topping))}' is not valid")
        { }

        public WaffleException(string topping, Exception innerException)
            : base($"'{topping ?? throw new ArgumentNullException(nameof(topping))}' is not valid", innerException)
        { }

        protected WaffleException(SerializationInfo info, StreamingContext context)
             : base(info, context)
        { }
    }
}
