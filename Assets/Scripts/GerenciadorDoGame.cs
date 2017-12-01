using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDoGame : MonoBehaviour
{
    public static void endGame()
    {
        Application.LoadLevel("DefaultScene");
    }
}