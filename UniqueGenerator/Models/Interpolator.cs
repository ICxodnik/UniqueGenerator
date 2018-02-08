using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniqueGenerator.Models
{
    public abstract class Interpolator
    {
        protected string[] strings;
        protected Random random = new Random(Environment.TickCount);
        public Interpolator(string[] strings)
        {
            this.strings = strings;
        }


    }
}