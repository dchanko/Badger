using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace BadgerAddin2010.Species
{
    public class HoneyBadger : Badger
    {
        public HoneyBadger(Outlook.Application pApplication)
            : base(pApplication, Constants.HoneyBadger, "Follow-ups/Badger/Honey", new TimeSpan(0, 5, 0, 0))
        {
            
        }
    }
}
