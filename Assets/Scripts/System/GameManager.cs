using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MapManager mapManager;

    public void Awake()
    {
        mapManager.Initialize();
    }

    public void OnEnble()
    {
    }

    public void OnDisable()
    {

    }
}
