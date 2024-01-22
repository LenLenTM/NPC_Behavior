public class BeingWithFriends : Node
{
    public BeingWithFriends(){}

    public override NodeState Evaluate()
    {
        int leisureTime = (int)GetData("leisureTime");
        string leisureTyp = (string)GetData("leisure");

        if (leisureTime > 0 && leisureTyp.Equals("friends"))
        {
            leisureTime--;
            state = NodeState.Success;
            return state;
        }

        if (leisureTime > 0 && !leisureTyp.Equals("friends"))
        {
            state = NodeState.Failure;
            return state;
        }
        
        if (leisureTime <= 0)
        {
            parent.parent.SetData("leisure", "");
        }
                
        parent.parent.SetData("leisureTime", 0);
        state = NodeState.Failure;
        return state;
    }
}