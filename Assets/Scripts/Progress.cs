using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    float total = 4f;
    Image progressBar;

    private Game_Manager gm;
    // Use this for initialization
    void Start ()
    {
        progressBar = gameObject.GetComponent<Image>();
        progressBar.fillAmount = 0F;

        GameObject g = GameObject.Find("Manager");
        if (g == null)
            Debug.Log("Não há um objeto chamado Manager na cena!");
        else
            gm = g.GetComponent<Game_Manager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        progressBar.fillAmount = (gm.GetTotalAmount()/total);
    }
}
