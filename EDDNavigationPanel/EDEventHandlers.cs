using EDDNavigationPanel.Models;
using QuickJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static EDDDLLInterfaces.EDDDLLIF;

namespace EDDNavigationPanel
{
    public class EDEventHandlers
    {
        private delegate void EDEventHandler(UCNavigationPanel navPanel, JToken jData, JournalEntry journalEntry);

        #region public methods
        public void Invoke(string eventName, UCNavigationPanel navPanel, JToken jData, JournalEntry je)
        {
            GetHandler(eventName)?.Invoke(navPanel, jData, je);
        }
        #endregion public methods

        #region events
        private void OnDockedEvent(UCNavigationPanel navPanel, JToken jData, JournalEntry je)
        {
            var StationName = jData["StationName"].Str();
            var stationType = (StationType)Enum.Parse(typeof(StationType), jData["StationType"].Str());
            navPanel.LandingPads.Update(stationType, -1);
        }

        private void OnDockingGrantedEvent(UCNavigationPanel navPanel, JToken jData, JournalEntry je)
        {
            var StationName = jData["StationName"].Str();
            var padNumber = jData["LandingPad"].Int();
            var stationType = (StationType)Enum.Parse(typeof(StationType), jData["StationType"].Str());
            navPanel.LandingPads.Update(stationType, padNumber);
        }

        private void OnCommanderEvent(JToken jData, JournalEntry je)
        {
            Toolbox.Log($"Welcome CMDR {jData["Name"]}");
        }
        #endregion events

        #region private methods
        private EDEventHandler GetHandler(string handlerName)
        {
#warning todo : add delegate caching
            var method = GetType().GetMethod(handlerName, BindingFlags.NonPublic | BindingFlags.Instance);
            var methodDelegate = method?.CreateDelegate(typeof(EDEventHandler), this);
            return methodDelegate as EDEventHandler;
        }
        #endregion private methods
    }
}
