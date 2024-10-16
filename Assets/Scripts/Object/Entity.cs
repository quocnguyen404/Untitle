using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public string Name => name;
    [SerializeField] private string _name;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private static readonly Vector3 offSet = new Vector3(0, 0.25f, 0);

    public void SetGridPosition(Vector3 position)
    {
        // Debug.Log("ori: " + transform.position);
        transform.position = position + offSet;
    }

    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    public void SetSpriteOrder(int order)
    {
        spriteRenderer.sortingOrder = order;
    }
}
