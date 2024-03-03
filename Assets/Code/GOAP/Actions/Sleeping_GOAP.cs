using System;
using System.Linq;
using UnityEngine;

public class Sleeping_GOAP : BaseAction
{
    public Vector3 PreconditionValue;
    private double targetTiredness;

    public Sleeping_GOAP(GOAP_Entity goapEntity) : base(goapEntity)
    {
        PreconditionType = typeof(Vector3);
        ResultType = typeof(Sleep);
    }
        
    public override void Initialize(object initializer)
    {
        targetTiredness = (double)initializer;
    }
    
    public override void InitializePreConValue()
    {
        PreconditionValue = World.Locations.Find(l => l.Typ == Locations.Bed).transform.position;
    }

    public override bool Action()
    {
        Debug.Log("Sleeping");
        
        entity.Sleep.Tiredness -= 0.00454 * World.Speed;
                
        return entity.Hunger.Hungry <= targetTiredness;
    }
    
    public override object GetPreconditionValue()
    {
        return PreconditionValue;
    }
}