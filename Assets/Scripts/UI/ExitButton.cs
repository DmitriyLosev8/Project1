using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitButton : MonoBehaviour
{
    public static event UnityAction Clicked;

    public void OnButtonClicked()
    {
        Clicked?.Invoke();
    }
}
