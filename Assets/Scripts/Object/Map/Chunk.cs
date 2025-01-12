using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using System.Xml.Linq;
using System.Data;

namespace Object.Map
{
    public class Chunk : MonoBehaviour
    {
        public static readonly Vector2Int ChunkSize = new Vector2Int(9, 9);
        public Vector2Int index;
        public bool drawRec = false;

        [SerializeField] private Vector2 origin;
        
        [SerializeField] private Vector2Int currentCellPosition;
        [SerializeField] private Vector2Int lastCellPosition;

        private Dictionary<Vector2Int, Entity> entities;
        private Tile[,] tiles;
        private Tile tilepref;

        public void Initilize(Vector2 chunkPosition)
        {
            transform.position = chunkPosition;
            int width = ChunkSize.x;
            int height = ChunkSize.y;
            
            tilepref = DataHelper.Prefabs.GetPrefab<Tile>(Prefab.Tile);
            if(tilepref == null)
                Debug.LogError("Tile prefab is null");

            //initialize chunk
            tiles = new Tile[width, height];
            origin = new Vector2(transform.position.x, transform.position.y);

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    Tile ntile = Instantiate(tilepref, transform);
                    ntile.SetSprite(DataHelper.Sprites.GetSprite("Dirt"));
                    ntile.TileName = "Dirt";
                    ntile.transform.position = CellToWorld(x, y);
                    tiles[x, y] = ntile;
                }
            }
        }

        public void Update()
        {
            if(hovering)
                Hover();
        }

        private void Hover()
        {
            Vector3 mousePosition = GameUtilities.MainCam.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            
            Vector2Int tempPos = WorldToCell(mousePosition);
            bool legal = LegalCellPosition(tempPos);
            if(legal && currentCellPosition != tempPos)
            {
                lastCellPosition = currentCellPosition;
                currentCellPosition = tempPos;
                // Debug.Log("Point cell: " + currentCellPosition);
                if(hoverTile != null)
                    hoverTile.drawRec = false;
                hoverTile = GetTile(currentCellPosition);
                hoverTile.drawRec = true;
                MouseHandler.Instance.MouseIndicator.transform.position = hoverTile.transform.position;
            }
        }

        private Tile hoverTile = null;
        private bool hovering = false;
        public void EnterHover()
        {
            drawRec = true;
            hovering = true;
        }

        public void ExitHover()
        {
            hovering = false;
            drawRec = false;
            if(hoverTile != null)
                hoverTile.drawRec = false;
        }

        public Tile GetTile(Vector2Int cPosition)
        {
            if(!LegalCellPosition(cPosition))
            {
                Debug.LogError("Illegal cell position");
                return null;
            }
            return tiles[cPosition.x, cPosition.y];
        }

        public Tile GetTile(Vector2 wPosition)
        {
            Vector2Int cPosition = WorldToCell(wPosition);
            if(!LegalCellPosition(cPosition))
            {
                Debug.LogError("Illegal cell position");
                return null;
            }
            return tiles[cPosition.x, cPosition.y];
        }

        public Vector2 CellToWorld(int row, int col)
        {
            float wX = origin.x + (row - col) * Tile.TileSize.x/2f;
            float wY = origin.y + (row + col) * Tile.TileSize.y/2f;
            return new Vector2(wX, wY);
        }

        public Vector2Int WorldToCell(Vector2 wPosition)
        {
            float x = (wPosition.y - origin.y) / Tile.TileSize.y + ((wPosition.x - origin.x) / Tile.TileSize.x);
            float y = (wPosition.y - origin.y) / Tile.TileSize.y - ((wPosition.x - origin.x) / Tile.TileSize.x);
            int cX = (int)x;
            int cY = (int)y;
            return new Vector2Int(cX, cY);
        }

        public bool LegalCellPosition(Vector2Int cPosition)
        {
            if(cPosition.x < 0 || cPosition.x >= ChunkSize.x ||
               cPosition.y < 0 || cPosition.y >= ChunkSize.y)
                return false;
            return true;
        }

        private void OnDrawGizmos()
        {
            if(!drawRec) 
                return;
                
            float xTOffset = Tile.TileSize.x;
            float yTOffset = Tile.TileSize.y;
            Vector3 top = CellToWorld(ChunkSize.x - 1, ChunkSize.y - 1);
            top.y += yTOffset/2;
            Vector3 bot = CellToWorld(0, 0);
            bot.y -= yTOffset/2;
            Vector3 right = CellToWorld(ChunkSize.x - 1, 0);
            right.x += xTOffset/2;
            Vector3 left = CellToWorld(0, ChunkSize.y - 1);
            left.x -= xTOffset/2;

            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(top, left);
            Gizmos.DrawLine(top, right);
            Gizmos.DrawLine(bot, left);
            Gizmos.DrawLine(bot, right);
        }
    }
}

