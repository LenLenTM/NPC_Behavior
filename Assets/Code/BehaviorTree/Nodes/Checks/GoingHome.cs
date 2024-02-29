using System.Linq;

public class GoingHome : Node
{
        public GoingHome()
        {
        }

        public override NodeState Evaluate()
        {
            Logger.WriteLog("Nothing else to do. Let's go home [...]");
            PerformanceMeter.StopStopwatch(4);
            parent.parent.SetData("target", World.Locations.FirstOrDefault(l => l.Typ.Equals(Locations.Home)).transform.position);
            state = NodeState.Success; 
            return state;
        }
}