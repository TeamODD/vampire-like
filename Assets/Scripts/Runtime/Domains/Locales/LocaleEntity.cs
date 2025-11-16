using System;
using UnityEngine.Events;

namespace Runtime.Domains.Locales
{
    [Serializable]
    public class LocaleEntity
    {
        private LanguageType _currentLanguage;

        public LanguageType CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                _currentLanguage = value;
                OnLanguageChanged?.Invoke();
            }
        }
        
        public readonly UnityEvent OnLanguageChanged = new();
    }
}