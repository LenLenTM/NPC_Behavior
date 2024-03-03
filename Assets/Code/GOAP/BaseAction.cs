using System;
using UnityEngine;

public interface IBaseAction
{
        bool Action();
        void Initialize(object initializer);
        void InitializePreConValue();
        object GetPreconditionValue();
}

public class BaseAction : IBaseAction
{
        public Type ResultType = null;
        public Type PreconditionType = null;
        public GOAP_Entity entity;

        public BaseAction(GOAP_Entity goapEntity)
        {
                entity = goapEntity;
        }

        public virtual bool Action()
        {
                return false;
        }

        public virtual void Initialize(object initializer)
        {
                
        }

        public virtual void InitializePreConValue()
        {
                
        }

        public virtual object GetPreconditionValue()
        {
                return new object();
        }
}