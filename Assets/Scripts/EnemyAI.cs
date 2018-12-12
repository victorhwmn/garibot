﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Move
{
    public float force;
    public float rate;
    public bool check;
}

public class EnemyAI : MonoBehaviour
{
    public Move hop;
    public Move jump;
    public Move fly;
    public Move shoot;
    public GameObject collectible;
    public Transform firePoint;
    public GameObject bullet;

    private Transform grid;
    private Vector2 cFly;
    //private bool facingRight = true;
    // Use this for initialization
    void Start()
    {
        if (hop.check)
            InvokeRepeating("Hop", 1f, Random.Range((1 / hop.rate)*0.7f, (1 / hop.rate) * 1.3f));
        if (jump.check)
            InvokeRepeating("Jump", (1 / jump.rate), Random.Range((1 / jump.rate) * 0.7f, (1 / jump.rate) * 1.3f));
        if (fly.check)
            InvokeRepeating("Fly", 1f, Random.Range((1 / fly.rate) * 0.7f, (1 / fly.rate) * 1.3f));
        if (shoot.check)
        {
            InvokeRepeating("Shoot", (1 / shoot.rate), Random.Range((1 / shoot.rate) * 0.7f, (1 / shoot.rate) * 1.3f));
            if (firePoint == null) Debug.LogWarning("Um inimigo está sem FirePoint (Transform)!");
            if (bullet == null) Debug.LogWarning("Um inimigo está sem Bullet (Prefab)!");
        }

            GameObject g = GameObject.Find("Grid");
        if (g == null)
            Debug.Log("Não há um objeto chamado Grid na cena!");
        else
            grid = g.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (!fly.check)
            return;

        Vector2 v = gameObject.GetComponent<Rigidbody2D>().velocity;
        v.x = Mathf.Lerp(v.x, 0f, 5f * Time.deltaTime); v.y = Mathf.Lerp(v.y, 0f, 5f * Time.deltaTime);
        gameObject.GetComponent<Rigidbody2D>().velocity = v;
    }

    private void FixFacing(float f)
    {
        if (f >= 0)
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);

        //if (facingRight)
        //    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        //else
        //    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void Hop()
    {
        Vector2 d = new Vector2(Random.Range(-1f, 1f), 1f); d = d.normalized; FixFacing(d.x);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(hop.force * d.x, hop.force * d.y), ForceMode2D.Impulse);
    }

    private void Jump()
    {
        Vector2 d = new Vector2(Random.Range(-0.7f, 0.7f), 1f); d = d.normalized;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jump.force * d.x, jump.force * d.y), ForceMode2D.Impulse);
    }

    private void Fly()
    {
        Vector2 d = new Vector2(4f * Random.Range(-0.5f, 0.5f), Random.Range(-0.2f, 0.2f));
        d = d.normalized; FixFacing(d.x);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fly.force * d.x, fly.force * d.y), ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        //Vector2 d = new Vector2(4f * Random.Range(-0.5f, 0.5f), Random.Range(-0.2f, 0.2f));
        //d = d.normalized;
        GameObject b = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        b.GetComponent<BulletMovement>().speed = shoot.force;
    }

    private void CounterFly()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            //AddForce(new Vector2(fly.force * cFly.x, fly.force * cFly.y), ForceMode2D.Impulse);
    }

    public void Die()
    {
        Instantiate(collectible, gameObject.transform.position, Quaternion.identity, grid);
        Destroy(gameObject);
    }
}
