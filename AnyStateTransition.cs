using UnityEngine;
using UnityEngine.Events;

namespace StateMachines
{
    public abstract class AnyStateTransition : MonoBehaviour
    {
        [SerializeField] protected UnityEvent transitionEvent = new();
    }
}