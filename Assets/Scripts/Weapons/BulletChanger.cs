using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class BulletChanger : MonoBehaviour
{
    [SerializeField] private List<Bullet> _bullets;
    [SerializeField] private Player _player;

    private Bullet _currentBullet;
    private int _currentBulletNumber = 0;
    private PlayerInput _playerInput;

    public Bullet CurrentBullet => _currentBullet;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.NextBullet.performed += ctx => NextBullet();
        _playerInput.Player.PreviosBullet.performed += ctx => PreviosBullet();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        ChangeBullet(_bullets[_currentBulletNumber]);
    }

    private void ChangeBullet(Bullet bullet)
    {
        _currentBullet = bullet;
    }

    private void NextBullet()
    {
        if (_player.Level >= _player.LevelOfExtraSkills)
        {
            if (_currentBulletNumber == _bullets.Count - 1)
                _currentBulletNumber = 0;
            else
            {
                _currentBulletNumber++;
                ChangeBullet(_bullets[_currentBulletNumber]);
            }
        }
    }

    private void PreviosBullet()
    {
        if (_player.Level >= _player.LevelOfExtraSkills)
        {
            if (_currentBulletNumber == 0)
                _currentBulletNumber = _bullets.Count - 1;
            else
            {
                _currentBulletNumber--;
                ChangeBullet(_bullets[_currentBulletNumber]);
            }
        }
    }
}
