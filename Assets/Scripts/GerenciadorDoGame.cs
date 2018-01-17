using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorDoGame : MonoBehaviour
{
    public static int numberOfBlockInGame;
    public static int numberOfBlocksDestroyed;
    public Image stars;
    public GameObject canvasGo;
    public static GerenciadorDoGame istance;
    public GameObject boll;
    public Plataforma plataform;
    
    private void Awake()
    {
        istance = this;
    }

    void Start()
    {
        if(Application.loadedLevel == 1)
        {
            canvasGo.SetActive(false);
            numberOfBlocksDestroyed = 0;
        }
    }
   
    public void endGame()
    {
        stars.fillAmount = (float)numberOfBlocksDestroyed / (float)numberOfBlockInGame;
        canvasGo.SetActive(true);

        plataform.enabled = false;
        Destroy(boll);
    }

    public void changeScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}