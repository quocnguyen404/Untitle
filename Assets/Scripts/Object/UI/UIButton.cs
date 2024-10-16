using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform rectTrans;
    [SerializeField] private Image img;

    [Space]
    [Header("Events")]
    public UnityEvent OnButtonClick;
    public UnityEvent OnButtonBeginDrag;
    public UnityEvent OnButtonDrag;
    public UnityEvent OnButtonEndDrag;

    private bool isOn = false;

    private void Awake()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // if(eventData.pointerEnter == gameObject)
        // {
        // }
        Debug.Log("Click: " + gameObject.name);
        OnButtonClick?.Invoke();
        eventData.Use();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag: " + gameObject.name);
        OnButtonBeginDrag?.Invoke();
        eventData.Use();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("Drag: " + gameObject.name);
        OnButtonDrag?.Invoke();
        eventData.Use();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag: " + gameObject.name);
        OnButtonEndDrag?.Invoke();
        eventData.Use();
    }

}
