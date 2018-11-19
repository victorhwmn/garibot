using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public Sprite imageOn;
    private bool isOn = false;

    public void Activate() {
        gameObject.GetComponent<SpriteRenderer>().sprite = imageOn;
        isOn = true;
    }

    public bool GetIsOn() {
        return isOn;
    }
}
