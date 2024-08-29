using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public float mouseSensitivity = 60f; // Sensibilidade do mouse
    public Vector3 offset; // Deslocamento da câmera em relação ao jogador

    public float yMinLimit = -25f; // Limite mínimo do ângulo de visão no eixo Y
    public float yMaxLimit = 25f; // Limite máximo do ângulo de visão no eixo Y

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
    }

    void Update()
    {
        // Movimentação da câmera com o mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, yMinLimit, yMaxLimit);

        // Rotaciona a câmera nos eixos X e Y
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        // Seguir o jogador
        transform.position = player.position + offset;

        // Centraliza a câmera na direção do mouse
        CenterCameraOnMouseDirection();
    }

    void CenterCameraOnMouseDirection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 direction = hit.point - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * mouseSensitivity);
        }
    }
}
