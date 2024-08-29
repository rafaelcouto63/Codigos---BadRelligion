using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariaçaoLuz : MonoBehaviour
{
    public Light targetLight; // A luz cuja intensidade será alterada
    public float changeRate = 0.1f; // A taxa de mudança da intensidade
    public float delay = 0.1f; // O atraso entre cada mudança de intensidade
    public float minIntensity = 0f; // Intensidade mínima da luz
    public float maxIntensity = 1f; // Intensidade máxima da luz

    private bool increasing = true;

    void Start()
    {
        if (targetLight == null)
        {
            targetLight = GetComponent<Light>();
        }
        StartCoroutine(ChangeLightIntensity());
    }

    IEnumerator ChangeLightIntensity()
    {
        while (true)
        {
            if (increasing)
            {
                targetLight.intensity += changeRate;
                if (targetLight.intensity >= maxIntensity)
                {
                    targetLight.intensity = maxIntensity;
                    increasing = false;
                }
            }
            else
            {
                targetLight.intensity -= changeRate;
                if (targetLight.intensity <= minIntensity)
                {
                    targetLight.intensity = minIntensity;
                    increasing = true;
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
