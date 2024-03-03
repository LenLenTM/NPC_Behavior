using System;
using System.Linq;
using UnityEngine;

public class Working_GOAP : BaseAction
{
    public Vector3 PreconditionValue;
    private double targetWork;

    public Working_GOAP(GOAP_Entity goapEntity) : base(goapEntity)
    {
        PreconditionType = typeof(Vector3);
        ResultType = typeof(Work);
        name = "Working";
    }
        
    public override void Initialize(object initializer)
    {
        targetWork = (double)initializer;
    }
    
    public override void InitializePreConValue()
    {
        PreconditionValue = World.Locations.Find(l => l.Typ == Locations.Work).transform.position;
    }

    public override bool Action()
    {
        GOAP_Entity.Work.Work2Do -= 0.003 * World.Speed;
                
        return GOAP_Entity.Work.Work2Do <= 1;
    }

    public override object GetPreconditionValue()
    {
        return PreconditionValue;
    }
}