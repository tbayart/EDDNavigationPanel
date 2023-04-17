using EDDNavigationPanel.Models;
using EDDNavigationPanel.ViewModels;
using QuickJSON;
using System;
using System.Reflection;
using System.Runtime.Caching;
using static EDDDLLInterfaces.EDDDLLIF;

namespace EDDNavigationPanel
{
    public class EDEventHandlers
    {
        private delegate void EDEventHandler(UCNavigationPanel navPanel, JToken jData, JournalEntry journalEntry);
        private readonly MemoryCache _caching;

        #region ctor
        public EDEventHandlers()
        {
            _caching = new MemoryCache("EDEventHandlers");
        }
        #endregion ctor

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
            ViewModelManager.SwitchTo<LandingPadsViewModel>()
                .SelectedPad(stationType, -1);
        }

        private void OnDockingGrantedEvent(UCNavigationPanel navPanel, JToken jData, JournalEntry je)
        {
            var StationName = jData["StationName"].Str();
            var padNumber = jData["LandingPad"].Int();
            var stationType = (StationType)Enum.Parse(typeof(StationType), jData["StationType"].Str());
            ViewModelManager.SwitchTo<LandingPadsViewModel>()
                .SelectedPad(stationType, padNumber);
        }

        private void OnCommanderEvent(JToken jData, JournalEntry je)
        {
            Toolbox.Log($"Welcome CMDR {jData["Name"]}");
        }
        #endregion events

        #region private methods
        private EDEventHandler GetHandler(string handlerName)
        {
            if (_caching.Get(handlerName) is not EDEventHandler handler)
            {
                var method = GetType().GetMethod(handlerName, BindingFlags.NonPublic | BindingFlags.Instance);
                handler = method?.CreateDelegate(typeof(EDEventHandler), this) as EDEventHandler;
                _caching[handlerName] = handler;
            }
            return handler;
        }
        #endregion private methods
    }
}
