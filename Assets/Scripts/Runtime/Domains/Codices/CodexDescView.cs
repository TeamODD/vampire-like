using System;
using Database;
using Runtime.Domains.Locales;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using VContainer;

namespace Runtime.Domains.Codices
{
    public class CodexDescView : MonoBehaviour
    {
        [Inject] private LocalePresenter _localePresenter;
        [Inject] private CodexPresenter _codexPresenter;
        [field: SerializeField] private TMP_Text _descriptionText;
        [field: SerializeField] private string _descKey;

        private void Start()
        {
            _codexPresenter.OnCodexIDChanged.AddListener(SetDescription);
            _localePresenter.OnLanguageChanged.AddListener(Refresh);
        }
        
        [Button]
        private void SetDescription(string codexID)
        {
            _descKey = DataRegistry.MonsterBases[codexID].DescKey;
            _descriptionText.text = _localePresenter.GetLocaleString(_descKey);
        }

        private void Refresh()
        {
            _descriptionText.text = _localePresenter.GetLocaleString(_descKey);
        }
    }
}