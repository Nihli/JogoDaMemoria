using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviewDeCenas : MonoBehaviour
{
    public void iniciarJogo()
    {
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void reiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
     public void voltarMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void sairJogo()
    {
        Application.Quit();
    }

}
