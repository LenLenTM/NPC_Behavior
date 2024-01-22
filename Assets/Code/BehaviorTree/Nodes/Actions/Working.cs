public class Working : Node
{
        public Working(){}

        public override NodeState Evaluate()
        {
                if (BT_Entity.Work.Work2Do > 1)
                {
                        BT_Entity.Work.Work2Do -= 0.003 * World.Speed;

                        state = NodeState.Running;
                        return state;
                }
                state = NodeState.Success;
                return state;
        }
}