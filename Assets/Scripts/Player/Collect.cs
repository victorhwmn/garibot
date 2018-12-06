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
    private ManageFollowers mf;
//    private Placeholder flag;

    void Start()
    {
        gm = GameObject.Find("Manager").GetComponent<Game_Manager>();
        mf = gameObject.GetComponent<ManageFollowers>();
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
            mf.CreateNewFollower();
        }
        if (tag == "Recycler" && gameObject.GetComponent<ManageFollowers>().GetNFollowers() > 0) //Verifica se to segurando pelo menos um coletável pra ser entregue
        {
            collider.gameObject.GetComponent<SummonAnimation>().Summon();
            gm.RetrieveAllPieces();
            mf.ClearAllFollowers();
        }
    }
}