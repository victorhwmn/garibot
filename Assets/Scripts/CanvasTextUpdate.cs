using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTextUpdate : MonoBehaviour
{
    public Text text;    //Text to display number of collected pieces
    [HideInInspector]
    private Game_Manager gm;

    void Start()
    {
        GameObject g = GameObject.Find("Manager");
        if (g == null)
            Debug.Log("Não há um objeto chamado Manager na cena!");
        else
            gm = g.GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Voce possui " + gm.GetTotalAmount() + " Pecas!";
        text.text += "\nNo total " + gm.GetRetrieveAmount() + " Pecas foram recicladas!";
    }
}
