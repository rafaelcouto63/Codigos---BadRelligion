using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : MonoBehaviour
{
   public Outline[] outlineObjects;
    private Outline currentOutline;
    private Outline hoverOutline;

    void Start()
    {
        // Encontra todos os objetos com o script Outline
        outlineObjects = Resources.FindObjectsOfTypeAll<Outline>();
    }

    void Update()
    {
        // Verifica a posição do mouse e habilita/desabilita o contorno
        foreach (Outline outline in outlineObjects)
        {
            if (outline != null && IsMouseOver(outline.gameObject))
            {
                // Habilita o contorno ao passar o mouse
                if (hoverOutline != outline)
                {
                    if (hoverOutline != null && hoverOutline != currentOutline)
                    {
                        hoverOutline.enabled = false;
                    }
                    outline.enabled = true;
                    hoverOutline = outline;
                }

                // Alterna o contorno ao clicar
                if (Input.GetMouseButtonDown(0))
                {
                    if (currentOutline != null)
                    {
                        currentOutline.enabled = false;
                    }

                    if (currentOutline == outline)
                    {
                        currentOutline = null;
                    }
                    else
                    {
                        outline.enabled = true;
                        currentOutline = outline;
                    }
                }
            }
            else if (hoverOutline == outline && hoverOutline != currentOutline && outline != null)
            {
                outline.enabled = false;
                hoverOutline = null;
            }
        }
    }

    private bool IsMouseOver(GameObject obj)
    {
        // Converte a posição do mouse para um raio no mundo
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Verifica se o raio colide com o objeto
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform == obj.transform;
        }

        return false;
    }

}
