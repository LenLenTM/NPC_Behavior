using System;
using UnityEngine;

public class Tiredness_GOAP : BaseGoal
{
    private double goal = 5;

    public Tiredness_GOAP(GOAP_Entity goapEntity) : base(goapEntity)
    {
        name = "Tiredness_GOAP";
        GoalType = typeof(Sleep);
    }


    public override void UpdatePriority()
    {
        if (entity.Sleep.Tiredness > 80 || World.Time.Hour > 22)
        {
            priority = 85;
        }
        else if (entity.Sleep.Tiredness <= 5 && World.Time.Hour < 22 && World.Time.Hour > 6)
        {
            priority = 0;
        }
    }

    public override void Initialize()
    {
    }
    
    public override object GetGoalValue()
    {
        return goal;
    }
}