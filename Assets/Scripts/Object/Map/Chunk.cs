using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HandleData;


namespace Object.Map
{
    public class Chunk : MonoBehaviour
    {
        //Chunk size 9x9
        //Tile size 1x0.5
        [SerializeField] private static Tile tilepref;
        private Dictionary<Vector2Int, Entity> entities;

        private Tile[,] tiles;
        private Vector2 origin;
        private static Vector2 tileSize = new Vector2(1.0f, 0.5f);
        [SerializeField] private short width = 9;
        [SerializeField] private short height = 9;

        public void Initilize(int width, int height)
        {
            tiles = new Tile[width, height];

            origin = new Vector2(transform.position.x, transform.position.y + height*tileSize.y/2f);

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    Tile ntile = Instantiate(tilepref, transform);
                    ntile.SetSprite(DataHelper.Sprites.GetSprite("Dirt"));
                    ntile.transform.position = CellToWorld(x, y);
                    tiles[x, y] = ntile;
                }
            }

        }

        public Tile GetTile(Vector2 wPosition)
        {
            Vector2Int cPosition = WorldToCell(wPosition);
            return tiles[cPosition.x, cPosition.y];
        }

        public Vector2 CellToWorld(int row, int col)
        {
            float wX = origin.x + (row - col) * tileSize.x/2f;
            float wY = origin.y - (row + col) * tileSize.y/2f;
            return new Vector2(wX, wY);
        }

        public Vector2Int WorldToCell(Vector2 wPosition)
        {
            int cX = (int)((wPosition.y - origin.y) / tileSize.y + (wPosition.x - origin.x) / tileSize.x);
            int cY = (int)((wPosition.y - origin.y) / tileSize.y - (wPosition.x - origin.x) / tileSize.x);
            return new Vector2Int(cX, cY);
        }
    }
}

