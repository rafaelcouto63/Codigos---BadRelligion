using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivityController : MonoBehaviour
{
     public Slider sensitivitySlider; // Referência ao slider
    public CameraController cameraController; // Referência ao script da câmera

    void Start()
    {
        // Configura os valores mínimo e máximo do slider
        sensitivitySlider.minValue = 100f;
        sensitivitySlider.maxValue = 1000f;

        // Inicializa o valor do slider com a sensibilidade atual
        sensitivitySlider.value = cameraController.mouseSensitivity;

        // Adiciona um listener para chamar a função UpdateSensitivity quando o valor do slider mudar
        sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
    }

    void UpdateSensitivity(float value)
    {
        // Atualiza a sensibilidade do mouse no script da câmera
        cameraController.mouseSensitivity = value;
    }
}