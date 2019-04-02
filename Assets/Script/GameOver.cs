using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI textoTentativas;

    // Start is called before the first frame update
    void Start()
    {
        textoTentativas.text = "Numero de tentativas: " + PlayerPrefs.GetInt("tentativas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
