using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel : MonoBehaviour {

    public LevelChanger loader;
	
	void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "FinalCollectible") {
            // Summons object animation and destroys it
            collider.gameObject.GetComponent<SummonAnimation>().Summon();
            Destroy(collider.gameObject);

            // Loads next scene
            loader.FadeToNextScene();
        }
    }
}
