using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private int totalAmount = 0; //Total amount of collected pieces
    [SerializeField] private int retrieveAmount = 0;
    [SerializeField] private float totalExisting = 0; //Total amount of collectable pieces
    

    public void InitTotalAmount() { totalAmount = 0; }
    public void IncrementTotal() { totalAmount++; }
    public int GetTotalAmount() { return totalAmount; }
    public int GetRetrieveAmount() { return retrieveAmount; }
    public void SetTotalExisting(float t) { totalExisting = t; }

    public int RetrieveAllPieces()  //Called when all collected pieces are retrieved/recycled
    { 
        int temp = totalAmount;
        //totalAmount = 0;
        StaticProgressManager.UpdateCompletion((temp-retrieveAmount)/totalExisting);
        retrieveAmount = temp;
        return temp;
    }

    // Returns completion percentage from zero to 100
    public float ReturnLevelCompletion() {
        return (totalAmount / totalExisting) * 100f; // temp
        //return (((float) GetTotalAmount() / (float) GetTotalInWorldAmount()) * 100);
    }
}

