using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Object.Map
{
    public class Tile : MonoBehaviour
    {
        public SpriteRenderer sr;
        public string TileName;

        public void SetSprite(Sprite sprite)
        {
            sr.sprite = sprite;
        }
    }
}

