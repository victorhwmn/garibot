using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlong : MonoBehaviour
{
    public float offset= .5f;

    private Transform[] moveAlong; //Objects that should move along the gameObject
    private void Awake()
    {
        moveAlong = GameObject.Find("ObjectsToMoveAlong").GetComponentsInChildren<Transform>();
    }

    void FixedUpdate ()
    {
        foreach (Transform t in moveAlong)
        {
            if (t.gameObject.tag == "MainCamera")   t.position = new Vector3(gameObject.transform.position.x         , gameObject.transform.position.y, t.position.z);
            else                                    t.position = new Vector3(gameObject.transform.position.x * offset, gameObject.transform.position.y, t.position.z);
        }
    }
}
