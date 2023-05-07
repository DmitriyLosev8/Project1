using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private PlayerInput _playerInput;
    
    public static UnityAction LoadMainMenuButtonClicked;
    public static bool IsPaused;

    private void Start()
    {
        _pausePanel.SetActive(false);    
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.UI.PauseButton.performed += ctx => PauseGame();
    }

    public void PauseGame()
    {
        if(_pausePanel != null)
        {
            _pausePanel.SetActive(true);
            IsPaused = true;
            Time.timeScale = 0;
        }  
    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1;
    }

    public void OnLoadMainMenuButtonClicked()
    {
        Time.timeScale = 1;
        LoadMainMenuButtonClicked?.Invoke();
    }
}
