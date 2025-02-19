using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Camera cam = null;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float smoothTime = 0.3f;

    private Vector3 vel = Vector3.zero;

    private void LateUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = cam.transform.position.z;
            Vector3 direction = mousePos - cam.transform.position;
            direction = direction.normalized * moveSpeed;

            cam.transform.position = Vector3.SmoothDamp(cam.transform.position, cam.transform.position + direction, ref vel, smoothTime);
            HandleCameraLimit();
        }
    }

    private void HandleCameraLimit()
    {
        Vector3 clampedPosition = cam.transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -GameConfigure.CameraLimitMax.x, GameConfigure.CameraLimitMax.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -GameConfigure.CameraLimitMax.y, GameConfigure.CameraLimitMax.y);
        cam.transform.position = clampedPosition;
    }
}
