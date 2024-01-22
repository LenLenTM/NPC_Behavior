using UnityEngine;

public class Eating : Node
{

    private Hunger _hunger;
    public Eating(Hunger hunger)
    {
        _hunger = hunger;
    }

    public override NodeState Evaluate()
    {
        double hungryTarget = (double)GetData("hunger");
        
        if (_hunger.Hungry > hungryTarget)
        {
            _hunger.Hungry -= 0.05;

            state = NodeState.Running;
            return state;
        }
        parent.parent.SetData("hunger", (double)0);
        state = NodeState.Failure;
        return state;
    }
}