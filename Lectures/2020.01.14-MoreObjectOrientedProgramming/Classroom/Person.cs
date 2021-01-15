using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom
{
    public record Person(string FirstName, string LastName) { }

    public record Student(string FirstName, string LastName, int StudentId)
        : Person(FirstName, LastName)
    { }
}
