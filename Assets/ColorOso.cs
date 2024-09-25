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

    // Update is called once per frame
     void Update()
    {
        // Detectar toques en la pantalla
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchCount++;
            switch (touchCount % 3)
            {
                case 1:
                    rend.material.color = new Color(0.5f, 0.25f, 0.0f); // Café
                    break;
                case 2:
                    rend.material.color = Color.blue; // Azul
                    break;
                default:
                    rend.material.color = OGcolor; // Color original
                    break;
            }
        }

    }
}