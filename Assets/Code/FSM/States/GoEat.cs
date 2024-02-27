using System.Linq;
using UnityEngine;

public class GoEat : BaseState
{
    public GoEat(FSM_Entity stateMachine) : base("GoEat", stateMachine){}

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
            var targetLocation = World.Locations.Where(l => l.Typ == Locations.Eat).OrderBy(l => Vector3.Distance(l.transform.position, _stateMachine.transform.position)).First();
            _stateMachine.transform.position = Vector3.MoveTowards
            (
                _stateMachine.transform.position,
                targetLocation.transform.position,
                World.Speed * Time.deltaTime * 2
            );
        }
    }   
}