using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    private LevelChanger loader;

    void Awake()
    {
        GameObject lc = GameObject.Find("LevelChanger");
        if (lc == null)
            Debug.Log("Não há um objeto chamado Level Changer na cena!");
        else
            loader = lc.GetComponent<LevelChanger>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "FinalCollectible") {
            // Summons object animation and destroys it
            collider.gameObject.GetComponent<SummonAnimation>().Summon();
            Destroy(collider.gameObject);

            // Loads next scene
            //if (SceneManager.GetActiveScene().buildIndex == 5) //Level 03
            //    loader.FadeToScene(5);
            //else
            loader.FadeToNextScene();
        }
    }
}
