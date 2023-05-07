using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _patrolDistance;

    private Vector3 _targetPosition;
    private Vector3 _leftPoint;
    private Vector3 _rightPoint;

    private void Start()
    {
        _leftPoint = transform.position;
        _targetPosition = new Vector3(transform.position.x + _patrolDistance, transform.position.y, transform.position.z);
        _rightPoint = _targetPosition;
    }

    private void Update()
    {   
        if(transform.position == _rightPoint)
            _targetPosition = _leftPoint;

        if (transform.position == _leftPoint)
            _targetPosition = _rightPoint;

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }   
}
