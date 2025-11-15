using UnityEngine;
using Sirenix.OdinInspector;
using SQLite4Unity3d;
using System.IO;

namespace Database
{
    /// <summary>
    /// SQLite 데이터베이스를 불러오는 베이스 클래스입니다.
    /// 실제 데이터 로딩은 자식 클래스를 통해 구현합니다.
    /// </summary>
    public abstract class AbstractDataRegistry : SerializedMonoBehaviour
    {
        /// <summary>
        /// 확장자를 포함한 데이터베이스 경로입니다.
        /// StreamingAssets 기준 상대 경로를 사용합니다.
        /// </summary>
        protected abstract string DatabasePath { get; }
        
        /// <summary>
        /// DB 연결을 생성하고 자식 클래스의 데이터 로딩 메서드를 호출합니다.
        /// using을 통해 데이터 로딩 후 자동으로 연결을 닫습니다.
        /// </summary>
        protected void RegisterData()
        {
            string path = Path.Combine(Application.streamingAssetsPath, DatabasePath);
            using SQLiteConnection connection = new(path, SQLiteOpenFlags.ReadOnly);

            LoadData(connection);
        }
        
        /// <summary>
        /// 실제 데이터 로딩 로직을 구현하는 메서드입니다.
        /// </summary>
        protected abstract void LoadData(SQLiteConnection connection);
    }
}