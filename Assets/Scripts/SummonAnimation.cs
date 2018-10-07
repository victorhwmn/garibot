using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAnimation : MonoBehaviour
{
    public GameObject animationObject;
	public void Summon () { Instantiate(animationObject, transform.position, Quaternion.identity); }
}
