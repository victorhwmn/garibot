using UnityEngine.UI;
using UnityEngine;

public class Storyboard : MonoBehaviour {

    public Sprite []pannels;
    public Image imageFrame;

    public Sprite finalText;
    public Image textFrame;
    private int currentPannel;

    public LevelChanger levelChanger;

	// Use this for initialization
	void Start () {
		if (pannels.Length > 0) {
            imageFrame.sprite = pannels[0];
            currentPannel = 0;
        }
	}
	
	public void OnClick () {
        currentPannel++;
        if (currentPannel >= pannels.Length - 1) {
            textFrame.sprite = finalText;
        }

        if (currentPannel < pannels.Length) {
            imageFrame.sprite = pannels[currentPannel];
        } else {
            levelChanger.FadeToNextScene();
        }
    }
}
