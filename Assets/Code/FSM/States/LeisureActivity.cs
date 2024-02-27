public class LeisureActivity : BaseState
{
    public LeisureActivity(FSM_Entity stateMachine) : base("LeisureActivity", stateMachine){}

    private int _timeSpent;
    public override void Enter()
    {
        base.Enter();
        _timeSpent = 60 * 30;
    }

    public override void Update()
    {
        base.Update();

        var check = TransitionChecker.CheckTransition(_stateMachine);
        if (check.transition && _timeSpent <= 0)
        {
            _stateMachine.ChangeState(check.state);
        }
        else
        {
            _timeSpent -= 1 * World.Speed;
        }
    }
}