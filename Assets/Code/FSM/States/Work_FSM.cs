public class Work_FSM : BaseState
{
    public Work_FSM(FSM_Entity stateMachine) : base("Work", stateMachine){}

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
            FSM_Entity.Work.Work2Do -= 0.003 * World.Speed;
        }
    } 
}