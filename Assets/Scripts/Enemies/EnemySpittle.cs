using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpittle : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _effect;
    
    private float _lifeTime = 40;

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        Destroyer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    private void Destroyer()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
