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
        mapManager.Initialize();
    }

    public void Update()
    {
        
    }

    public void OnEnble()
    {
    }

    public void OnDisable()
    {

    }
}
