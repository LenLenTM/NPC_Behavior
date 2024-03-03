using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Planner
{
        private List<BaseAction> _plan; // stores the plan for execution and checking the last link in the plan if it still fulfills the current goal

        private BaseGoal _currentGoal = null;
        private bool changedGoal = false;
        
        public Planner(){}
        
        public void PlanningAndExecution(List<BaseAction> actions, List<BaseGoal> goals)
        {
                UpdateGoalPriority(goals);
                UpdateGoal(goals);

                if (!(_plan.Count >= 1) || !CheckPlanValid())
                {
                        Plan(actions);
                }
                
                ExecutePlan();
        }

        private bool CheckPlanValid()
        {
                return _currentGoal.GoalType == _plan[0].ResultType;
        }

        private void UpdateGoal(List<BaseGoal> goals)
        {
                var highestPriority = goals.OrderByDescending(g => g.priority).First();

                if (_currentGoal == null || !_currentGoal.name.Equals(highestPriority.name))
                {
                        _currentGoal = highestPriority;
                        _currentGoal.Initialize();
                        _plan = new List<BaseAction>();
                        changedGoal = true;
                }
        }

        private void UpdateGoalPriority(List<BaseGoal> goals)
        {
                foreach (var goal in goals)
                {
                        goal.UpdatePriority();
                }
        }

        private void Plan(List<BaseAction> actions)
        {
                PerformanceMeter.StartStopwatch();
                
                _plan = new List<BaseAction>();
                BaseAction nextStep = null;

                foreach (var action in actions)
                {
                        if (action.ResultType == _currentGoal.GoalType)
                        {
                                nextStep = action;
                                nextStep.Initialize(_currentGoal.GetGoalValue());
                                nextStep.InitializePreConValue();
                                _plan.Add(nextStep);
                                break;
                        }
                }
                
                // TODO: implement A* for planning

                while (nextStep.PreconditionType != null)
                {
                        foreach (var action in actions)
                        {
                                if (action.ResultType == nextStep.PreconditionType)
                                {
                                        var preconditionValue = nextStep.GetPreconditionValue();
                                        nextStep = action;
                                        nextStep.Initialize(preconditionValue);
                                        nextStep.InitializePreConValue();
                                        _plan.Add(nextStep);
                                        break;
                                }
                        }
                }

                if (Logger.GetLastEntry().Contains("Calculation time"))
                {
                        PerformanceMeter.ResetStopwatch();
                }
                else
                {
                        PerformanceMeter.StopStopwatch(1, false);
                }
        }

        private void ExecutePlan()
        {
                if (changedGoal)
                {
                        Logger.WriteLog("Action: " + _plan.Last().name + " | Goal: " + _currentGoal.name + " [priority: " + _currentGoal.priority + "]");
                        changedGoal = false;
                }
                
                if (_plan.Last().Action())
                {
                        _plan.RemoveAt(_plan.Count -1);
                }
        }
}