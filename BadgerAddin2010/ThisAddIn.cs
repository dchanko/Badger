using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.Diagnostics;

namespace BadgerAddin2010
{
    public partial class ThisAddIn
    {
        System.Timers.Timer mBadgerAlarm;
        List<Species.Badger> Badgers;

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new Ribbon();
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.NewMailEx += Application_NewMailEx;
            Application.ItemSend += Application_ItemSend;

            Badgers = new List<Species.Badger>
            {
                new Species.EuropeanBadger(Application),
                new Species.AmericanBadger(Application),
                new Species.HoneyBadger(Application)
            };

            // Wake up the badgers every five minutes.
            mBadgerAlarm = new System.Timers.Timer(300000);
            mBadgerAlarm.AutoReset = true;
            mBadgerAlarm.Elapsed += mBadgerAlarm_Elapsed;

            // Badgers don't wait. That's the point.
            foreach(Outlook.MailItem item in Util.GetInbox(Application).Items)
            {
                Application_NewMailEx(item.EntryID);
            }
          
            mBadgerAlarm.Start();
        }

        /// <summary>
        /// Handler to give the badgers a chance to examine outgoing mail.
        /// It is important that this handler be non-blocking or else the add-in
        /// will not handle multiple events.
        /// </summary>
        /// <param name="i">The item sent.</param>
        private void Application_ItemSend(object i, ref bool Cancel)
        {
            var item = i as Outlook.MailItem;

            if (item != null)
            {
                try
                {
                    if (item.BCC.Contains(item.SendUsingAccount.CurrentUser.Name))
                    {
                        item = item.Copy();
                        item.UnRead = true;
                        var badgerPrompt = new UI.BadgerPrompt(new Action<int>(
                            species => 
                            {
                                var badger = Badgers.FirstOrDefault(b => b.IsSpecies(species));
                                if (null != badger)
                                    badger.Assign(item);
                                else
                                    item.Move(Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDeletedItems));
                            }));
                        // It is important that this is non-blocking
                        // or else the add-in will not handle multiple requests.
                        badgerPrompt.Show();
                    }
                }
                catch
                {
                    // Honey badgers ate this part of the code.
                }
            }
        }

        /// <summary>
        /// Periodically have the badgers examine items pending response to see if followup is necessary.
        /// </summary>
        private void mBadgerAlarm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Badgers.ForEach(b => b.BadgerVictim());
        }

        /// <summary>
        /// Handler to let the badgers take a look at incoming mail to see if it answers
        /// one of the items pending followup.
        /// </summary>
        /// <param name="pEntryID">The EntryId of the incoming mail item.</param>
        private void Application_NewMailEx(string pEntryID)
        {
            var item = Application.Session.GetItemFromID(pEntryID);
            if (item == null) return;
            
            Badgers.ForEach(b => b.HandleIncomingMail(item));
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
