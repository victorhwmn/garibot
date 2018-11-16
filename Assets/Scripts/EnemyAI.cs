using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float hopForce = 2f;
    public float hopRate = 2f;
    public float jumpForce = 2f;
    public float jumpRate = 2f;
    public GameObject collectible;

    private Transform grid;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Hop", 1f, 1 / hopRate);
        InvokeRepeating("Jump", 1 / jumpRate, 1 / jumpRate);
        GameObject g = GameObject.Find("Grid");
        if (g == null)
            Debug.Log("Não há um objeto chamado Grid na cena!");
        else
            grid = g.GetComponent<Transform>();
    }

    private void Hop()
    {
        Vector2 d = new Vector2(Random.Range(-1f, 1f), 1f); d = d.normalized;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(hopForce * d.x, hopForce * d.y), ForceMode2D.Impulse);
    }

    private void Jump()
    {
        Vector2 d = new Vector2(Random.Range(-0.8f, 0.8f), 1f); d = d.normalized;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForce * d.x, jumpForce * d.y), ForceMode2D.Impulse);
    }

    public void Die()
    {
        Instantiate(collectible, gameObject.transform.position, Quaternion.identity, grid);
        Destroy(gameObject);
    }
}
