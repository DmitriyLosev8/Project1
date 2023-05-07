using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;

    private void OnEnable()
    {
        Boss.Died += onBossDied;
    }

    private void OnDisable()
    {
        Boss.Died -= onBossDied;
    }

    private void onBossDied()
    {
        _winPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
