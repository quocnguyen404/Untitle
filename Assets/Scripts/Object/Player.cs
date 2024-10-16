using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;      
    private bool isMoving = false;    
    private Vector3 targetPosition;   
    public MapManager MapManager;

    public void Awake()
    {
        // Debug.Log(MapManager.IsMoveableTile(Vector3Int.one));
        targetPosition = GameConstant.ENTITY_OFFSET + MapManager.GridOffset;
        transform.position = GameConstant.ENTITY_OFFSET + MapManager.GridOffset;
    }
    
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if(isMoving) 
            return;
            
        if (Input.GetKey(KeyCode.W))
        {
            targetPosition += Vector3.up/4;
            targetPosition -= Vector3.right/2;     
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            targetPosition -= Vector3.up/4;     
            targetPosition += Vector3.right/2;     
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            targetPosition -= Vector3.up/4;     
            targetPosition -= Vector3.right/2;      
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            targetPosition += Vector3.up/4;
            targetPosition += Vector3.right/2;     
        }

        if (targetPosition != transform.position && TileIsMoveable())
            StartCoroutine(MoveToTarget());
        else
            targetPosition = transform.position;
    }

    private bool TileIsMoveable()
    {
        return MapManager.IsMoveableTile(targetPosition);
    }

    private IEnumerator MoveToTarget()
    {
        isMoving = true;

        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;  
        }

        transform.position = targetPosition;

        isMoving = false;  
    }
}
