using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<UIButton> buttons;

    public void Awake()
    {
        foreach(Transform child in transform)
        {
            UIButton btn = child.GetComponent<UIButton>();
            if(btn != null)
                buttons.Add(btn);
        }
    }
}
