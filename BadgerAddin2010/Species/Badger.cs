using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace BadgerAddin2010.Species
{
    public class Badger
    {
        private Outlook.MAPIFolder mBadgerFolder;

        public string FolderPath { get; set; }
        public TimeSpan Interval { get; set; }
        public int BadgerSpecies { get; set; }

        public Badger(
            Outlook.Application pApplication, 
            int pSpecies,
            string pFolderPath, 
            TimeSpan pInterval)
        {
            mBadgerFolder = Util.InitializeMailFolder(pApplication, pFolderPath);
            BadgerSpecies = pSpecies;
            Interval = pInterval;
        }

        public bool IsSpecies(int pSpecies)
        {
            return BadgerSpecies == pSpecies;
        }

        public virtual void HandleIncomingMail(Outlook.MailItem pMail)
        {
            foreach (object m in mBadgerFolder.Items)
            {
                var message = m as Outlook.MailItem;

                if (null != message)
                {
                    if (pMail.Subject.Contains(message.Subject)
                        && message.To.Contains(pMail.SenderName))
                    {
                        // We have a response from someone on the TO list.
                        // A.K.A. Another badger angel gets its wings.
                        message.UnRead = false;
                        message.Delete();
                    }
                }
            }
        }

        public virtual void BadgerVictim()
        {
            foreach (object m in mBadgerFolder.Items)
            {
                var message = m as Outlook.MailItem;

                if (null == message) continue;

                message = Util.GetLastSentMessageInConversationForMessage(message);

                if (DateTime.Now.Subtract(message.SentOn) > Interval)
                {
                    Outlook.MailItem reply;

                    if (message.Body.StartsWith(Constants.PoliteReminder))
                    {
                        reply = message.Copy();
                    }
                    else
                    {
                        reply = message.Reply();
                        if (reply.BodyFormat == Outlook.OlBodyFormat.olFormatHTML)
                        {
                            var pos = reply.HTMLBody.IndexOf("<o:p>");
                            reply.HTMLBody = reply.HTMLBody.Insert(pos, Constants.PoliteReminder);
                        }
                        else
                            reply.Body = Constants.PoliteReminder + reply.Body;
                    }
                    reply.To = message.To;
                    reply.CC = String.Empty;
                    reply.BCC = String.Empty;
                    reply.Send();
                }
            }
        }

        public virtual void Assign(Outlook.MailItem pItem)
        {
            pItem.Move(mBadgerFolder);
        }

    }
}
