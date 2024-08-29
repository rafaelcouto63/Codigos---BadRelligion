using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biblia : MonoBehaviour
{
    public Vector3 offset = new Vector3(1, 1, 0); // Offset em relação à câmera
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isFollowingCamera = false;
    private Camera mainCamera;

    void Start()
    {
        // Armazena a posição e rotação original do objeto
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        // Obtém a câmera principal
        mainCamera = Camera.main;

        // Verifica se a câmera principal foi encontrada
        if (mainCamera == null)
        {
            Debug.LogError("Câmera principal não encontrada!");
        }
    }

    void Update()
    {
        if (isFollowingCamera && Input.GetMouseButtonDown(0))
        {
            // Verifica se o clique foi fora do objeto
            if (!IsMouseOver())
            {
                ReturnToOriginalPosition();
            }
        }
    }

    void OnMouseDown()
    {
        if (mainCamera == null) return;

        isFollowingCamera = !isFollowingCamera;
        if (isFollowingCamera)
        {
            // Torna o objeto um filho da câmera
            transform.SetParent(mainCamera.transform);
            // Ajusta a posição do objeto com base no offset
            transform.localPosition = offset;
            // Ajusta a rotação do objeto
            transform.localRotation = Quaternion.Euler(90, 0, 0);
        }
        else
        {
            ReturnToOriginalPosition();
        }
    }

    private void ReturnToOriginalPosition()
    {
        // Remove o objeto como filho da câmera
        transform.SetParent(null);
        // Move o objeto de volta para a posição original
        transform.position = originalPosition;
        // Restaura a rotação original do objeto
        transform.rotation = originalRotation;
        isFollowingCamera = false;
    }

    private bool IsMouseOver()
    {
        // Converte a posição do mouse para um raio no mundo
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Verifica se o raio colide com o objeto
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform == transform;
        }

        return false;
    }
}