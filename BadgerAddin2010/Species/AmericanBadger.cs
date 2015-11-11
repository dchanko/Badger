using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace BadgerAddin2010.Species
{
    public class AmericanBadger : Badger
    {
        public AmericanBadger(Outlook.Application pApplication)
            : base(pApplication, Constants.AmericanBadger, "Follow-ups/Badger/American", new TimeSpan(0, 24, 0, 0))
        {
            
        }
    }
}
