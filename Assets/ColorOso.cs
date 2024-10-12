using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOso : MonoBehaviour
{
    private int touchCount = 0;
    private Renderer rend;
    private Color OGcolor;
    void Start()
    {
        rend = GetComponent<Renderer>();
        OGcolor = rend.material.color;
    }

    // Método público para cambiar el color
    public void ChangeColor()
    {
        touchCount++;
        switch (touchCount % 5)
        {
            case 1:
                rend.material.color = new Color(0.5f, 0.25f, 0.0f); // Café
                break;
            case 2:
                rend.material.color = Color.red; // Rojo
                break;
            case 3:
                rend.material.color = Color.yellow; // Amarillo
                break;
            case 4:
                rend.material.color = new Color(0.5f, 0.0f, 0.5f); // Morado
                break;
            default:
                rend.material.color = OGcolor; // Color original
                break;
        }
    }
}