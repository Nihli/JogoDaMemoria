using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class GameController : MonoBehaviour
{


    public Sprite[] imgs;
    public GameObject cartaOriginal;
    private Carta primeiro, segundo;
    public TextMeshProUGUI scoreTexto, tentativasTexto;
    public int score, tentativas;
    
    // Start is called before the first frame update
    void Start()
    {
        tentativas = 0;
        //numero atribuído às cartas para comparar depois.
        int[] id = {0,0,1,1,2,2,3,3};
        id = ShuffleArray(id);
        cartaOriginal.GetComponent<Carta>().setID(id[0], imgs[id[0]]);
        for (int i = 1; i < 4; i++) //cartas de baixo
        {
            //instantiate cria game objects dentro do código, copia. Se deixar só essa linha ele bota na mesma posição da carta original.
            GameObject carta = Instantiate(cartaOriginal);
            carta.GetComponent<Carta>().setID(id[i], imgs[id[i]]);
            carta.transform.position = new Vector3(carta.transform.position.x +(3*i), carta.transform.position.y,carta.transform.position.z);

        }
        for (int i = 0; i < 4; i++) //cartas de cima
        {
            //instantiate cria game objects dentro do código, copia. Se deixar só essa linha ele bota na mesma posição da carta original.
            GameObject carta = Instantiate(cartaOriginal);
            carta.GetComponent<Carta>().setID(id[i+4], imgs[id[i+4]]);
            carta.transform.position = new Vector3(carta.transform.position.x + (3 * i), carta.transform.position.y+5, carta.transform.position.z);

        }

    }

    public void revelaCarta(Carta carta)
    {
        if (primeiro == null)
        {
            primeiro = carta;
        }
        else
        {
            segundo = carta;
            tentativas++;
            tentativasTexto.text = "Tentativas: " + tentativas;
            StartCoroutine(verificaPar());
        }
    }

    public IEnumerator verificaPar()
    {
        if (primeiro.getID() == segundo.getID()){
            score++;
            scoreTexto.text = "Score: " + score;
            if (score >= 4)
            {
                PlayerPrefs.SetInt("tentativas", tentativas);
                yield return new WaitForSeconds(1f);
                //SceneManager.LoadScene(2);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            yield return new WaitForSeconds(1f); //para por um segundo a execução do código.
            primeiro.unreveal();
            segundo.unreveal();
        }
        primeiro = null;
        segundo = null;
    }

    public Carta getSegundo()
    {
        return segundo;
    }

    private int[] ShuffleArray(int[] ids)
    {
        int[] shuffled = ids;
        for (int i=0; i < shuffled.Length; i++)
        {
            int tmp = shuffled[i];
            int r = Random.Range(i, shuffled.Length);
            shuffled[i] = shuffled[r];
            shuffled[r] = tmp;
        }
        return shuffled;
    }
}
