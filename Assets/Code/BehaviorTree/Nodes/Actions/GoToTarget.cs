﻿using UnityEngine;

public class GoToTarget : Node
{
        private Transform _transform;

        public GoToTarget(Transform transform)
        {
                _transform = transform;
        }

        public override NodeState Evaluate()
        {
                Vector3 target = (Vector3)GetData("target");

                if (Vector3.Distance(_transform.position, target) > 0.01f)
                {
                        _transform.position = Vector3.MoveTowards
                                (
                                _transform.position, 
                                target, 
                                World.Speed * Time.deltaTime
                                );
                        
                        state = NodeState.Running;
                        return state;
                }

                state = NodeState.Success;
                return state;
        }
}