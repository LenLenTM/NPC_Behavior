using System;
using UnityEngine;

public class Hunger_GOAP : BaseGoal
{
    private double goal = 0;

    public Hunger_GOAP(GOAP_Entity goapEntity) : base(goapEntity)
    {
        name = "Hunger_GOAP";
        GoalType = typeof(Hunger);
    }

    public override void UpdatePriority()
    {
        if (entity.Hunger.Hungry > 62)
        {
            priority = 90;
        }
        else if (entity.Hunger.Hungry <= goal)
        {
            priority = 0;
        }
    }

    public override void Initialize()
    {
        goal = entity.Hunger.Hungry - 40;
    }
    
    public override object GetGoalValue()
    {
        return goal;
    }
}