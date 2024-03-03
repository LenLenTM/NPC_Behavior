using System;
using UnityEngine;

public class Work_GOAP : BaseGoal
{
    private double goal = 1;

    public Work_GOAP(GOAP_Entity goapEntity) : base(goapEntity)
    {
        name = "Work_GOAP";
        GoalType = typeof(Work);
    }

    public override void UpdatePriority()
    {
        if (GOAP_Entity.Work.Work2Do > 1 && World.Time.Hour > 7 && World.Time.Hour < 20)
        {
            priority = 60;
        }
        else
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