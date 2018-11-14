using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour {
    float total = 4f;
    Image progressBar;
    public int totalAmount;
    // Use this for initialization
    void Start () {
        progressBar = gameObject.GetComponent<Image>();
        progressBar.fillAmount = 0F;
        totalAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {

        progressBar.fillAmount = (float) (totalAmount/total);

    }
    public void IncrementTotal()
    {
        totalAmount++;
    }
}
