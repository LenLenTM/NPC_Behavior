public class Sleeping_FSM : BaseState
{
    public Sleeping_FSM(FSM_Entity stateMachine) : base("Sleeping", stateMachine){}

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
        else
        {
            _stateMachine.Sleep.Tiredness -= 0.00454 * World.Speed;
        }
    } 
}