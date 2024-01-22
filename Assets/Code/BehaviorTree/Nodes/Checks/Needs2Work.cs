using System.Linq;
using UnityEngine;

public class Needs2Work : Node
{
        private Transform _transform;

        public Needs2Work(Transform transform)
        {
                _transform = transform;
        }

        public override NodeState Evaluate()
        {
                if (BT_Entity.Work.Work2Do > 1 && World.Time.Hour > 7 && World.Time.Hour < 20)
                {
                        parent.parent.SetData("target", World.Locations.FirstOrDefault(l => l.Typ.Equals(Locations.Work)).transform.position);

                        state = NodeState.Success;
                        return state;
                }

                state = NodeState.Failure;
                return state;
        }
}