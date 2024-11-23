using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Object
{
    public class Entity : MonoBehaviour
    {
        public string Name => _name;
        [SerializeField] private string _name;
        [SerializeField] private SpriteRenderer spriteRenderer;
    }
}

