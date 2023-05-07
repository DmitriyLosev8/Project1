using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private EnemySpittle _enemySpittleTemplate;
    [SerializeField] private Transform _spittleSpawnPoint;
    [SerializeField] private float _delayOfSpit;
    [SerializeField] private int _id;

    private Animator _animator;
    private float _timeBetweenSpit = 5;
    private float _patrolDistance;
    private float _speed;
    private Vector3 _targetPosition;
    private Vector3 _leftPatrolPoint;
    private Vector3 _rightPatrolPoint;

    public int Id => _id;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

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

    private void Spit(EnemyAttackZone enemySpitZone)
    {
            if (_timeBetweenSpit <= 0)
            {
                Instantiate(_enemySpittleTemplate, _spittleSpawnPoint.position, _spittleSpawnPoint.transform.rotation);
                _timeBetweenSpit = _delayOfSpit;
            }
            else
            _timeBetweenSpit -= Time.deltaTime;
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

    private void Die()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
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

    private void SetStartPatrolPositions()
    {
        _leftPatrolPoint = transform.position;
        _targetPosition = new Vector3(transform.position.x + _patrolDistance, transform.position.y, transform.position.z);
        _rightPatrolPoint = _targetPosition;
    }

    private void TryToAddExtraSpeed()
    {
        int lowBorder = 2;
        int highBorder = 6;
        int nummerOfCatchValue = 5;
        int chanceToAdd = Random.Range(lowBorder, highBorder);
        float priviosValueOfSpeed = _speed;

        if (chanceToAdd == nummerOfCatchValue)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyAttackZone enemySpitZone))
            StartCoroutine(TryToSpit(enemySpitZone));
    }    
    
    private IEnumerator TryToSpit(EnemyAttackZone enemySpitZone)
    {
        while (true)
        {
            if (enemySpitZone.IsEnemyNeedToSpit)
                Spit(enemySpitZone);
                
            _animator.SetBool("IsAttack", enemySpitZone.IsEnemyNeedToSpit);
            yield return null;  
        }
    }

    public void SetSpittleSpawnPointRotation(Quaternion direction)
    {
        _spittleSpawnPoint.transform.rotation = direction;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        Die();
    }
}
