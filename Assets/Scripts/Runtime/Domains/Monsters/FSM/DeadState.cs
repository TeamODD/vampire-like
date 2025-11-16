namespace Runtime.Domains.Monsters.FSM
{
    /// <summary>
    /// 몬스터 사망 상태 구현 클래스입니다. 
    /// </summary>
    public class DeadState : MonsterState
    {
        protected override void OnEnter()
        {
            UnityEngine.Object.Destroy(_fsmBehaviour.Owner.gameObject);
        }
    }
}