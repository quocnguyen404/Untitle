using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Sprite temp = Resources.Load<Sprite>(string.Format(GameConstant.SPRITE_PATH, spriteName));
            if(temp == null)
            {
                Debug.LogError("Not exist sprite: " + spriteName + " in Resources");
                return null;
            }
            sprites.Add(spriteName, temp);
        }
        return sprites[spriteName];
    }
}
