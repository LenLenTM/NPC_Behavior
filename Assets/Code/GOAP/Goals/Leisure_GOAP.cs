using System;
using UnityEngine;

public class Leisure_GOAP : BaseGoal
{
    private int goal = 5000;

    public Leisure_GOAP(GOAP_Entity goapEntity) : base(goapEntity)
    {
        name = "Leisure_GOAP";
        GoalType = typeof(Leisure);
    }

    public override void UpdatePriority()
    {
        if (World.Time.Hour is < 20 and > 8 && priority != 40)
        {
            priority = 40;
            Logger.WriteLog("[Goal] Leisure priority changed to [40].");
        }
        else if(World.Time.Hour is > 20 or < 8)
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