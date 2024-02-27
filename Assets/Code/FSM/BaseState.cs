public class BaseState
{
        public string name;
        private protected FSM_Entity _stateMachine;

        public BaseState(string name, FSM_Entity stateMachine)
        {
                this.name = name;
                this._stateMachine = stateMachine;
        }

        public virtual void Enter(){}
        public virtual void Update(){}
        public virtual void Exit(){}
}