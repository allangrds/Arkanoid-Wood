using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeArestas : MonoBehaviour
{
    void Start()
    {
        Camera cam = Camera.main;
        EdgeCollider2D collider = GetComponent<EdgeCollider2D>();

        //Seta as arestas
        Vector2 lowerLeftCorner = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 upperLeftCorner = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        Vector2 lowerRightCorner = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        Vector2 upperRightCorner = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //Inclui as arestas como pontos no colisor
        collider.points = new Vector2[5]
        {
            lowerLeftCorner,
            upperLeftCorner,
            upperRightCorner,
            lowerRightCorner,
            lowerLeftCorner
        };
    }

    void Update()
    {
    }
}