using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private float _damage = 10f;
    private float _delayDamage = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.IsInWater = true;
            player.StartTakePoisonDamage(_delayDamage, _damage);
        }
    }
            
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.IsInWater = false;
            player.StopTakePoisonDamage(_delayDamage, _damage);
        }
    }        
}
