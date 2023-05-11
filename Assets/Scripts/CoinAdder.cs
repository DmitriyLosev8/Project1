using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinAdder : MonoBehaviour
{
    private int _coins;

    public event UnityAction<int> CoinAdded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            AddCoin();
            Destroy(collision.gameObject);
        }
    }

    public void AddCoin()
    {
        _coins++;
        CoinAdded?.Invoke(_coins);
    }
}
