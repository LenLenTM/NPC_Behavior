public class Work_FSM : BaseState
{
    public Work_FSM(FSM_Entity stateMachine) : base("Work", stateMachine){}

    public override void Enter()
    {
        base.Enter();
        Logger.WriteLog("Working. [WorkToDo > 1 & time between 7:00 and 20:00]");
        PerformanceMeter.StopStopwatch(9);
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
            FSM_Entity.Work.Work2Do -= 0.003 * World.Speed;
        }
    } 
}