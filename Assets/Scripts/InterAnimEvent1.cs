using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterAnimEvent1 : MonoBehaviour {
    public EndingStory script;
    // f*** unity
    public void OnEvent() {
        script.OnAnimationEnd();
    }
}
