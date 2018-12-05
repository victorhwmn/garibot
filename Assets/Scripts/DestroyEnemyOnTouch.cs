using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyOnTouch : MonoBehaviour
{
    //public float launchForce = 10f;
    //// Use this for initialization
    //void Awake ()
    //{
    //    Vector3 r = gameObject.transform.rotation.eulerAngles;
    //    gameObject.GetComponent<Rigidbody2D>().AddForce(
    //        new Vector2(launchForce * r.x, launchForce * r.y), ForceMode2D.Impulse);
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        string tag = collider.tag;

        //Debug.Log(tag);

        if (tag == "Enemy")
        {
            collider.gameObject.GetComponent<EnemyAI>().Die();
        }
    }
}
