using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement : MonoBehaviour
{
    protected bool isOn;
    [SerializeField] protected float fadedTime = 0.7f;
    [SerializeField] protected CanvasGroup cvGroup;

    public virtual void Awake()
    {
        TurnOff();
    }
    
    public virtual void TurnOn()
    {
        isOn = true;
    }

    public virtual void TurnOff()
    {
        isOn = false;
    }

    private IEnumerator FadeIn()
    {
        yield return null;
    }


}
