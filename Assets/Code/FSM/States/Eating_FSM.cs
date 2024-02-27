public class Eating_FSM : BaseState
{
    public Eating_FSM(FSM_Entity stateMachine) : base("Eat", stateMachine){}

    private double _targetHunger;
    
    public override void Enter()
    {
        base.Enter();
        _targetHunger = _stateMachine.Hunger.Hungry - 40f;
    }

    public override void Update()
    {
        base.Update();
        var check = TransitionChecker.CheckTransition(_stateMachine);
        if (check.transition && _stateMachine.Hunger.Hungry <= _targetHunger)
        {
            _stateMachine.ChangeState(check.state);
        }
        else
        {
            _stateMachine.Hunger.Hungry -= 0.025 * World.Speed;
        }
    } 
}