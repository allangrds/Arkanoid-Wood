using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class GeradorDeBlocos : MonoBehaviour
{
    public GameObject[] blocks;
    public int lines;

    void Start()
    {
        CreateBlocksGroup();
    }

    void CreateBlocksGroup()
    {
        Bounds blockLimit = blocks[0].GetComponent<SpriteRenderer>().bounds;

        float blockWidth = blockLimit.size.x;
        float blockHeight = blockLimit.size.y;
        float screenWidth, screenHeight, widthMultiplier;
        int columns;

        CollectBlockInformations(blockWidth, out screenWidth, out screenHeight, out columns, out widthMultiplier);

        GerenciadorDoGame.numberOfBlockInGame = columns * lines;

        for (int i = 0; i < lines; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject randomBlock = blocks[Random.Range(0, blocks.Length)];
                GameObject blockInstance = (GameObject) (Instantiate(randomBlock));

                blockInstance.transform.position =
                    new Vector3(-(screenWidth * 0.5f) + (j * blockWidth * widthMultiplier),
                        (screenHeight * 0.5f) - (i * blockHeight), 0);
                float newBlockWidth = blockInstance.transform.localScale.x * widthMultiplier;
                blockInstance.transform.localScale =
                    new Vector3(newBlockWidth, blockInstance.transform.localScale.y, 1);
            }
        }
    }

    void CollectBlockInformations(float blockWidth, out float screenWidth, out float screenHeight,
        out int columns, out float widthMultiplier)
    {
        Camera cam = Camera.main;
        screenWidth = (cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) -
                       cam.ScreenToWorldPoint(new Vector3(0, 0, 0)))
            .x; //gera vetor que aponta do lado esquerdo ao direito
        screenHeight = (cam.ScreenToWorldPoint(new Vector3(Screen.height, 0, 0)) -
                        cam.ScreenToWorldPoint(new Vector3(0, 0, 0))).y;
        columns = (int) (screenWidth / blockWidth);
        widthMultiplier = screenWidth / (columns * blockWidth);
    }
}