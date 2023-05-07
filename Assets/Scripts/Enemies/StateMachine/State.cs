using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Player TargetPlayer { get; private set; }

    public void Enter(Player targetPlayer)
    {
        if(enabled == false)
        {
            TargetPlayer = targetPlayer;
            enabled = true;
        }

        foreach (var transition in _transitions)
        {
            transition.enabled = true;
            transition.Init(TargetPlayer);
        }
    }

    public void Exit()
    {
        if(enabled == true)
        {
            foreach(var transition in _transitions)
                transition.enabled = false;
            
            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach(var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }
        return null;
    }

}
