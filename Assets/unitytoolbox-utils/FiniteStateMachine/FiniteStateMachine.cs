namespace UnityToolBox.Utils
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class FiniteStateMachine
    {
        private Dictionary<string, State> states = new Dictionary<string, State>();

        public State CurrentState { get; set; } = null;

        public State CreateState(string name)
        {
            State newState = new State
            {
                Name = name
            };

            if (states.Count == 0)
            {
                CurrentState = newState;
            }

            states[name] = newState;

            return newState;
        }

        public void Update()
        {
            CurrentState.OnUpdate?.Invoke();
        }

        public void TransitionTo(State state)
        {
            CurrentState.OnExit?.Invoke();
            CurrentState = state;
            CurrentState.OnEnter?.Invoke();
        }

        public void TransitionTo(string stateName)
        {
            if (!states.TryGetValue(stateName, out State state))
            {
                Debug.LogFormat("No valid state named {0} for the state machine", stateName);
                return;
            }

            TransitionTo(state);
        }

        public class State
        {
            public Action OnUpdate { get; set; } = null;

            public Action OnEnter { get; set; } = null;

            public Action OnExit { get; set; } = null;

            public string Name { get; set; } = string.Empty;
        }
    }
}
