using System;
using UnityEditor;
using UnityEngine;

public class GoTo_GOAP : BaseAction
{
        public Vector3 target;

        public GoTo_GOAP(GOAP_Entity goapEntity) : base(goapEntity)
        {
                PreconditionType = null;
                ResultType = typeof(Vector3);
                name = "GoToLocation";
        }
        
        public override void Initialize(object initializer)
        {
                target = (Vector3)initializer;
        } 

        public override bool Action()
        {
                entity.transform.position = Vector3.MoveTowards
                (
                        entity.transform.position,
                        target,
                        World.Speed * Time.deltaTime * 2
                );
                
                return Vector3.Distance(target, entity.transform.position) < 0.01f;
        }
}