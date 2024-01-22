public class Gaming : Node
{
    public Gaming(){}

    public override NodeState Evaluate()
    {
        int leisureTime = (int)GetData("leisureTime");
        string leisureTyp = (string)GetData("leisure");

        if (leisureTime > 0 && leisureTyp.Equals("games"))
        {
            leisureTime--;
            state = NodeState.Running;
            return state;
        }

        if (leisureTime > 0 && !leisureTyp.Equals("games"))
        {
            state = NodeState.Failure;
            return state;
        }

        if (leisureTime <= 0)
        {
            parent.parent.SetData("leisure", "");
        }
                
        parent.parent.parent.SetData("leisureTime", 0);
        state = NodeState.Success;
        return state;
    }
}