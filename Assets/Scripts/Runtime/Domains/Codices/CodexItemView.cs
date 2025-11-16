using System;
using Database;
using Runtime.Domains.Locales;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Runtime.Domains.Codices
{
    [RequireComponent(typeof(Button))]
    public class CodexItemView : MonoBehaviour
    {
        [field: SerializeField] private TMP_Text _nameText;
        [field: SerializeField] private string _monsterID;
        [field: SerializeField] private string _nameKey;
        [Inject] private LocalePresenter _localePresenter;
        [Inject] private CodexPresenter _codexPresenter;

        private void Start()
        {
            _nameKey = DataRegistry.MonsterBases[_monsterID].NameKey;
            _localePresenter.OnLanguageChanged.AddListener(Refresh);
            Refresh();
        }

        [Button]
        private void Initialize(string monsterID)
        {
            _monsterID = monsterID;
            _nameKey = DataRegistry.MonsterBases[monsterID].NameKey;
            _localePresenter.OnLanguageChanged.AddListener(Refresh);
            Refresh();
        }
        
        [Button]
        private void Refresh()
        {
            _nameText.text = _localePresenter.GetLocaleString(_nameKey);
        }

        public void SetCodexID()
        {
            _codexPresenter.CodexID = _monsterID;
        }
    }
}