namespace Runtime.Domains.Common.FSM
{
    public interface IFSMState
    {
        public void Enter();
        public void Exit();
        public void Update();
        public void FixedUpdate();
        public void LateUpdate();
    }
}