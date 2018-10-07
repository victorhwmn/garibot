using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public string colliderTag;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == colliderTag)
        {
            collider.gameObject.GetComponent<SummonAnimation>().Summon();
            Destroy(collider.gameObject);
        }
    }
}
