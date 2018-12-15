using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public float distance;
    [HideInInspector]
    public Transform leader;
    //[HideInInspector]
    //public GameObject follower;

    void FixedUpdate ()
    {
        if (Vector3.Distance(transform.position, leader.position) > distance)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, leader.position.x, 8f * Time.deltaTime),
                                                Mathf.Lerp(transform.position.y, leader.position.y, 8f * Time.deltaTime),
                                                Mathf.Lerp(transform.position.z, leader.position.z, 8f * Time.deltaTime));
        }
        else
        {
            if (leader.tag == "Recycler")
                AnimateAndDie();
        }
    }

    public void DestroyAndAnimate()
    {
        leader = GameObject.FindGameObjectWithTag("Recycler").transform;
    }

    public void DestroyWithoutAnimate()
    {
        leader = GameObject.FindGameObjectWithTag("Recycler").transform;
        gameObject.GetComponent<SummonAnimation>().animationObject = null;
    }

    private void AnimateAndDie()
    {
        gameObject.GetComponent<SummonAnimation>().Summon();
        Destroy(gameObject);
    }
}
