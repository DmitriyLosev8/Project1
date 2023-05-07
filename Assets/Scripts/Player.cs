using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Bullet> _bullets;
    [SerializeField] private Blaster _blaster;
    [SerializeField] private float _health;
    [SerializeField] private ParticleSystem _effectOfDying;

    private int _level = 0;
    private Bullet _currentBullet;
    private int _currentBulletNumber = 0; 
    private Animator _animator;
    private PlayerInput _playerInput;
    private bool _poisonJob;
    private int _coins;
    private float _positionYToSelfDesttoy = -30f;
    private bool _isLookRight;

    public int Level => _level;
    public float Health => _health;
    public bool IsLookRight =>_isLookRight;

    public  UnityAction<float> HealthChanged;
    public UnityAction<int> CountOfCoinsChanged;
    public static event UnityAction Died;
    public static event UnityAction CameInRockZone;
    public static event UnityAction LevelChangedToNext;
    public event UnityAction<int> CoinAdded; 
    public static event UnityAction CameInEnemySpitZone;
    public bool IsInWater = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        ChangeBullet(_bullets[_currentBulletNumber]);
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
        _playerInput.Player.Shot.performed += ctx => OnShot(_currentBullet);
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

    private void ChangeBullet(Bullet bullet)
    {
        _currentBullet = bullet;
    }

    private void OnShot(Bullet bullet)
    {
        bullet = _currentBullet;
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

    public void NextBullet()
    {
        if (_level >= 3)
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

    public void PreviosBullet()
    {
        if (_level >= 3)
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
