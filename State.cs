using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StateMachines
{
    public class State : MonoBehaviour
    {
        public enum OverrideBehaviour { AllowAllExcept, DisallowAllExcept }
        
        [Header("Behaviour")]
        [SerializeField] private AnyStateTransitionManager anyStateTransitionManager;
        [SerializeField] private OverrideBehaviour overrideBehaviour;
        [SerializeField] private List<AnyStateTransition> exceptions;

        protected virtual void Awake()
        {
            enabled = false;
        }

        protected virtual void OnEnable()
        {
            OverrideAnyStateTransitions(false);
        }

        protected virtual void OnDisable()
        {
            OverrideAnyStateTransitions(true);
        }

        private void OverrideAnyStateTransitions(bool enabled)
        {
            switch (overrideBehaviour)
            {
                case OverrideBehaviour.AllowAllExcept:
                    foreach (var anyStateTransition in exceptions)
                    {
                        anyStateTransition.enabled = enabled;
                    }
                    break;
                case OverrideBehaviour.DisallowAllExcept:
                    foreach (var anyStateTransition in anyStateTransitionManager.AnyStateTransitions.Except(exceptions))
                    {
                        anyStateTransition.enabled = enabled;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}