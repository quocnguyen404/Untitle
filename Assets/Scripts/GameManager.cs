using Data;
using Object.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MapManager mapManager;

    public void Awake()
    {
        GameUtilities.MainCam = Camera.main;

        InitializeGameConfigure();
        mapManager.Initialize();
    }

    public void Update()
    {
        
    }

    private void InitializeGameConfigure()
    {
        GameConfigure.CameraLimitMax = mapManager.ChunkNum * Chunk.ChunkSize/2;
        Debug.Log(GameConfigure.CameraLimitMax);
    }
}
