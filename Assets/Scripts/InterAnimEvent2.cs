using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterAnimEvent2 : MonoBehaviour {
    public EndingStory script;
    // f*** unity
    public void OnEvent() {
        script.OnFadeEnd();
    }
}
