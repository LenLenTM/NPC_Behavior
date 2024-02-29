public class Sleeping_FSM : BaseState
{
    public Sleeping_FSM(FSM_Entity stateMachine) : base("Sleeping", stateMachine){}

    public override void Enter()
    {
        base.Enter();
        Logger.WriteLog("Sleeping. [Tiredness > 80 or time after 22:00]");
        PerformanceMeter.StopStopwatch(8);
    }

    public override void Update()
    {
        base.Update();
        PerformanceMeter.StartStopwatch();
        var check = TransitionChecker.CheckTransition(_stateMachine);
        if (check.transition && (_stateMachine.Sleep.Tiredness <= 1 && World.Time.Hour > 6))
        {
            _stateMachine.ChangeState(check.state);
        }
        else
        {
            PerformanceMeter.ResetStopwatch();
            _stateMachine.Sleep.Tiredness -= 0.00454 * World.Speed;
            if (_stateMachine.Sleep.Tiredness < 0)
            {
                _stateMachine.Sleep.Tiredness = 0;
            }
        }
    } 
}