using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HandleData
{
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

        private static PlayerData playerData;
        public static PlayerData PlayerData
        {
            get
            {
                if(playerData == null)
                    playerData = new PlayerData();
                return playerData;
            }
        }
    }
}


