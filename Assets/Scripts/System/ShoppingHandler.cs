using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingHandler : MonoBehaviour
{
    [SerializeField] private MouseIndicator mouseIndicator;
    [SerializeField] private float IndicatorDelay = 0.2f;
    private float delayCount = 0;
    private String buyingName = "";

    public event Action<string> OnRelease;

    public void Initialize()
    {
        mouseIndicator.Default();
        mouseIndicator.SetActive(false);
    }
    
    public void HandleMouseIndicator(bool isInGrid,Vector3 wPosition, Vector3 mPosition)
    {
        delayCount += Time.deltaTime;
        if(delayCount >= IndicatorDelay)
        {
            if(isInGrid)
            {
                mouseIndicator.SetActive(true);
                mouseIndicator.SetGridPosition(wPosition);
                delayCount = 0f;
            }
            else
            {
                mouseIndicator.SetPosition(mPosition);
                mouseIndicator.SetActive(false);
                if(buyingName != "")
                    mouseIndicator.SetActive(true);
            }
        }
    }

    //Call when drag shopping button
    public void HandleBeginDrag(string entityName)
    {
        //Todo set sprite
        mouseIndicator.SetSprite(DataHelper.Sprites.GetSprite(entityName));
        buyingName = entityName;
        Debug.Log("Buy: " + entityName);
    }

    //Call when end drag shopping button
    public void HandleEndDrag()
    {
        OnRelease?.Invoke(buyingName);
        mouseIndicator.Default();
        buyingName = "";
        Debug.Log("Release");
    }
}
