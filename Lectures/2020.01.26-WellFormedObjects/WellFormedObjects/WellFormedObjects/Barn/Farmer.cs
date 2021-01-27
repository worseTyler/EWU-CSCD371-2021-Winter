using System;

namespace WellFormedObjects.Barn
{
    public class Farmer
    {
        private Lazy<Farmer> _CleanMeUp = new(() => new Farmer());

        public static Farmer DaleSimple { get; } = new();

        private static Lazy<Farmer> _Dale = new(() => new Farmer());
        public static Farmer Dale
        {
            get
            {
                /*
                if (_Dale is null)
                {
                    _Dale = new Farmer();
                }
                return _Dale;
                */
                return _Dale.Value;
            }
        }

        public void Disposing()
        {
            if (_CleanMeUp.IsValueCreated)
            {
                _CleanMeUp.Value.Disposing();
            }
        }

        public Pony MyPony { get; }
    }
}
