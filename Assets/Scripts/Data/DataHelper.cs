using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHelper
{
    private static Sprites sprites;
    public static Sprites Sprites
    {
        get
        {
            if(sprites == null)
                sprites = new Sprites();
            return sprites;
        }
    }
    
}
