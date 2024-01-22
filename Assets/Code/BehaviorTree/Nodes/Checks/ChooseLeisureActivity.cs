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
                Debug.Log(leisureActivity);

                if (leisureActivity.Equals("") && World.Time.Hour > 8 && World.Time.Hour < 22)
                {
                        switch (Random.Range(0, 3))
                        {
                                case 0:
                                        parent.parent.SetData("target", World.Locations.FirstOrDefault(l => l.Typ.Equals(Locations.Cinema)).transform.position);
                                        parent.parent.SetData("leisure", "cinema");
                                        break;
                                case 1:
                                        parent.parent.SetData("target", World.Locations.FirstOrDefault(l => l.Typ.Equals(Locations.Friends)).transform.position);
                                        parent.parent.SetData("leisure", "friends");
                                        break;
                                case 2:
                                        parent.parent.SetData("target", World.Locations.FirstOrDefault(l => l.Typ.Equals(Locations.Games)).transform.position);
                                        parent.parent.SetData("leisure", "games");
                                        break;
                        }
                        parent.parent.SetData("leisureTime", 200);
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