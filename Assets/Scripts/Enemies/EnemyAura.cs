using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAura : MonoBehaviour
{
   [SerializeField] private float _damage = 15f;
   [SerializeField] private float _delayDamage = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            player.StartTakePoisonDamage(_delayDamage, _damage);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            player.StopTakePoisonDamage(_delayDamage, _damage);
    }
}
