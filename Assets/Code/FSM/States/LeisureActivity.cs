using System.Linq;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public class LeisureActivity : BaseState
{
    public LeisureActivity(FSM_Entity stateMachine) : base("LeisureActivity", stateMachine){}

    private int _timeSpent;
    public override void Enter()
    {
        base.Enter();
        _timeSpent = 60 * 30;

        var targetLocation = World.Locations.Find(l => Vector3.Distance(l.transform.position, _stateMachine.transform.position) < 0.01f).Typ;
        switch (targetLocation)
        {
            case Locations.Cinema:
                Logger.WriteLog("Watching movie at the cinema. [No other needs to fulfill]");
                break;
            case Locations.Friends:
                Logger.WriteLog("Being with friends. [No other needs to fulfill]");
                break;
            case Locations.Games:
                Logger.WriteLog("Playing games. [No other needs to fulfill]");
                break;
        }
        PerformanceMeter.StopStopwatch(7);
    }

    public override void Update()
    {
        base.Update();
        PerformanceMeter.StartStopwatch();
        var check = TransitionChecker.CheckTransition(_stateMachine);
        if (check.transition && _timeSpent <= 0)
        {
            _stateMachine.ChangeState(check.state);
        }
        else
        {
            PerformanceMeter.ResetStopwatch();
            _timeSpent -= 1 * World.Speed;
        }
    }
}