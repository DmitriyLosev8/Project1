using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Boss : MonoBehaviour
{
    [SerializeField] private Player _targetPlayer;
    [SerializeField] private float _health = 200;
    [SerializeField] private float _damage;
    [SerializeField] private EnemySpittle _spittleTemplate;
    [SerializeField] private Transform _spittleSpawnPoint;
    [SerializeField] private float _delayOfSpit;

    private Animator _animator;
    private float _delayOfTeleport = 5f;
    private float _speedOfTeleport = 500;
    private float _timeBetweenSpit = 5;
    private int _offSet = -90;
    private bool _readyToAttack;
   
    private const string IsAttack = "IsAttack";

    public Player TargetPlayer => _targetPlayer;
   
    public static event UnityAction Died;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(Teleport());
    }

    private void Update()
    {
        TryToAttack();
        SetSpitDirection();     
        Spit(); 
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        
        if(_health <= 0)
        {
            Die();
        }     
    }

    private void Die()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }

    private IEnumerator Teleport()  
    {
        float offSetOfTeleport = 3f;
        Vector3 PointToTeleport;
        var delay = new WaitForSeconds(_delayOfTeleport);

        while (true)
        {
            _animator.SetBool(IsAttack, _readyToAttack);
            
            if (_readyToAttack)
            {
                if (_targetPlayer.IsLookRight)
                    PointToTeleport = new Vector3(_targetPlayer.transform.position.x + offSetOfTeleport, 
                        _targetPlayer.transform.position.y, _targetPlayer.transform.position.z);
                else
                    PointToTeleport = new Vector3(_targetPlayer.transform.position.x - offSetOfTeleport,
                        _targetPlayer.transform.position.y, _targetPlayer.transform.position.z);

                transform.position = Vector3.MoveTowards(transform.position, PointToTeleport, _speedOfTeleport);
                           
                yield return delay;
            }     
            yield return null;
        }  
    }

    private void Spit()
    {
        if (_readyToAttack)
        {    
            if (_timeBetweenSpit <= 0)
            {
                Instantiate(_spittleTemplate, _spittleSpawnPoint.position, _spittleSpawnPoint.transform.rotation);
                _timeBetweenSpit = _delayOfSpit;
            }
            else
                _timeBetweenSpit -= Time.deltaTime;
        }
    }

    private void SetSpitDirection()
    {
        Vector3 difference = DetermineDistanceToPlayer();
        float rotateSpawnPointZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        _spittleSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, rotateSpawnPointZ + _offSet);
    }

    private Vector3 DetermineDistanceToPlayer()
    {
        Vector3 distanse = _targetPlayer.transform.position - transform.position;
        return distanse;
    }

    private void TryToAttack()
    {
        Vector3 difference = DetermineDistanceToPlayer();
        float distanceToAttack = 12;

        if (difference.x < distanceToAttack && difference.y < distanceToAttack && difference.z < distanceToAttack)
            _readyToAttack = true;
        else
            _readyToAttack = false;
    }
}

