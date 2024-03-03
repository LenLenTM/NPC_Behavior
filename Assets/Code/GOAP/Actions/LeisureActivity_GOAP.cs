using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class LeisureActivity_GOAP : BaseAction
{
    public Vector3 PreconditionValue;
    private int leisureTime;

    public LeisureActivity_GOAP(GOAP_Entity goapEntity) : base(goapEntity)
    {
        PreconditionType = typeof(Vector3);
        ResultType = typeof(Leisure);
        name = "Leisure";
    }
        
    public override void Initialize(object initializer)
    {
        leisureTime = (int)initializer;
    }
    
    public override void InitializePreConValue()
    {
        var random = new Random();

        switch (random.Next(0, 3))
        {
            case 0:
                PreconditionValue = World.Locations.Find(l => l.Typ == Locations.Cinema).transform.position;
                name = "Watching movie";
                break;
            case 1:
                PreconditionValue = World.Locations.Find(l => l.Typ == Locations.Friends).transform.position;
                name = "Meeting friends";
                break;
            case 2:
                PreconditionValue = World.Locations.Find(l => l.Typ == Locations.Games).transform.position;
                name = "Gaming";
                break;
        }
    }

    public override bool Action()
    {
        leisureTime -= 1 * World.Speed;
                
        return leisureTime <= 0;
    }
    
    public override object GetPreconditionValue()
    {
        return PreconditionValue;
    }
}