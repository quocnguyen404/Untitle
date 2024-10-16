using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseIndicator : Entity
{
    [SerializeField] private Sprite defaultSprite;

    public void Default()
    {
        SetSprite(defaultSprite);
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
