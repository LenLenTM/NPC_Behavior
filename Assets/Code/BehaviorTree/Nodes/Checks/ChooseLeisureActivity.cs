using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChooseLeisureActivity : Node
{
        private Transform _transform;

        public ChooseLeisureActivity(Transform transform)
        {
                _transform = transform;
        }

        public override NodeState Evaluate()
        {
                string leisureActivity = (string)GetData("leisure");

                if (leisureActivity.Equals("") && World.Time.Hour > 8 && World.Time.Hour < 22)
                {
                        Vector3 target = new Vector3();
                        switch (Random.Range(0, 3))
                        {
                                case 0:
                                        target = World.Locations.FirstOrDefault(l => l.Typ.Equals(Locations.Cinema)).transform.position;
                                        parent.parent.SetData("target", target);
                                        parent.parent.SetData("leisure", "cinema");
                                        break;
                                case 1:
                                        target = World.Locations.FirstOrDefault(l => l.Typ.Equals(Locations.Friends)).transform.position;
                                        parent.parent.SetData("target", target);
                                        parent.parent.SetData("leisure", "friends");
                                        break;
                                case 2:
                                        target = World.Locations.FirstOrDefault(l => l.Typ.Equals(Locations.Games)).transform.position;
                                        parent.parent.SetData("target", target);
                                        parent.parent.SetData("leisure", "games");
                                        break;
                        }
                        parent.parent.SetData("leisureTime", (int)200);
                        state = NodeState.Success;
                        return state;
                }
                if (!String.IsNullOrEmpty(leisureActivity) && World.Time.Hour > 8 && World.Time.Hour < 22)
                {
                        state = NodeState.Success;
                        return state;
                }
                
                state = NodeState.Failure;
                return state;
        }
}