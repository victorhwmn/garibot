using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;
    private float distPlayer;

    [SerializeField]
    private GameObject previousCopy = null;
    [SerializeField]
    private GameObject followingCopy = null;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = new Vector3(13.5f, 0f, 0f);
        distPlayer = 0f;

        SetUp();
    }

    public void SetDistPlayer(float f) { distPlayer = f; }
    public void SetPreviousCopy(GameObject c) { previousCopy = c; }
    public void SetFollowingCopy(GameObject c) { followingCopy = c; }
    public float GetDistPlayer() { return distPlayer; }

    // Update is called once per frame
    void Update ()
    {
        previousCopy.transform.position = transform.position - offset;
        followingCopy.transform.position = transform.position + offset;

        //Debug.Log(gameObject.name + " " + (player.position.x - transform.position.x) + " - " + distPlayer);

        Correct();
    }

    public void SetUp()
    {
        //Debug.Log("SetUp: " + (previousCopy == null) + " " + (followingCopy == null));
        if (previousCopy == null)
        {
            previousCopy = Instantiate(gameObject, transform.position - offset, transform.rotation);
            Destroy(previousCopy.GetComponent<RepeatBackground>());
            //previousCopy.name = "Fundo (Previous)";
        }

        if (followingCopy == null)
        {
            followingCopy = Instantiate(gameObject, transform.position + offset, transform.rotation);
            Destroy(followingCopy.GetComponent<RepeatBackground>());
            //followingCopy.name = "Fundo (Following)";
        }
    }

    private void Correct()
    {
        if ((player.position.x - transform.position.x) > 13.5f)
        {
            distPlayer = 13.5f + distPlayer;
        }
        if ((player.position.x - transform.position.x) < 0f)
        {
            distPlayer = distPlayer - 13.5f;
        }
        //Se a copia anterior for a mais próxima do player
        //if (Vector2.Distance(previousCopy.transform.position, player.position) < Vector2.Distance(followingCopy.transform.position, player.position))
        //if (Mathf.Abs(previousCopy.transform.position.x - player.position.x) < Mathf.Abs(followingCopy.transform.position.x - player.position.x))
        //{
        //    Destroy(followingCopy);
        //    previousCopy.GetComponent<RepeatBackground>().enabled = true;
        //    previousCopy.GetComponent<RepeatBackground>().SetFollowingCopy(gameObject);
        //    previousCopy.GetComponent<RepeatBackground>().SetPreviousCopy(null);
        //    previousCopy.GetComponent<RepeatBackground>().SetUp();
        //    previousCopy.GetComponent<RepeatBackground>().SetDistPlayer((13.5f / 2f) + distPlayer);
        //    previousCopy.name = "Fundo";
        //    gameObject.name = "Fundo (Following)";
        //    enabled = false;

        //}
        //else //Se a copia seguinte for a mais próxima do player
        //{
        //    Destroy(previousCopy);
        //    followingCopy.GetComponent<RepeatBackground>().enabled = true;
        //    followingCopy.GetComponent<RepeatBackground>().SetPreviousCopy(gameObject);
        //    followingCopy.GetComponent<RepeatBackground>().SetFollowingCopy(null);
        //    followingCopy.GetComponent<RepeatBackground>().SetUp();
        //    followingCopy.GetComponent<RepeatBackground>().SetDistPlayer((13.5f / 2f) + distPlayer);
        //    followingCopy.name = "Fundo";
        //    gameObject.name = "Fundo (Previous)";
        //    enabled = false;
        //}
    }
}
