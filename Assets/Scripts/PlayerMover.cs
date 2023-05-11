using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerRunner))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerRunner _playerRunner;
    [SerializeField] private float _jumpForse;
    [SerializeField] private Transform _readyToJumpChecker;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private LayerMask _wall;

    private PlayerInput _playerInput;
    private Rigidbody2D _playersRigidbody;
    private Vector2 _runDirection;
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
        _runDirection = _playerInput.Player.Run.ReadValue<Vector2>();
        _playerRunner.Run(_runDirection, _isMoveBlocked);
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
        int numberOfChangeScale = 1;

        if ((_runDirection.x > 0 && !_isLookRight) || (_runDirection.x < 0 && _isLookRight))
        { 
            transform.localScale *= new Vector2(-numberOfChangeScale, numberOfChangeScale);
            _isLookRight = !_isLookRight;
        }
        _player.DetermineOfSideOfLook(_isLookRight);
    }

    private void Swim()
    {
        int numberOfChangeSpeed = 1;
        _isMoveBlocked = true;
        float swimSpeed = (_playerRunner.Speed - numberOfChangeSpeed) * Time.deltaTime;
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
        float numberOfChangeAngleX;
        float numberOfChangeAngleY;

        if (_currentJumpCount == 1)
        {
            numberOfChangeAngleX = 6.5f;
            numberOfChangeAngleY = 3f;
            wallJumpAngle = new Vector2(numberOfChangeAngleX, numberOfChangeAngleY);
            WallJump(wallJumpAngle);
        }

        if (_currentJumpCount == 2)
        {
            numberOfChangeAngleX = 10f;
            numberOfChangeAngleY = 10f;
            wallJumpAngle = new Vector2(numberOfChangeAngleX, numberOfChangeAngleY);
            WallJump(wallJumpAngle);
        }
    }
   
    private void WallJump(Vector2 wallJumpAngle)
    {
        int numberOfChangeSpeed = 1;
        float numberOfChangeAngleX = 1.1f;
        float numberOfChangeAngleY = 3.8f;

        if (_isOnWall && !_isGrounded)
        {
            _isMoveBlocked = true;
            _runDirection.x = 0;

            transform.localScale *= new Vector2(-numberOfChangeSpeed, numberOfChangeSpeed);
            _isLookRight = !_isLookRight;
            
            if(_player.Level < _player.LevelOfExtraSkills)
            _playersRigidbody.velocity = 
                    new Vector2(transform.localScale.x * wallJumpAngle.x * numberOfChangeAngleX, wallJumpAngle.y * numberOfChangeAngleY);
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
