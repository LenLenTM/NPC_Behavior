using System;
using System.Collections.Generic;
using UnityEngine;

public class Not : Node
{
        public Not() : base(){}
        public Not(List<Node> children) : base(children){}
        
        public override NodeState Evaluate()
        {
                foreach (Node node in children)
                {
                        switch (node.Evaluate())
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
                }
                return state;
        }
}