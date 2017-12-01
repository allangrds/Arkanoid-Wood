using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public float movimentSpeed;
    public float horizontalLimitCamera;

    void Start()
    {
    }

    void Update()
    {
        // -1 esquerda; 0 parado; 1 direita;
        float mouseHorizontalDirection = Input.GetAxis("Mouse X");

        // Vetor global
        GetComponent<Transform>().position += Vector3.right * mouseHorizontalDirection * movimentSpeed * Time.deltaTime;

        // Bloquiei o valor da posição
        float actualHorizontalPosition = transform.position.x;
        actualHorizontalPosition = Mathf.Clamp(actualHorizontalPosition, -horizontalLimitCamera, horizontalLimitCamera);

        // Dizer que o campo em X foi atualizado
        transform.position = new Vector2(actualHorizontalPosition, transform.position.y);
    }
}