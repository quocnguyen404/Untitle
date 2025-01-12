using System.Collections;
using System.Collections.Generic;
using Object;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    public static MouseHandler Instance { get; private set; }

    [SerializeField] private MouseIndicator mi = null;
    public MouseIndicator MouseIndicator
    {
        get { return mi; }
    }

    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        // Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        // mi.transform.position = new Vector3(mousePosition.x, mousePosition.y, mi.transform.position.z);
    }
}
