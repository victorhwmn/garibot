using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public string sceneToBeDestroyed;
    public string tagName;

	// Use this for initialization
	void Awake ()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tagName);
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
	}

    void Update()
    {
        if (SceneManager.GetActiveScene().name == sceneToBeDestroyed)
            Destroy(this.gameObject);
    }
}
