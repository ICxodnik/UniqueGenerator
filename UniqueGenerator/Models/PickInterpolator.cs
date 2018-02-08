using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniqueGenerator.Models
{
    public class PickInterpolator : Interpolator
    {
        public PickInterpolator(string[] strings) : base(strings)
        {
        }

        public override string ToString()
        {
            return String.Join("", this.strings.OrderBy(x => random.Next()));
        }
    }
}