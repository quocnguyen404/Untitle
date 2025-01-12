using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class Sprites
    {
        private Dictionary<string, Sprite> sprites;

        public Sprites()
        {
            Sprite[] aSprite = Resources.LoadAll<Sprite>("Sprites");
            sprites = new Dictionary<string, Sprite>(aSprite.Length);
            foreach(Sprite sprite in aSprite)
            {
                Debug.Log("Load sprite: " + sprite.name);
                sprites.Add(sprite.name, sprite);
            }
        }

        public Sprite GetSprite(string spriteName)
        {
            if(!sprites.ContainsKey(spriteName))
            {
                Sprite sprite = Resources.Load<Sprite>(string.Format(GameConstant.SPRITE_PATH, spriteName));
                if(sprite == null)
                    return null;
                sprites.Add(spriteName, sprite);
            }
            return sprites[spriteName];
        }
    }
}

