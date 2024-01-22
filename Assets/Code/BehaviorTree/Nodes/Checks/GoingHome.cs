using System.Linq;

public class GoingHome : Node
{
        public GoingHome()
        {
        }

        public override NodeState Evaluate()
        {
               parent.parent.SetData("target", World.Locations.FirstOrDefault(l => l.Typ.Equals(Locations.Home)).transform.position);

               state = NodeState.Success;
               return state;
        }
}