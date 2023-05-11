using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    
    private BulletChanger _bulletChanger;
    private PlayerInput _playerInput;
    private Vector2 _shotDirection;
    private float _offSet = - 90;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.Shot.performed += ctx => Shot(_bulletChanger.CurrentBullet);
        _bulletChanger = GetComponent<BulletChanger>();
    }

    private void Update()
    {
        SetShotDirection();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public void Shot(Bullet bullet)
    {
        Instantiate(bullet, _shotPoint.position, transform.rotation);
    }

    private void SetShotDirection()
    {
        _shotDirection = _playerInput.Blaster.SetDirection.ReadValue<Vector2>();
        Vector3 difference = Camera.main.ScreenToWorldPoint(_shotDirection) - transform.position;
        float rotateThrowPointZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotateThrowPointZ + _offSet);
    }
}
