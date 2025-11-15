using SQLite4Unity3d;

namespace Database.DataRepositories
{
    public interface IDataLoader
    {
        /// <summary>
        /// SQLite 데이터베이스로부터 데이터를 읽어와 리포지토리를 채우는 메서드입니다.
        /// DataRegistry로부터 데이터베이스 연결 객체를 전달받아 데이터를 읽습니다.
        /// 필요시 DataRegistry를 통해 먼저 초기화된 다른 리포지토리를 활용합니다.
        /// </summary>
        /// <param name="connection">데이터 조회에 사용되는 SQLite 데이터베이스 연결 객체</param>
        /// <param name="registry">다른 데이터 리포지토리에 접근하기 위한 DataRegistry</param>
        void LoadData(SQLiteConnection connection, DataRegistry registry);
    }
}