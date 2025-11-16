using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Domains.Codices
{
    public class CodexPresenter
    {
        private string _codexID;

        public string CodexID
        {
            get => _codexID;
            set
            {
                _codexID = value;
                OnCodexIDChanged.Invoke(_codexID);
            }
        }
        public readonly UnityEvent<string> OnCodexIDChanged = new();
    }
}