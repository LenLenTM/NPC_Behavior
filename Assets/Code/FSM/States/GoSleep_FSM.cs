using UnityEngine;

public class GoSleep_FSM : BaseState
{
    public GoSleep_FSM(FSM_Entity stateMachine) : base("GoSleep", stateMachine){}

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
            _stateMachine.transform.position = Vector3.MoveTowards
            (
                _stateMachine.transform.position,
                World.Locations.Find(l => l.Typ == Locations.Bed).transform.position,
                World.Speed * Time.deltaTime * 2
            );
        }
    } 
}