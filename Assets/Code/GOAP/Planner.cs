using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Planner
{
        private List<BaseAction> _plan; // stores the plan for execution and checking the last link in the plan if it still fulfills the current goal

        private BaseGoal _currentGoal = null;
        
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
                _plan = new List<BaseAction>();
                BaseAction nextStep = null;

                foreach (var action in actions)
                {
                        if (action.ResultType == _currentGoal.GoalType)
                        {
                                Debug.Log(_currentGoal.name);
                                Debug.Log(action);
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
        }

        private void ExecutePlan()
        {
                if (_plan.Last().Action())
                {
                        _plan.RemoveAt(_plan.Count -1);
                }
        }
}