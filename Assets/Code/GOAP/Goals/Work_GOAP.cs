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
        if (GOAP_Entity.Work.Work2Do > 1 && World.Time.Hour is > 7 and < 20 && priority != 60)
        {
            priority = 60;
            Logger.WriteLog("[Goal] Work priority changed to [60].");
        }
        else if (GOAP_Entity.Work.Work2Do <= 1 || World.Time.Hour is < 7 or > 20)
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