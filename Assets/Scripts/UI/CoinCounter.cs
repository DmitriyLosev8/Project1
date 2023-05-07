using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _coinCounter;

    private void Start()
    {
        _coinCounter.text = "0";
    }

    private void OnEnable()
    {
        _player.CoinAdded += OnCoinAdded;
    }

    private void OnDisable()
    {
        _player.CoinAdded -= OnCoinAdded;
    }

    private void OnCoinAdded(int coins)
    {
        _coinCounter.text = coins.ToString();
    }
}
