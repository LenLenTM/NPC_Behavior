
using System;
using UnityEngine;

public class WatchingMovie : Node
{
        public WatchingMovie(){}

        public override NodeState Evaluate()
        {
                var leisureTime = (int)GetData("leisureTime");
                string leisureTyp = (string)GetData("leisure");

                if (leisureTime > 0 && leisureTyp.Equals("cinema"))
                {
                        leisureTime -= 1 * World.Speed;
                        parent.parent.parent.SetData("leisureTime", leisureTime);
                        state = NodeState.Running;
                        return state;
                }

                if (leisureTime > 0 && !leisureTyp.Equals("cinema"))
                {
                        state = NodeState.Failure;
                        return state;
                }
                
                if (leisureTime <= 0)
                {
                        parent.parent.parent.SetData("leisure", "");
                }
                
                parent.parent.parent.SetData("leisureTime", 0);
                state = NodeState.Success;
                return state;
        }
}