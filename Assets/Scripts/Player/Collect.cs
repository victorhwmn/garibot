using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    //public string colliderTag;
    private Game_Manager gm;

    void Start()
    {
        gm = GameObject.Find("Manager").GetComponent<Game_Manager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //int temp = gm.GetTotalAmount();
        string tag = collider.tag;

        if (tag == "Collectible")
        {
            collider.gameObject.GetComponent<SummonAnimation>().Summon();
            gm.IncrementTotal();
            Destroy(collider.gameObject);
        }
        if (tag == "Recycler")
        {
            collider.gameObject.GetComponent<SummonAnimation>().Summon();
            gm.RetrieveAllPieces();
        }
    }
}