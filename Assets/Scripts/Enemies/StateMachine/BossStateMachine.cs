using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Boss))]
public class BossStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _targetPlayer;
    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        _targetPlayer = GetComponent<Boss>().TargetPlayer;
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State firstState) 
    {
        _currentState = firstState;

        if (_currentState != null)
            _currentState.Enter(_targetPlayer);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_targetPlayer);
    }
}
