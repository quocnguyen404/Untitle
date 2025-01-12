using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Object
{
    public class Entity : MonoBehaviour
    {
        public string Name => _name;
        [SerializeField] protected string _name;
        [SerializeField] protected SpriteRenderer sr;
    
        public void SetSprite(Sprite sprite)
        {
            sr.sprite = sprite;
        }
    }
}

