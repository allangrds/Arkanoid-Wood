using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    // Use this for initialization
    void Start()
    {
        //A direção se tornará um vetor normalizado
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    // Função chamada quando esse elemento colidir com outro.
    // O outro elemento, junto com a info da colisão, são encontrados no 'collider'
    void OnCollisionEnter2D(Collision2D collision)
    {
        bool invalidCollision = false;
        Vector2 normal = collision.contacts[0].normal;
        Plataforma plataform = collision.transform.GetComponent<Plataforma>();
        GeradorDeArestas edgeGenerator = collision.transform.GetComponent<GeradorDeArestas>();
        if (plataform != null) // Se existir o componente Plataforma no game object com o qual a bolinha colidiu
        {
            if (normal != Vector2.up)
            {
                invalidCollision = true;
            }
        }
        else if (edgeGenerator != null)
        {
            if (normal == Vector2.up)
            {
                invalidCollision = true;
            }
        }
        else //Caso entre no else, estamos colidindo com um bloco
        {
            invalidCollision = false;
            Destroy(collision.gameObject); //contém referência do objeto que a bolinha colidiu
        }

        if (invalidCollision)
        {
            GerenciadorDoGame.endGame();
        }
        else
        {
            direction = Vector2.Reflect(direction, normal);
            direction.Normalize();
        }
    }
}