using System;
using System.Collections.Generic;
using System.Text;
using static Csharp_learn.接口;

namespace Csharp_learn
{
    public class 接口 : IEquatable<接口>
    {

        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Year { get; set; }

        // Implementation of IEquatable<T> interface
        public bool Equals(接口? car)
        {
            return (this.Make, this.Model, this.Year) ==
                (car?.Make, car?.Model, car?.Year);
        }

    }
}
