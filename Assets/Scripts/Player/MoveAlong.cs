using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlong : MonoBehaviour
{
    private Transform[] moveAlong; //Objects that should move along the gameObject
    private void Awake()
    {
        moveAlong = GameObject.Find("ObjectsToMoveAlong").GetComponentsInChildren<Transform>();
    }

    void FixedUpdate ()
    {
        foreach (Transform t in moveAlong)
            t.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, t.position.z);
    }
}
