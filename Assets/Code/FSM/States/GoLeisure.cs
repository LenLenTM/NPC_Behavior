using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GoLeisure : BaseState
{
    public GoLeisure(FSM_Entity stateMachine) : base("GoLeisure", stateMachine){}

    private Location _targetLocation;
    public override void Enter()
    {
        base.Enter();
        var locations = new List<Location>()
        {
            World.Locations.Find(l => l.Typ == Locations.Cinema),
            World.Locations.Find(l => l.Typ == Locations.Games),
            World.Locations.Find(l => l.Typ == Locations.Friends)
        };
        var random = new Random();
        var randomIndex = random.Next(0, locations.Count);

        _targetLocation = locations[randomIndex];
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
                _targetLocation.transform.position,
                World.Speed * Time.deltaTime * 2
            );
        }
    }
}