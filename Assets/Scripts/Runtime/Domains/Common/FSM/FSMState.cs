namespace Runtime.Domains.Common.FSM
{
    public abstract class FSMState : IFSMState
    {
        public void Enter()
        {
            OnEnter();
        }

        public void Exit()
        {
            OnExit();
        }

        public void Update()
        {
            OnUpdate();
        }

        public void FixedUpdate()
        {
            OnFixedUpdate();
        }

        public void LateUpdate()
        {
            OnLateUpdate();
        }

        protected virtual void OnEnter() { }
        protected virtual void OnExit() { }
        protected virtual void OnUpdate() { }
        protected virtual void OnFixedUpdate() { }
        protected virtual void OnLateUpdate() { }
    }
}