using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selector
{
    internal class Student
    {
        public int Level;
        public string FirstName;
        public string LastName;

        public override string ToString()
        {
            return $"{Level} {FirstName} {LastName}";
        }
    }
}
