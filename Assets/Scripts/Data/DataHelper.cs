using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public static class DataHelper
    {
        private static Sprites sprites = null;
        public static Sprites Sprites
        {
            get
            {
                if(sprites == null)
                    sprites = new Sprites();
                return sprites;
            }
        }

        private static Prefabs prefabs = null;
        public static Prefabs Prefabs
        {
            get
            {
                if(prefabs == null)
                    prefabs = new Prefabs();
                return prefabs;
            }
        }
    }
}


