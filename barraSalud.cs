using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barraSalud : MonoBehaviour
{
    public RectTransform salud;
    public static Vector2 cantidadSalud;
    public static float saludC, saludMax = 92;
    public GameObject fin, todo;

    public void Start()
    {
        saludC = salud.sizeDelta.x;
    }

    public void cambiaSalud(float cantidad)
    {
        cantidadSalud[0] = cantidad;
        cantidadSalud[1] = 0;
        salud.sizeDelta += cantidadSalud;
        if (salud.sizeDelta.x > saludMax) { cantidadSalud[0] = saludMax; cantidadSalud[1] = 3.5f; salud.sizeDelta = cantidadSalud; }
        if(salud.sizeDelta.x <= 0) { pierdeVida(); }
        saludC = salud.sizeDelta.x;
    }

    public void pierdeVida()
    {
        if(vidas2.vidasC <= 1)
        {
            fin.SetActive(true);
            todo.SetActive(false);
        }

        if(vidas2.vidasC > 1)
        {
            cambiaSalud(saludMax);
            FindObjectOfType<vidas2>().cambiaVida(-0.25f);
        }
    }

}
