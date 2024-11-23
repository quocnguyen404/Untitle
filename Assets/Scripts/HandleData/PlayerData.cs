using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HandleData
{
    public class PlayerData
    {
        private int gold;
        public int Gold => gold;

        public PlayerData()
        {
            gold = 100;
        }
    }
}

