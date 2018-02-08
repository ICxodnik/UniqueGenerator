using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniqueGenerator.Models
{
    public class SampleInterpolator : Interpolator
    {
        public SampleInterpolator(string[] strings) : base(strings)
        {
        }

        public override string ToString()
        {
            return this.strings.ElementAt(random.Next(0, this.strings.Length));
        }

    }
}