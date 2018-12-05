using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCollectible : MonoBehaviour
{
    public SpriteRenderer sr;
    public Collider2D c2d;
    public float minPercentage = 50f;

    private Game_Manager gm;
    // Use this for initialization
    void Awake()
    {
        sr.enabled = false;
        c2d.enabled = false;

        GameObject g = GameObject.Find("Manager");
        if (g == null)
            Debug.Log("Não há um objeto chamado Manager na cena!");
        else
            gm = g.GetComponent<Game_Manager>();
    }

	// Update is called once per frame
	void Update ()
    {
		if (gm.ReturnLevelCompletion() > minPercentage)
        {
            sr.enabled = true;
            c2d.enabled = true;
            this.enabled = false;
        }
	}
}
