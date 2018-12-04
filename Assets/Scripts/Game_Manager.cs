using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private int totalAmount = 0;
    [SerializeField] private int retrieveAmount = 0; //Total amount of collected pieces

    public void InitTotalAmount() { totalAmount = 0; }
    public void IncrementTotal() { totalAmount++; }
    public int GetTotalAmount() { return totalAmount; }
    public int GetRetrieveAmount() { return retrieveAmount; }

    public int RetrieveAllPieces()  //Called when all collected pieces are retrieved/recycled
    { 
        int temp = totalAmount;
        totalAmount = 0;
        retrieveAmount += temp;
        return temp;
    }

    // Returns completion percentage from zero to 100
    public float ReturnCompletion() {
        return (((float) GetTotalAmount() / (float) 5) * 100); // temp
        //return (((float) GetTotalAmount() / (float) GetTotalInWorldAmount()) * 100);
    }
}

