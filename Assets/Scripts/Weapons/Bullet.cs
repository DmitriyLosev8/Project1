using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet: MonoBehaviour 
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _effect;

    private float _lifeTime = 8f;
 
    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BulletDestroyer bulletDestroyer))
        {
            Destroy(gameObject);
            Instantiate(_effect, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damage);

        if(collision.gameObject.TryGetComponent(out Boss boss))
            boss.TakeDamage(_damage);
    }
}
