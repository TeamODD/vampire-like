using Database;
using UnityEngine;
using UnityEngine.Events;
using VContainer;
using VContainer.Unity;

namespace Runtime.Domains.Locales
{
    public class LocalePresenter : IInitializable
    {
        [Inject] private readonly LocaleEntity _localeEntity;

        public void ChangeLanguage()
        {
            int type = ((int)_localeEntity.CurrentLanguage + 1) % 2;
            _localeEntity.CurrentLanguage = (LanguageType)type;
        }

        public void Initialize()
        {
            _localeEntity.OnLanguageChanged.AddListener(OnLanguageChanged.Invoke);
        }

        public string GetLocaleString(string key)
        {
            if (!DataRegistry.Locales.TryGetValue(key, out var locale))
            {
                return null;
            }
            
            switch (_localeEntity.CurrentLanguage)
            {
                case LanguageType.Korean:
                    return locale.Korean;
                case LanguageType.English:
                    return locale.English;
                default:
                    return null;
            }
        }

        public readonly UnityEvent OnLanguageChanged = new();
    }
}