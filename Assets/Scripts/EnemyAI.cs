using System.Collections;
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
    public GameObject collectible;

    private Transform grid;
    private Vector2 cFly;
    // Use this for initialization
    void Start()
    {
        if (hop.check)
            InvokeRepeating("Hop", 1f, (1 / hop.rate));
        if (jump.check)
            InvokeRepeating("Jump", (1 / jump.rate), (1 / jump.rate));
        if (fly.check)
        {
            InvokeRepeating("Fly", 1f, (2 / fly.rate));
            //InvokeRepeating("CounterFly", 1f + (1 / fly.rate), (2 / fly.rate));
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

    private void Hop()
    {
        Vector2 d = new Vector2(Random.Range(-1f, 1f), 1f); d = d.normalized;
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
        d = d.normalized; //cFly = new Vector2(-d.x, -d.y);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fly.force * d.x, fly.force * d.y), ForceMode2D.Impulse);
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
