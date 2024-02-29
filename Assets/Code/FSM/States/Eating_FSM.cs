public class Eating_FSM : BaseState
{
    public Eating_FSM(FSM_Entity stateMachine) : base("Eat", stateMachine){}

    private double _targetHunger;
    
    public override void Enter()
    {
        base.Enter();
        _targetHunger = _stateMachine.Hunger.Hungry - 40f;
        Logger.WriteLog("Eating. [Hunger > 62]");
        PerformanceMeter.StopStopwatch(0);
    }

    public override void Update()
    {
        base.Update();
        PerformanceMeter.StartStopwatch();
        var check = TransitionChecker.CheckTransition(_stateMachine);
        if (check.transition && _stateMachine.Hunger.Hungry <= _targetHunger)
        {
            _stateMachine.ChangeState(check.state);
        }
        else
        {
            PerformanceMeter.ResetStopwatch();
            _stateMachine.Hunger.Hungry -= 0.025 * World.Speed;
        }
    } 
}