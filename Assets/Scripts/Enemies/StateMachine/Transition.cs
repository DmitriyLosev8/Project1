using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;
    
    protected Player TargetPlayer { get; private set; }

    public State TargetState => _targetState;
    public bool NeedTransit { get; private set; }

    public void Init(Player targetPlayer)
    {
        TargetPlayer = targetPlayer;    
    }

    public void OnEnable()
    {
        NeedTransit = false;
    }
}
