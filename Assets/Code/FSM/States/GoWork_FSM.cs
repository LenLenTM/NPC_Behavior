using UnityEngine;

public class GoWork_FSM : BaseState
{
    public GoWork_FSM(FSM_Entity stateMachine) : base("GoWork", stateMachine){}

    public override void Enter()
    {
        base.Enter();
        Logger.WriteLog("Going to work. [WorkToDo > 1 & time between 7:00 and 20:00]");
        PerformanceMeter.StopStopwatch(5);
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
            _stateMachine.transform.position = Vector3.MoveTowards
            (
                _stateMachine.transform.position,
                World.Locations.Find(l => l.Typ == Locations.Work).transform.position,
                World.Speed * Time.deltaTime * 2
            );
        }
    } 
}