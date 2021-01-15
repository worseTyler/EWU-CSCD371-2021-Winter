using System;

namespace Classroom
{
    public record Course
    {

        private string? _Name;
        public string Name
        {
            get
            {
                return _Name!;
            }
            set => _Name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string? Description { get; set; }

        public Course(string name)
        {
            Name = name;

            // Value types can also be null - but the complier checks, it is more than just intent.
            // int? number = null;
            // int number2 = (int)number!;

        }
    }
}
