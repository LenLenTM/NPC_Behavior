using System;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
        public BaseState CurrentState;

        private void Start()
        {
                CurrentState = GetInitialState();
                if (CurrentState != null)
                {
                        CurrentState.Enter();
                }
        }

        private void Update()
        {
                if (CurrentState != null)
                {
                        CurrentState.Update();
                }
        }

        public void ChangeState(BaseState newState)
        {
                CurrentState.Exit();
                CurrentState = newState;
                CurrentState.Enter();
        }

        protected virtual BaseState GetInitialState()
        {
                return null;
        }
}