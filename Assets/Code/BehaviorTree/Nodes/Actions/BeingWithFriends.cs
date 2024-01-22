public class BeingWithFriends : Node
{
    public BeingWithFriends(){}

    public override NodeState Evaluate()
    {
        string leisureTyp = (string)GetData("leisure");
        int leisureTime = (int)GetData("leisureTime");
        

        if (leisureTime > 0 && leisureTyp.Equals("friends"))
        {
            leisureTime--;
            state = NodeState.Running;
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
                
        parent.parent.parent.SetData("leisureTime", 0);
        state = NodeState.Success;
        return state;
    }
}