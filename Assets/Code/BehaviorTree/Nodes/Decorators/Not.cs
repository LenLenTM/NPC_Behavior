using System;
using UnityEngine;

public class Not : Node
{
        private Node _innerNode;

        public Not(Node node)
        {
                _innerNode = node;
        }

        public override NodeState Evaluate()
        {
                switch (_innerNode.Evaluate())
                {
                        case NodeState.Failure:
                                state = NodeState.Success;
                                break;
                        case NodeState.Success:
                                state = NodeState.Failure;
                                break;
                        case NodeState.Running:
                                state = NodeState.Running;
                                break;
                }

                return state;
        }
}