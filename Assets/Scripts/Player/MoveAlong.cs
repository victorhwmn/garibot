using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlong : MonoBehaviour
{
    public float delayRate = .5f;

    private Transform cam;
    private Transform[] moveAlong; //Objects that should move along the gameObject
    private Vector3[] offsets;
    private Vector3 playerStart;
    private void Awake()
    {
        //moveAlong = GameObject.Find("ObjectsToMoveAlong").GetComponentsInChildren<Transform>();
        cam = Camera.main.transform;
        Transform tr = GameObject.Find("Fundo").GetComponent<Transform>();
        moveAlong = new Transform[tr.childCount];
        offsets = new Vector3[tr.childCount];
        playerStart = transform.position;
        int i = 0;
        foreach (Transform child in tr)
        {
            moveAlong[i] = child;
            offsets[i] = transform.position - child.position;
            i++;
        }
    }

    void FixedUpdate ()
    {
        //foreach (Transform t in moveAlong)
        //{
        //    if (t.gameObject.tag == "MainCamera")   t.position = new Vector3(gameObject.transform.position.x         , gameObject.transform.position.y, t.position.z);
        //    else                                    t.position = new Vector3(gameObject.transform.position.x * offset, gameObject.transform.position.y, t.position.z);
        //}

        cam.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, cam.transform.position.z);
        GameObject f = GameObject.Find("Fundo");
        Transform tr = f.GetComponent<Transform>();
        tr.position = new Vector3(gameObject.transform.position.x * delayRate + f.GetComponent<RepeatBackground>().GetDistPlayer(), gameObject.transform.position.y, tr.position.z);

        //for (int i = 0; i < moveAlong.Length; i++)
        //{
        //    //if (moveAlong[i].gameObject.tag == "MainCamera")
        //        moveAlong[i].position = new Vector3(gameObject.transform.position.x * delayRate, gameObject.transform.position.y, moveAlong[i].position.z);
        //    //else
        //    //{

        //    //    moveAlong[i].position = new Vector3(    (gameObject.transform.position.x - playerStart.x) * delayRate + playerStart.x + offsets[i].x,
        //    //                                            gameObject.transform.position.y,
        //    //                                            moveAlong[i].position.z);
        //    //    Debug.Log(moveAlong[i].gameObject.name);
        //    //}
        //}
    }
}
