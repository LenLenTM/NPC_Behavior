public class Idle : BaseState
{
        public Idle(FSM_Entity stateMachine) : base("Idle", stateMachine){}

        public override void Enter()
        {
                base.Enter();
                Logger.WriteLog("At home. [nothing else to do]");
                PerformanceMeter.StopStopwatch(6);
        }

        public override void Update()
        {
                base.Update();
                PerformanceMeter.StartStopwatch();
                var check = TransitionChecker.CheckTransition(_stateMachine);
                if (check.transition)
                {
                        _stateMachine.ChangeState(check.state);
                }
                else
                {
                        PerformanceMeter.ResetStopwatch();
                }
        }
}