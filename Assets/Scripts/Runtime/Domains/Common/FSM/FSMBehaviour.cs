using Sirenix.OdinInspector;

namespace Runtime.Domains.Common.FSM
{
    public abstract class FSMBehaviour : SerializedMonoBehaviour
    {
        protected IFSMState _currentState;
        protected IFSMState _defaultState;

        private void Update()
        {
            _currentState?.Update();
        }

        private void FixedUpdate()
        {
            _currentState?.FixedUpdate();
        }

        private void LateUpdate()
        {
            _currentState?.LateUpdate();
        }

        public void ChangeState(IFSMState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }

        public void ChangeDefaultState()
        {
            _defaultState?.Exit();
            _currentState = _defaultState;
            _currentState?.Enter();
        }
    }
}