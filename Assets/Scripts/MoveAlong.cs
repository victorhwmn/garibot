using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlong : MonoBehaviour
{
    public Transform[] moveAlong; //Objects that should move along the gameObject
    void FixedUpdate ()
    {
        foreach (Transform t in moveAlong)
            t.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, t.position.z);
    }
}
