using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class PlayerRunner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;


    private const string IsRunning = "IsRunning";

    private Animator _animator;
    private bool _isRunBlocked;

    public float Speed => _speed;
    public bool IsRunBlocked => _isRunBlocked;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run(Vector2 runDirection, bool isMoveBlocked)
    {
       
        if (!isMoveBlocked && runDirection != new Vector2(0, 0))
        {
            float scaledMoveSpeed = _speed * Time.deltaTime;
            transform.Translate(scaledMoveSpeed * runDirection);
            _animator.SetBool(IsRunning, true);
        }
        else
            _animator.SetBool(IsRunning, false);
    }
}
