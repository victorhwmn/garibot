using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    //public string colliderTag;
    public GameObject textObject;
    public GameObject bar;
    void OnTriggerEnter2D(Collider2D collider)
    {
        int temp = textObject.GetComponent<CanvasTextUpdate>().totalAmount;
        string tag = collider.tag;

        if (tag == "Collectible")
        {
            collider.gameObject.GetComponent<SummonAnimation>().Summon();
            textObject.GetComponent<CanvasTextUpdate>().totalAmount = temp + 1;
            Destroy(collider.gameObject);
            bar.GetComponent<Progress>().IncrementTotal();
            //Debug.Log(bar.GetComponent<Progress>().totalAmount);
        }
        if (tag == "Recycler")
        {
            collider.gameObject.GetComponent<SummonAnimation>().Summon();
            textObject.GetComponent<CanvasTextUpdate>().RetrieveAllPieces();
        }
    }
}