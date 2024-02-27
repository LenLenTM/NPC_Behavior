using System;
using UnityEngine;

public interface IGoal
{
    bool PreconditionsChecked();
    int CalculatePriority();
    void SatisfyGoal();
    void ActivateGoal();
    void DeactivateGoal();
}
public class BaseGoal : MonoBehaviour, IGoal
{
    public int priority = -1;
    
    public virtual bool PreconditionsChecked()
    {
        return false;
    }

    public virtual int CalculatePriority()
    {
        return priority;
    }

    public virtual void SatisfyGoal()
    {
    }

    public virtual void ActivateGoal()
    {
    }

    public virtual void DeactivateGoal()
    {
    }
}