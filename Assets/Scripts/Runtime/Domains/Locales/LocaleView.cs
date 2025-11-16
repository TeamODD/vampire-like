using UnityEngine;
using VContainer;

namespace Runtime.Domains.Locales
{
    public class LocaleView : MonoBehaviour
    {
        [Inject] private readonly LocalePresenter _localePresenter;

        public void ChangeLanguage()
        {
            _localePresenter.ChangeLanguage();
        }
    }
}