using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTextUpdate : MonoBehaviour
{
    public Text text;    //Text to display number of collected pieces
    [HideInInspector]
    public int totalAmount = 0; //Total amount of collected pieces
    private int retrieveAmount = 0; //Total amount of collected pieces

    // Update is called once per frame
    void Update()
    {
        text.text = "Voce possui " + totalAmount + " Pecas!";
        text.text += "\nNo total " + retrieveAmount + " Pecas foram recicladas!";
    }

    public void IncrementTotalAmount() //Called when a piece is collected
    { totalAmount++; }

    public int RetrieveAllPieces()  //Called when all collected pieces are retrieved/recycled
    {
        int temp = totalAmount;
        totalAmount = 0;
        retrieveAmount += temp;
        return temp;
    }
}
