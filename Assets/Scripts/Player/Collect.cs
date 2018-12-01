using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder
{
    public int a;
}

public class Collect : MonoBehaviour
{
    //public string colliderTag;
    private Game_Manager gm;
//    private Placeholder flag;

    void Start()
    {
        gm = GameObject.Find("Manager").GetComponent<Game_Manager>();
    }

    //void Update()
    //{
    //    flag.a = 1;
    //}

    void OnTriggerEnter2D(Collider2D collider)
    {
            //int temp = gm.GetTotalAmount();
            string tag = collider.tag;
        SummonAnimation sa = null;

        if (tag == "Collectible")
        {
            sa = collider.GetComponent<SummonAnimation>();

            if (sa.LockAndCheck())
            {
                collider.gameObject.GetComponent<SummonAnimation>().Summon();
                gm.IncrementTotal();
                Destroy(collider.gameObject);
            }
        }
        if (tag == "Recycler")
        {
            collider.gameObject.GetComponent<SummonAnimation>().Summon();
            gm.RetrieveAllPieces();
        }
    }
}