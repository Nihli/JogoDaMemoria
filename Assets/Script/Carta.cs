using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{

    public GameObject fundoCarta;
    public GameController gc;
    private int id;
    //aplica no game object e quando clicamos, ele executa o codigo dessa classe.
    public void OnMouseDown()
    {
        if (fundoCarta.activeSelf && gc.getSegundo() == null) { //fundo da carta tem que estar ativado e segundo tem que ser null
            fundoCarta.SetActive(false); //para de renderizar a imagem do fundo da carta.
            gc.revelaCarta(this);
        }
    }

    public int getID()
    {
        return id;
    }

    public void setID(int id_, Sprite img)
    {
        this.id = id_;
        //Procura dentro do GameObject um Sprite e retorna. No caso ele tá procurando em Carta Principal
        GetComponent<SpriteRenderer>().sprite = img;
    }

    public void unreveal() {
        fundoCarta.SetActive(true);
    }


}
