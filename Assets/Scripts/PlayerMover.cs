using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;

    private Animator _animator;
    private bool _isMoveBlocked;

    private const string IsRunning = "IsRunning";

    public float Speed => _speed;
    public bool IsMoveBlocked => _isMoveBlocked;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(Vector2 moveDirection, bool isMoveBlocked)
    {
       
        if (!isMoveBlocked && moveDirection != new Vector2(0, 0))
        {
            float scaledMoveSpeed = _speed * Time.deltaTime;
            transform.Translate(scaledMoveSpeed * moveDirection);
            _animator.SetBool(IsRunning, true);
        }
        else
            _animator.SetBool(IsRunning, false);
    }
}
