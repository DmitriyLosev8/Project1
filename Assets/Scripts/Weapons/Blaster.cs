using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    
    private PlayerInput _playerInput;
    private Vector2 _shotDirection;
    private float _offSet = - 90;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
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

    public void Shot(Bullet weapon)
    {
        Instantiate(weapon, _shotPoint.position, transform.rotation);
    }

    private void SetShotDirection()
    {
        _shotDirection = _playerInput.ThrowingHand.SetThowDirection.ReadValue<Vector2>();
        Vector3 difference = Camera.main.ScreenToWorldPoint(_shotDirection) - transform.position;
        float rotateThrowPointZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotateThrowPointZ + _offSet);
    }
}
