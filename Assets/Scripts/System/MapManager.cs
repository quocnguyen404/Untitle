using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Object;

public class MapManager : MonoBehaviour
{
    public Camera cam;
    

    public void Initialize()
    {
        cam = Camera.main;
    }
}
