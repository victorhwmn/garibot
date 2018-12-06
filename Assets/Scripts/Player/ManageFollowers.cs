using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageFollowers : MonoBehaviour
{
    public GameObject followerPrefab;
    public Transform followerPoint;

    private GameObject[] followers;
    private int nFollowers = 0;

	void Start () { followers = new GameObject[20]; }

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

    public void ClearAllFollowers()
    {
        if (nFollowers == 0)
            return;

        for (nFollowers--; nFollowers > 0; nFollowers--)
        {
            followers[nFollowers].GetComponent<SummonAnimation>().Summon();
            Destroy(followers[nFollowers]);
        }
        Destroy(followers[nFollowers]);
    }

    public void RestartAllFollowers()
    {
        //if (nFollowers == 0)
        //    return;

        for (int i = 0; i < nFollowers; i++)
            followers[i].transform.position = new Vector3(followerPoint.position.x, followerPoint.position.y, followerPoint.position.z);
    }

}
