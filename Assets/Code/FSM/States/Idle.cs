public class Idle : BaseState
{
        public Idle(FSM_Entity stateMachine) : base("Idle", stateMachine){}

        public override void Enter()
        {
                base.Enter();
        }

        public override void Update()
        {
                base.Update();
                var check = TransitionChecker.CheckTransition(_stateMachine);
                if (check.transition)
                {
                        _stateMachine.ChangeState(check.state);
                }
        }
}