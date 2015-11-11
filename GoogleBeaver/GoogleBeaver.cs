using BadgerAddin2010.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleBeaver
{
    public class GoogleBeaver : IBeaver
    {
        public string Name { get; set; }

        public GoogleBeaver()
        {
            Name = "Google";
        }
    }
}
