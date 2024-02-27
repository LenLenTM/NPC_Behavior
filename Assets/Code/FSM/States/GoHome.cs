using UnityEngine;

public class GoHome : BaseState
{
        public GoHome(FSM_Entity stateMachine) : base("GoHome", stateMachine){}

        public override void Enter()
        {
                base.Enter();
        }

        public override void Update()
        {
                base.Update();
                
                var check = TransitionChecker.CheckTransition(_stateMachine);
                if (check.transition)
                {
                        _stateMachine.ChangeState(check.state);
                }
                else
                {
                        _stateMachine.transform.position = Vector3.MoveTowards
                        (
                                _stateMachine.transform.position,
                                World.Locations.Find(l => l.Typ == Locations.Home).transform.position,
                                World.Speed * Time.deltaTime * 2
                        );
                }
        }
}