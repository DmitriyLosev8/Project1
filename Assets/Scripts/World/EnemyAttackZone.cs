using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackZone : MonoBehaviour
{
    private bool _isEnemyNeedToSpit;

    public bool IsEnemyNeedToSpit => _isEnemyNeedToSpit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
                _isEnemyNeedToSpit = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            _isEnemyNeedToSpit = false;
    }
}