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

    void Update ()
    {
        if (Vector3.Distance(transform.position, leader.position) > distance)
        {
            transform.position = new Vector3(   Mathf.Lerp(transform.position.x, leader.position.x, 5f * Time.deltaTime),
                                                Mathf.Lerp(transform.position.y, leader.position.y, 5f * Time.deltaTime),
                                                Mathf.Lerp(transform.position.z, leader.position.z, 5f * Time.deltaTime));
        }
    }
}
