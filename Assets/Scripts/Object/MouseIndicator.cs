using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Data;
using UnityEngine;

namespace Object
{
    public class MouseIndicator : Entity
    {
        public Sprite defaultSprite = null;

        public void Awake()
        {
            defaultSprite = sr.sprite;
        }

        public void DefaultMode()
        {
            SetSprite(defaultSprite);
        }

        public void TileMode()
        {
            SetSprite(DataHelper.Sprites.GetSprite("Indicator"));
        }
    }
}

