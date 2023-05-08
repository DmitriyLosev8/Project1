using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private float _jumpForse;
    [SerializeField] private Transform _readyToJumpChecker;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private LayerMask _wall;

    private PlayerInput _playerInput;
    private Rigidbody2D _playersRigidbody;
    private Vector2 _moveDirection;
    private int _currentJumpCount = 0;
    private int _maxJumpCount = 2;
    private float _maxTimeWallJump = 1f;
    private float _currentTimeWallJump;
    private bool _isLookRight = true;
    private bool _isMoveBlocked;
    private bool _isGrounded;
    private bool _isOnWall = false;
    private float _readyToJumpCheckerRadius = 0.2f;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.Jump.performed += ctx => OnJump();
        _playerInput.Player.WallJump.performed += ctx => OnWallJump();
    } 
   
    private void Start()
    {
        _playersRigidbody = _player.GetComponent<Rigidbody2D>();
    }
   
    private void Update()
    {
        ReadyToJumpCheker();
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
        _playerMover.Move(_moveDirection, _isMoveBlocked);
        Reflect();
        MoveBlockedDisabler();

        if (_player.IsInWater)
            Swim();
    }
   
    private void ReadyToJumpCheker()
    {
        _isGrounded = Physics2D.OverlapCircle(_readyToJumpChecker.position, 
            _readyToJumpCheckerRadius, _ground);
        _isOnWall = Physics2D.OverlapCircle(_readyToJumpChecker.position, 
            _readyToJumpCheckerRadius, _wall);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Reflect()
    {
        if ((_moveDirection.x > 0 && !_isLookRight) || (_moveDirection.x < 0 && _isLookRight))
        { 
            transform.localScale *= new Vector2(-1, 1);
            _isLookRight = !_isLookRight;
        }
        _player.DetermineOfSideOfLook(_isLookRight);
    }

    private void Swim()
    {
       _isMoveBlocked = true;
        float swimSpeed = (_playerMover.Speed - 1) * Time.deltaTime;
        transform.Translate(swimSpeed * Vector2.right);
    }

    private void OnJump()
    {
        if (_isGrounded || (++_currentJumpCount < _maxJumpCount && _player.Level >= _player.LevelOfExtraSkills))
            _playersRigidbody.AddForce(Vector2.up * _jumpForse);

        if (_isGrounded)
            _currentJumpCount = 0;
    }
    
    private void OnWallJump()
    {
        Vector2 wallJumpAngle; 
        
        if(_currentJumpCount == 1)
        {
            wallJumpAngle = new Vector2(6.5f, 3f);
            WallJump(wallJumpAngle);
        }

        if (_currentJumpCount == 2)
        {
            wallJumpAngle = new Vector2(10f, 10f);
            WallJump(wallJumpAngle);
        }
    }
   
    private void WallJump(Vector2 wallJumpAngle)
    {
        if (_isOnWall && !_isGrounded)
        {
            _isMoveBlocked = true;
            _moveDirection.x = 0;

            transform.localScale *= new Vector2(-1, 1);
            _isLookRight = !_isLookRight;
            
            if(_player.Level < _player.LevelOfExtraSkills)
            _playersRigidbody.velocity = 
                    new Vector2(transform.localScale.x * wallJumpAngle.x * 1.1f, wallJumpAngle.y * 3.8f);
            else
            _playersRigidbody.velocity = 
                    new Vector2(transform.localScale.x * wallJumpAngle.x, wallJumpAngle.y);  
        }
    }

    private void MoveBlockedDisabler()
    {
        if ((_isMoveBlocked && (_currentTimeWallJump += Time.deltaTime) > _maxTimeWallJump) || _isGrounded)
        {
            _isMoveBlocked = false;
            _currentTimeWallJump = 0;
        }
    }
}
