using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour, IComponent
{
    private Dictionary<Vector2Int, Entity> entities;

    public Camera cam;
    public Entity DirtPref;
    [SerializeField] private Tilemap TileMap;
    [SerializeField] private Grid grid;
    [SerializeField] private ShoppingHandler shoppingHandler;

    public Vector3 GridOffset => grid.transform.position;

    public void Initialize()
    {
        entities = new Dictionary<Vector2Int, Entity>();
        cam = Camera.main;
        shoppingHandler.Initialize();
        shoppingHandler.OnRelease += HandleBuyEntity;
    }

    public void Update()
    {
        HandleMouseInput();
    }

    public bool IsMoveableTile(Vector3 wPosition)
    {
        Vector3Int gPosition = grid.WorldToCell(wPosition);
        return TileMap.HasTile(gPosition);
    }

    public void AddEntity(Entity entity, Vector3 wPosition)
    {
        Vector3Int gPosition = TileMap.WorldToCell(wPosition);
        entity.SetGridPosition(TileMap.CellToWorld(gPosition));
        entities.Add(new Vector2Int(gPosition.x, gPosition.y), entity);
    }

    public void HandleMouseInput()
    {
        Vector3 mPosition = GetMousePosition();
        Vector3Int cPosition = TileMap.WorldToCell(mPosition);
        Vector3 wPosition = TileMap.CellToWorld(cPosition);

        shoppingHandler.HandleMouseIndicator(IsMoveableTile(mPosition), wPosition, mPosition);
    }

    public void HandleBuyEntity(string entityName)
    {
        Vector3 mPosition = GetMousePosition();
        if(IsMoveableTile(mPosition))
        {
            GenerateEntity(entityName, mPosition);
        }
        else
            Debug.Log("Not moveable");
    }

    public void GenerateEntity(string entityName, Vector3 position)
    {
        Debug.Log("Generate entity: " + entityName);
        Entity entity = Instantiate(DirtPref, TileMap.transform);
        AddEntity(entity, position);
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        return new Vector3(mPosition.x, mPosition.y, 0);
    }

    public void Finalize()
    {
        shoppingHandler.OnRelease -= HandleBuyEntity;
    }
}
