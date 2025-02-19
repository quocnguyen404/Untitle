using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object.Map;
using Data;
using System;

public class MapManager : MonoBehaviour
{
    //chunk size = 9x9
    [SerializeField] private Vector2 origin;
    [SerializeField] private Vector2Int chunkNum = new Vector2Int(1, 1);
    [Space]
    [Header("Chunk handle")]
    [SerializeField] private Vector3 mousePosition;
    [SerializeField] private Vector2 relativeMousePos;
    [SerializeField] private Vector2Int currentChunkPos;
    [SerializeField] private Vector2Int lastChunkPos;
    

    private Chunk[,] chunks;
    private Chunk chunkpref;
    private Vector2 mapUnit = new Vector2(Chunk.ChunkSize.x * Tile.TileSize.x, Chunk.ChunkSize.y * Tile.TileSize.y);
    
    
    public bool drawRect = true;

    public Vector2Int ChunkNum => chunkNum;
    
    public void Initialize()
    {
        transform.position = new Vector3(transform.position. x, -mapUnit.y * chunkNum.y / 2f);

        chunks = new Chunk[chunkNum.x, chunkNum.y];
        origin = new Vector2(transform.position.x, transform.position.y);
        
        chunkpref = GameConfigure.Prefabs.GetPrefab<Chunk>(Prefab.Chunk);
        if(chunkpref == null)
            Debug.LogError("Chunk prefab is null");
        
        //x row, y col
        for(int x = chunkNum.x - 1; x >= 0; x--)
        {
            for(int y = chunkNum.y - 1; y >= 0; y--)
            {
                Chunk nChunk = Instantiate(chunkpref, transform);
                nChunk.Initilize(ChunkToWorld(x, y));
                nChunk.index = new Vector2Int(x, y);
                nChunk.drawRec = drawRect;
                chunks[x, y] = nChunk;
            }
        }
    }

    private Chunk hoverChunk = null;
    public void Update()
    {
        mousePosition = GameUtilities.MainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        ChunkHover();
    }

    private bool haveExit = true;
    private void ChunkHover()
    {
        Vector2Int tempPos = WorldToChunk(mousePosition);
        bool legal = LegalChunkPosition(tempPos.x, tempPos.y);

        if(!legal)
        {
            MouseHandler.Instance.MouseIndicator.transform.position = mousePosition;
            if(hoverChunk != null)
                hoverChunk.ExitHover();
            hoverChunk = null;
            haveExit = true;
            MouseHandler.Instance.MouseIndicator.DefaultMode();
            return;
        }

        if(legal && (haveExit || currentChunkPos != tempPos))
        {
            haveExit = false;
            lastChunkPos = currentChunkPos;
            currentChunkPos = tempPos;
            // Debug.Log("Point to chunk" + GetChunk(currentChunkPos).index);

            MouseHandler.Instance.MouseIndicator.TileMode();
            if(hoverChunk != null)
                hoverChunk.ExitHover();
            hoverChunk = GetChunk(currentChunkPos);
            hoverChunk.EnterHover();
        }
    }

    public Chunk GetChunk(Vector2Int cPosition)
    {
        if(!LegalChunkPosition(cPosition.x , cPosition.y))
        {
            Debug.LogError("Illegal chunk position");
            return null;
        }
        return chunks[cPosition.x, cPosition.y];
    }

    public Chunk GetChunk(Vector2 wPosition)
    {
        Vector2Int cPosition = WorldToChunk(wPosition);
        if(!LegalChunkPosition(cPosition.x, cPosition.y))
        {
            Debug.LogError("Illegal chunk position");
            return null;
        }
        return chunks[cPosition.x, cPosition.y];
    }

    public Vector2 ChunkToWorld(int row, int col)
    {
        float wX = origin.x + (row - col) * mapUnit.x/2f;
        float wY = origin.y + (row + col) * mapUnit.y/2f;
        return new Vector2(wX, wY);
    }

    public Vector2Int WorldToChunk(Vector2 wPosition)
    {
        float x = (wPosition.y - origin.y) / mapUnit.y + ((wPosition.x - origin.x) / mapUnit.x);
        float y = (wPosition.y - origin.y) / mapUnit.y - ((wPosition.x - origin.x) / mapUnit.x);
        relativeMousePos.x = x;
        relativeMousePos.y = y;
        if(!LegalChunkPosition(x, y))
            return GameConstant.ILLEGAL_CHUNK_POS; //return illegal position
        int cX = (int)x;
        int cY = (int)y;
        return new Vector2Int(cX, cY);
    }

    private bool LegalChunkPosition(float x, float y)
    {
        if(x < 0 || x >= chunkNum.x ||
           y < 0 || y >= chunkNum.y)
            return false;
        return true;
    }
}
