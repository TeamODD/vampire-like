using UnityEngine;
using SQLite4Unity3d;
using System.Collections.Generic;

namespace Database.DataRepositories
{
    /// <summary>
    /// 딕셔너리를 상속받은 추상 데이터 리포지토리 클래스입니다.
    /// 인덱서를 통해 접근할 수 있으며, 잘못된 키 접근 시 경고 메시지를 출력합니다.
    /// 각 데이터 리포지토리는 이 클래스를 상속하여 구현합니다.
    /// </summary>
    /// <typeparam name="TKey">데이터를 조회할 때 사용하는 키 타입</typeparam>
    /// <typeparam name="TData">저장 및 조회 대상이 되는 데이터 타입</typeparam>
    public abstract class AbstractDataRepository<TKey, TData> : Dictionary<TKey, TData>, IDataLoader where TData : class
    {
        /// <summary>
        /// 키를 통해 데이터에 접근합니다.
        /// 잘못된 키 접근 시 경고 메시지를 출력하고 null을 반환합니다.
        /// </summary>
        /// <param name="key">데이터를 조회할 때 사용하는 키</param>
        public new TData this[TKey key]
        {
            get
            {
                if(!base.TryGetValue(key, out var data))
                {
                    Debug.LogWarning($"[{GetType().Name}] 키를 찾을 수 없음. KEY: {key}");
                    return null;
                }
                return data;
            }
            set => base[key] = value;
        }
        
        /// <summary>
        /// SQLite 데이터베이스로부터 데이터를 읽어와 리포지토리를 채우는 메서드입니다.
        /// DataRegistry로부터 데이터베이스 연결 객체를 전달받아 데이터를 읽습니다.
        /// 필요시 DataRegistry를 통해 먼저 초기화된 다른 리포지토리를 활용합니다.
        /// </summary>
        /// <param name="connection">데이터 조회에 사용되는 SQLite 데이터베이스 연결 객체</param>
        /// <param name="registry">다른 데이터 리포지토리에 접근하기 위한 DataRegistry</param>
        public abstract void LoadData(SQLiteConnection connection, DataRegistry registry);
    }
}