using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Object.Map
{
    public class Tile : MonoBehaviour
    {
        private Entity[] children;

        public static readonly Vector2 TileSize = new Vector2(1f, 0.5f);
        public SpriteRenderer sr;

        public bool drawRec = false;
        public string TileName;

        public void SetSprite(Sprite sprite)
        {
            sr.sprite = sprite;
        }

        public void OnDrawGizmos()
        {
            if(!drawRec) 
                return;

            Vector3 top = new Vector3(transform.position.x, transform.position.y + TileSize.y/2, transform.position.z);
            Vector3 bot = new Vector3(transform.position.x, transform.position.y - TileSize.y/2, transform.position.z);
            Vector3 right = new Vector3(transform.position.x + TileSize.x/2, transform.position.y, transform.position.z);
            Vector3 left = new Vector3(transform.position.x - TileSize.x/2, transform.position.y, transform.position.z);

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(top, left);
            Gizmos.DrawLine(top, right);
            Gizmos.DrawLine(bot, left);
            Gizmos.DrawLine(bot, right);
        }
    }
}

