using System;
using System.Linq;
using UnityEngine;

public class Eating_GOAP : BaseAction
{
    public Vector3 PreconditionValue;
    private double _targetHunger;

    public Eating_GOAP(GOAP_Entity goapEntity) : base(goapEntity)
    {
        PreconditionType = typeof(Vector3);
        ResultType = typeof(Hunger);
    }
        
    public override void Initialize(object initializer)
    {
        _targetHunger = (double)initializer;
    }
    
    public override void InitializePreConValue()
    {
        PreconditionValue = World.Locations.Where(l => l.Typ == Locations.Eat).OrderBy(l => Vector3.Distance(l.transform.position, entity.transform.position)).First().transform.position;
    }

    public override bool Action()
    {
        Debug.Log("Eating");
        
        entity.Hunger.Hungry -= 0.025 * World.Speed;
                
        return entity.Hunger.Hungry <= _targetHunger;
    }
    
    public override object GetPreconditionValue()
    {
        return PreconditionValue;
    }
}