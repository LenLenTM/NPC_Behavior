using System.Linq;
using UnityEngine;

public class IsTired : Node
{
        private Sleep _sleep;
        private Transform _transform;

        public IsTired(Sleep sleep, Transform transform)
        {
                _sleep = sleep;
                _transform = transform;
        }

        public override NodeState Evaluate()
        {
                bool tiredSet = (bool)GetData("sleep");

                if ((_sleep.Tiredness > 80 && !tiredSet) || World.Time.Hour > 22 )
                {
                        parent.parent.SetData("sleep", true);
                        parent.parent.SetData("target", World.Locations.FirstOrDefault(l => l.Typ.Equals(Locations.Bed)).transform.position);

                        state = NodeState.Success;
                        return state;
                }

                if (_sleep.Tiredness <= 5 && World.Time.Hour < 22 && World.Time.Hour > 6)
                {
                        parent.parent.SetData("sleep", false);

                        state = NodeState.Failure;
                        return state;
                }
                
                if (tiredSet)
                {
                        state = NodeState.Success;
                        return state;
                }

                state = NodeState.Failure;
                return state;
        }
}