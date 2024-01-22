public class Sleeping : Node
{
        private Sleep _sleep;

        public Sleeping(Sleep sleep)
        {
                _sleep = sleep;
        }

        public override NodeState Evaluate()
        {
                bool isSleeping = (bool)GetData("sleep");

                if (isSleeping)
                {
                        _sleep.Tiredness -= 0.00154 * World.Speed;
                        if (_sleep.Tiredness < 0)
                        {
                                _sleep.Tiredness = 0;
                        }

                        state = NodeState.Running;
                        return state;
                }

                state = NodeState.Failure;
                return state;
        }
}