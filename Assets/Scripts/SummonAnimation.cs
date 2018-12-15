using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAnimation : MonoBehaviour
{
    public GameObject animationObject;

    public Placeholder flag;

    void Start()
    {
        flag = new Placeholder();
        flag.a = 1;
    }

	public void Summon ()
    {
        if (animationObject != null)
            Instantiate(animationObject, transform.position, Quaternion.identity);
    }

    public void SummonAndDestroy() { Instantiate(animationObject, transform.position, Quaternion.identity); Destroy(gameObject); }

    public bool LockAndCheck()
    {
        lock(flag)
        {
            if (flag.a == 1)
            {
                flag.a = 0;
                return true;
            }
        }

        return false;
    }
}
