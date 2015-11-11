using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace BadgerAddin2010.Species
{
    public class EuropeanBadger : Badger
    {
        public EuropeanBadger(Outlook.Application pApplication)
            : base(pApplication, Constants.EuropeanBadger, "Follow-ups/Badger/European", new TimeSpan(3, 0, 0, 0))
        {
            
        }
    }
}
