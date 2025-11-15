using Database.DataRepositories;
using Sirenix.Serialization;
using SQLite4Unity3d;
using UnityEngine;

namespace Database
{
    /// <summary>
    /// 모든 데이터 테이블을 로딩해 관리하는 전역 데이터 레지스트리입니다.
    /// 싱글톤 패턴 및 DontDestroyOnLoad 메서드를 통해 모든 씬에서 접근이 가능합니다.
    /// </summary>
    public class DataRegistry : AbstractDataRegistry
    {
        /// <summary>
        /// Awake 메서드를 통해 싱글톤을 구현합니다.
        /// 인스턴스 초기화 후 RegisterData 메서드를 호출하여 자동으로 데이터를 불러옵니다.
        /// </summary>
        #region Singleton
        private static DataRegistry _instance;
        public static DataRegistry Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new GameObject("Data Registry").AddComponent<DataRegistry>();
                }
                return _instance;
            }
        }
        private void Awake()
        {
            if(_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
            
            RegisterData();
        }

        #endregion
        
        /// <summary>
        /// 유니티 인스펙터를 통해 데이터베이스 경로를 설정합니다.
        /// StreamingAssets 기준 상대 경로를 사용합니다.
        /// </summary>
        [field: SerializeField] private string _databasePath;
        protected override string DatabasePath => _databasePath;
        
        /// <summary>
        /// 데이터 리포지토리를 초기화합니다.
        /// </summary>
        protected override void LoadData(SQLiteConnection connection)
        {
            // 데이터 리포지토리 Load 메서드 추가
            _weapons.LoadData(connection, this);
            _accessories.LoadData(connection, this);
        }
        
        // 데이터 리포지토리 필드 추가
        [OdinSerialize] private WeaponDataRepository _weapons;
        [OdinSerialize] private AccessoryDataRepository _accessories;
        
        // 데이터 리포지토리 getter 추가
        public static WeaponDataRepository Weapons => Instance._weapons;
        public static AccessoryDataRepository Accessories => Instance._accessories;
    }
}