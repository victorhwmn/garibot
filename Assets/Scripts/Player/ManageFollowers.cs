using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFollowers : MonoBehaviour
{
    public GameObject followerPrefab;
    public Transform followerPoint;

    private GameObject[] followers;
    private int nFollowers = 0;

    private bool go = false;

	void Start () { followers = new GameObject[40]; }

    public int GetNFollowers() { return nFollowers; }

    public void CreateNewFollower()
    {
        if (nFollowers == 0)
        {
            GameObject go = Instantiate(followerPrefab, followerPoint.position, Quaternion.identity);
            followers[0] = go;
            go.GetComponent<Follower>().leader = followerPoint;

            float scale = Random.Range(.3f, 1f);
            go.transform.localScale = new Vector3(scale, scale, 1f);

            nFollowers++;
        }
        else
        {
            GameObject go = Instantiate(followerPrefab, followers[nFollowers-1].transform.position, Quaternion.identity);
            followers[nFollowers] = go;

            float scale = Random.Range(.3f, 1f);
            go.transform.localScale = new Vector3(scale, scale, 1f);

            go.GetComponent<Follower>().leader = followers[nFollowers-1].transform;
            nFollowers++;
        }
    }

    public void CreateNewFollower(Sprite sprite)
    {
        if (nFollowers == 0)
        {
            GameObject go = Instantiate(followerPrefab, followerPoint.position, Quaternion.identity);
            go.GetComponent<SpriteRenderer>().sprite = sprite;
            go.GetComponent<Animator>().enabled = false;

            followers[0] = go;
            go.GetComponent<Follower>().leader = followerPoint;

            float scale = Random.Range(.3f, 1f);
            go.transform.localScale = new Vector3(scale, scale, 1f);

            nFollowers++;
        }
        else
        {
            GameObject go = Instantiate(followerPrefab, followers[nFollowers - 1].transform.position, Quaternion.identity);
            go.GetComponent<SpriteRenderer>().sprite = sprite;
            go.GetComponent<Animator>().enabled = false;

            followers[nFollowers] = go;

            float scale = Random.Range(.3f, 1f);
            go.transform.localScale = new Vector3(scale, scale, 1f);

            go.GetComponent<Follower>().leader = followers[nFollowers - 1].transform;
            nFollowers++;
        }
    }

    public void ClearAllFollowers()
    {
        Game_Manager gm = GameObject.Find("Manager").GetComponent<Game_Manager>();
        //Debug.Log(nFollowers + " + " + gm.GetRetrieveAmount() + " = " + gm.GetTotalExisting());
        go = false;
        if (nFollowers + gm.GetRetrieveAmount() >= gm.GetTotalExisting())
            go = true;

        StartCoroutine(StartClearAllFollowers());
    }
    public IEnumerator StartClearAllFollowers()
    {
        if (nFollowers == 0)
            yield return new WaitForSeconds(0f);
        else
        {
            for (int i = 0; i < nFollowers-1; i++)
            {
                followers[i+1].GetComponent<Follower>().leader = followerPoint;
                followers[i].GetComponent<Follower>().DestroyWithoutAnimate();
                yield return new WaitForSeconds(.1f);
            }

            if (go)
            {
                //Debug.Log("No animation");
                followers[nFollowers-1].GetComponent<Follower>().DestroyAndAnimate();
            }
            else
            {
                //Debug.Log("With animation");
                followers[nFollowers-1].GetComponent<Follower>().DestroyWithoutAnimate();
            }

            nFollowers = 0;
        }
    }

    public void RestartAllFollowers()
    {
        //if (nFollowers == 0)
        //    return;

        for (int i = 0; i < nFollowers; i++)
            followers[i].transform.position = new Vector3(followerPoint.position.x, followerPoint.position.y, followerPoint.position.z);
    }

}
