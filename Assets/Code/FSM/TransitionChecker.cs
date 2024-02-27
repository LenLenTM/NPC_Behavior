using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransitionObject
{
      
}
public class TransitionChecker
{
      public static (bool transition, BaseState state) CheckTransition(FSM_Entity stateMachine)
      {

            bool transition = false;
            BaseState state = stateMachine.CurrentState;
            
            
            // Go to eat
            if (stateMachine.Hunger.Hungry > 62 && World.Locations.Any(l => Vector3.Distance(l.transform.position, stateMachine.transform.position) > 0.01f && l.Typ == Locations.Eat))
            {
                  if (!state.Equals(stateMachine.GoEat))
                  {
                        transition = true;
                  }
                  state = stateMachine.GoEat;
                  return (transition, state);
            }
            
            // Eat
            if (stateMachine.Hunger.Hungry > 62)
            {
                  if (!state.Equals(stateMachine.Eating))
                  {
                        transition = true;
                  }
                  state = stateMachine.Eating;
                  return (transition, state);
            }
            
            // Go to sleep
            if ((stateMachine.Sleep.Tiredness > 80 || World.Time.Hour > 22) && World.Locations.Any(l => Vector3.Distance(l.transform.position, stateMachine.transform.position) > 0.01f && l.Typ == Locations.Bed))
            {
                  if (!state.Equals(stateMachine.GoSleep))
                  {
                        transition = true;
                  }
                  state = stateMachine.GoSleep;
                  return (transition, state);
            }
            
            // Sleep
            if (stateMachine.Sleep.Tiredness > 80 || World.Time.Hour > 22)
            {
                  if (!state.Equals(stateMachine.Sleeping))
                  {
                        transition = true;
                  }
                  state = stateMachine.Sleeping;
                  return (transition, state);
            }
            
            // Go to work
            if (FSM_Entity.Work.Work2Do > 1 && World.Time.Hour > 7 && World.Time.Hour < 20 && World.Locations.Any(l => Vector3.Distance(l.transform.position, stateMachine.transform.position) > 0.01f && l.Typ == Locations.Work))
            {
                  if (!state.Equals(stateMachine.GoWork))
                  {
                        transition = true;
                  }
                  state = stateMachine.GoWork;
                  return (transition, state);
            }
            
            // Work
            if (FSM_Entity.Work.Work2Do > 1 && World.Time.Hour > 7 && World.Time.Hour < 20)
            {
                  if (!state.Equals(stateMachine.Working))
                  {
                        transition = true;
                  }
                  state = stateMachine.Working;
                  return (transition, state);
            }
            
            // Go to leisure
            if (World.Time.Hour > 8 && World.Time.Hour < 20 && World.Locations.Any(l => Vector3.Distance(l.transform.position, stateMachine.transform.position) > 0.01f && (l.Typ == Locations.Cinema || l.Typ == Locations.Friends || l.Typ == Locations.Games)))
            {
                  if (!state.Equals(stateMachine.GoLeisure))
                  {
                        transition = true;
                  }
                  state = stateMachine.GoLeisure;
                  return (transition, state);
            }
            
            // Leisure
            if (World.Time.Hour > 8 && World.Time.Hour < 20)
            {
                  if (!state.Equals(stateMachine.Leisure))
                  {
                        transition = true;
                  }
                  state = stateMachine.Leisure;
                  return (transition, state);
            }
            
            // GoHome
            if (World.Locations.Any(l => Vector3.Distance(l.transform.position, stateMachine.transform.position) > 0.01f && l.Typ == Locations.Home))
            {
                  if (!state.Equals(stateMachine.GoHome))
                  {
                        transition = true;
                  }
                  state = stateMachine.GoHome;
                  return (transition, state);
            }
            
            // Idle
            return (true, stateMachine.Idle);
      }
}