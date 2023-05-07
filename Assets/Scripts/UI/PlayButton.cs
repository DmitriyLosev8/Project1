using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayButton : MonoBehaviour
{
    public static event UnityAction PlayButtonClicked;
    
    public void OnPlayButtonClicked()
    {
        PlayButtonClicked?.Invoke();
    }
}
