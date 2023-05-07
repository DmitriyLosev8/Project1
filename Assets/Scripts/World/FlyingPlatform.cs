using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatform : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Transform _startPoint;

    private Vector3 _targetPosition;

    private void Start()
    {
        transform.position = _startPoint.transform.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position == _startPoint.transform.position)
            _targetPosition = _targetPoint.transform.position;

        if (transform.position == _targetPoint.transform.position)
            _targetPosition = _startPoint.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
}
