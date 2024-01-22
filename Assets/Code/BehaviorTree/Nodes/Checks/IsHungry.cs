using UnityEngine;

public class IsHungry : Node
{
    private Hunger _hunger;
    private Transform _transform;
        
    public IsHungry(Hunger hunger, Transform transform)
    {
        _hunger = hunger;
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        double hungerSet = (double)GetData("hunger");
        
        if (_hunger.Hungry > 62 && hungerSet == 0 && !(bool)GetData("sleep"))
        {
            parent.parent.SetData("target", FindNearestEat(_transform)); // vector3
            parent.parent.SetData("hunger", _hunger.Hungry - 40);
                
            state = NodeState.Success;
            return state;
        }

        if (hungerSet > 0)
        {
            state = NodeState.Success;
            return state;
        }

        state = NodeState.Failure;
        return state;
    }

    private Vector3 FindNearestEat(Transform startPosition)
    {
        var distance = 100000f;
        Vector3 nearest = new Vector3(0, 0, 0);

        foreach (Location location in World.Locations)
        {
            if (location.Typ.Equals(Locations.Eat))
            {
                var calcDistance = Vector3.Distance(startPosition.position, location.transform.position);
                if (calcDistance < distance)
                {
                    distance = calcDistance;
                    nearest = location.transform.position;
                }
            }
        }
        Debug.Log(nearest);
        return nearest;
    }
}