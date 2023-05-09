using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionEffect;

    private float _damage = 70f;
    private float _positionYToSelfDesttoy = -40f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out RockIgnoreSurface rockIgnoreSurface))
        {
            if (collision.gameObject.TryGetComponent(out Player player))
                player.TakeDamage(_damage);

            if (collision.gameObject.TryGetComponent(out Water water))
                Destroy(gameObject);

            _damage = 30f;
            Instantiate(_collisionEffect, transform.position, Quaternion.identity);
            Debug.Log(collision.gameObject.name);
        }
    }
            
    private void Update()
    {
        if (transform.position.y <= _positionYToSelfDesttoy)
            Destroy(gameObject);
    }
}
