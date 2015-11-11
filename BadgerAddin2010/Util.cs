using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace BadgerAddin2010
{
    /// <summary>
    /// Utility functions for dealing with Outlook.
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Get the Inbox folder for the provided Aplication.
        /// </summary>
        /// <param name="pApplication">The current Outlook application.</param>
        /// <returns>The default Inbox folder for the application.</returns>
        public static Outlook.MAPIFolder GetInbox(Outlook.Application pApplication)
        {
            return pApplication.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
        }

        /// <summary>
        /// Get the Sent folder for the provided Application.
        /// </summary>
        /// <param name="pApplication">The current Outlook application.</param>
        /// <returns>The default Sent folder for the application.</returns>
        public static Outlook.MAPIFolder GetSent(Outlook.Application pApplication)
        {
            return pApplication.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail);
        }
        
        /// <summary>
        /// Given an Outlook application and a path representing a folder, ensure the folder exists.
        /// </summary>
        /// <param name="pApplication">The current Outlook application.</param>
        /// <param name="pPath">A folder path, separated by '/' or '\'.</param>
        /// <returns>The folder represented by the path.</returns>
        public static Outlook.MAPIFolder InitializeMailFolder(Outlook.Application pApplication, string pPath)
        {
            return InitializeMailFolder(pApplication,
                pPath.Split('/', '\\').Where(p => p.Length > 0).ToArray());
        }

        /// <summary>
        /// Given an Outlook application and a string array representing a folder path, ensure the folder exists.
        /// </summary>
        /// <param name="pApplication">The current Outlook application.</param>
        /// <param name="pPath">A string array representing the folder path.</param>
        /// <returns>The folder represented by the path.</returns>
        public static Outlook.MAPIFolder InitializeMailFolder(Outlook.Application pApplication, params string[] pPath)
        {
            Outlook.MAPIFolder temp = GetInbox(pApplication).Parent;

            foreach(string p in pPath)
            {
                try
                {
                    temp = temp.Folders[p];
                }
                catch
                {
                    temp = temp.Folders.Add(p);
                }
            }

            return temp;
        }

        /// <summary>
        /// Given a mail item that is part of a conversation, get the last sent mail item in the conversation.
        /// </summary>
        /// <param name="pMailItem">The mail item.</param>
        /// <returns>The last sent mail item in the given mail item's conversation, or the mail item.</returns>
        public static Outlook.MailItem GetLastSentMessageInConversationForMessage(Outlook.MailItem pMailItem)
        {
            var folder = pMailItem.Parent as Outlook.Folder;
            var store = folder.Store;

            if (store.IsConversationEnabled)
            {
                Outlook.Conversation conv = pMailItem.GetConversation();
                if (conv != null)
                {                  
                    var table = conv.GetTable();
                    table.Sort("SentOn", true);
                    table.MoveToStart();

                    if (!table.EndOfTable)
                    {
                        var firstRow = table.GetNextRow();
                        return pMailItem.Application.Session.GetItemFromID(firstRow["EntryID"]);
                    }
                }
            }

            return pMailItem;
        }
    }
}
