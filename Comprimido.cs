using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comprimido : MonoBehaviour
{
    private bool isHolding = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        isHolding = !isHolding;
    }

    void Update()
    {
        if (isHolding)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            transform.position = worldPosition;
        }
    }
}
