using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BulletChanger))]
public class Player : MonoBehaviour
{
    [SerializeField] private BulletChanger _bulletChanger;
    [SerializeField] private Blaster _blaster;
    [SerializeField] private float _health;
    [SerializeField] private ParticleSystem _effectOfDying;

    private PlayerInput _playerInput;
    private int _level = 0;
    private bool _poisonJob;
    private int _coins;
    private float _positionYToSelfDesttoy = -30f;
    private bool _isLookRight;
    private int _levelOfExtraSkills = 3;

    public int Level => _level;
    public float Health => _health;
    public bool IsLookRight =>_isLookRight;
    public int LevelOfExtraSkills => _levelOfExtraSkills;

    public static event UnityAction Died;
    public static event UnityAction CameInRockZone;
    public static event UnityAction LevelChangedToNext;
    public static event UnityAction CameInEnemySpitZone;

    public event UnityAction<float> HealthChanged;
    public event UnityAction<int> CoinAdded; 
    
    public bool IsInWater = false;

    private void Start()
    {     
        _level = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (transform.position.y <= _positionYToSelfDesttoy)
            Die();
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.Shot.performed += ctx => OnShot(_bulletChanger.CurrentBullet);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Die()
    {
        Instantiate(_effectOfDying, transform.position, Quaternion.identity);
        Died?.Invoke();
        Destroy(gameObject);       
    }

    private IEnumerator TakePoisonDamage(float delayDamage, float damage)
    {
        var waitForDelay = new WaitForSecondsRealtime(delayDamage);

        while (_poisonJob)
        {
            yield return waitForDelay;
           
            _health -= damage;
            HealthChanged?.Invoke(_health);

            if (_health <= 0)
                Die();  
        } 
    }

    private void OnShot(Bullet bullet)
    {
        _blaster.Shot(bullet);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out NextLevelZone nextLevelZone))
        {
            _level++;
            LevelChangedToNext?.Invoke();
        }

        if (collision.gameObject.TryGetComponent(out RockEventZone rockEventZone))
            CameInRockZone?.Invoke();
        
        if(collision.gameObject.TryGetComponent(out Coin coin))
        {
            AddCoin();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out EnemyAttackZone enemySpitZone))
            CameInEnemySpitZone?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void StartTakePoisonDamage(float delayDamage, float damage)
    {
        _poisonJob = true;
        StartCoroutine(TakePoisonDamage(delayDamage, damage));
    }

    public void StopTakePoisonDamage(float delayDamage, float damage)
    {
        _poisonJob = false;
        StopCoroutine(TakePoisonDamage(delayDamage, damage));
    }

    public void DetermineOfSideOfLook(bool isLookRight)
    {
        _isLookRight = isLookRight;
    }

    public void AddCoin()
    {
        _coins++;
        CoinAdded?.Invoke(_coins);
    }
}
