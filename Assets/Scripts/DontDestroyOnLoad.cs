using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    //public string sceneToBeDestroyed;
    //public string tagGroupName;
    //public string tagName;

    // Use this for initialization
    void Awake ()
    {
        DontDestroyOnLoad[] objs = FindObjectsOfType<DontDestroyOnLoad>();

        //GameObject obj = FindObjectOfType<DontDestroyOnLoad>().gameObject;

        //Debug.Log("Found an object: " + obj.name + " | " + obj.tag + " " + gameObject.tag + " | " + obj.Equals(gameObject));

        int decision = 0;
        GameObject go = null;

        if (objs.Length == 1)
            decision = 1;
        else
            for (int i = 0; i < objs.Length; i++)
            {
                go = objs[i].gameObject;
                if (go.tag == gameObject.tag)
                {
                    if (go.Equals(gameObject))
                        continue;
                    else
                    {
                        decision = 2;
                        break;
                    }
                }
                else
                {
                    decision = 3;
                    break;
                }
            }

        switch (decision)
        {
            case 0:
                Debug.LogWarning("Something went wrong!");
                break;
            case 1:
                //Debug.Log("I am unique");
                DontDestroyOnLoad(gameObject);
                break;
            case 2:
                //Debug.Log("The world doesn't need 2 of me");
                Destroy(gameObject);
                break;
            case 3:
                //Debug.Log("It's my turn now");
                Destroy(go);
                DontDestroyOnLoad(gameObject);
                break;
        }

        //        {
        //    if (obj.Equals(gameObject))
        //    {
        //        Debug.Log("I am special");
        //        DontDestroyOnLoad(gameObject);
        //    }
        //    else
        //    {
        //        Debug.Log("The world doesn't need 2 of me");
        //        Destroy(gameObject);
        //    }
        //}
        //else
        //{
        //    Debug.Log("It's my turn now");
        //    Destroy(obj);
        //    DontDestroyOnLoad(gameObject);
        //}
    }

    //void Update()
    //{
    //    if (SceneManager.GetActiveScene().name == sceneToBeDestroyed)
    //        Destroy(this.gameObject);
    //}
}
