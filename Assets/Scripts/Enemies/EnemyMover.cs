using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private Vector3 _targetPosition;
    private Vector3 _leftPatrolPoint;
    private Vector3 _rightPatrolPoint;
    private float _patrolDistance;
    private float _speed;

    private void Start()
    {
        SetPatrolDistance();
        SetStartPatrolPositions();
        SetPatrolSpeed();
        TryToAddExtraSpeed();
    }

    private void Update()
    {
        Patrol();
    }

    private void SetStartPatrolPositions()
    {
        _leftPatrolPoint = transform.position;
        _targetPosition = new Vector3(transform.position.x + _patrolDistance, transform.position.y, transform.position.z);
        _rightPatrolPoint = _targetPosition;
    }

    private void SetPatrolSpeed()
    {
        float minSpeed = 0.5f;
        float maxSpeed = 2f;

        _speed = Random.Range(minSpeed, maxSpeed);
    }

    private void SetPatrolDistance()
    {
        float minDistance = 0.5f;
        float maxDistance = 1.2f;

        _patrolDistance = Random.Range(minDistance, maxDistance);
    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position == _rightPatrolPoint)
            _targetPosition = _leftPatrolPoint;

        if (transform.position == _leftPatrolPoint)
            _targetPosition = _rightPatrolPoint;

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    private void TryToAddExtraSpeed()
    {
        int lowBorder = 2;
        int highBorder = 6;
        int numberOfCatchValue = 5;
        int chanceToAdd = Random.Range(lowBorder, highBorder);
        float priviosValueOfSpeed = _speed;

        if (chanceToAdd == numberOfCatchValue)
            StartCoroutine(SetExtraSpeed(priviosValueOfSpeed));
    }

    private IEnumerator SetExtraSpeed(float priviosValueOfSpeed)
    {
        int minValueOfDelay = 6;
        int maxValueOfDelay = 15;
        int delay = Random.Range(minValueOfDelay, maxValueOfDelay);
        var waitForDelay = new WaitForSeconds(delay);
        var workTime = new WaitForSeconds(0.35f);
        float increasedValueOfSpeed = 10f;

        while (true)
        {
            _speed = increasedValueOfSpeed;
            yield return workTime;
            _speed = priviosValueOfSpeed;
            yield return waitForDelay;
        }
    }
}
