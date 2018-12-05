using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        SummonAnimation sa = gameObject.GetComponent<SummonAnimation>();
        if (sa != null) sa.Summon();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        SummonAnimation sa = gameObject.GetComponent<SummonAnimation>();
        if (sa != null) sa.Summon();
        Destroy(gameObject);
    }
}
