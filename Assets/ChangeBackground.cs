using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour {
    public Transform GarbageBackground;
    public Game_Manager Manager;
    public Animator BackAnimator;
    private float CompletionRate; // percentage from 0 to 100
    private int GarbageLevel = 3; // from 0 (none) to 3 (total)

	void Start () {
        GarbageBackground = gameObject.transform.Find("Lixo");
    }
	
	// Update is called once per frame
	void Update () {
        CompletionRate = Manager.ReturnCompletion();
        // Verifies completion rate
        if (CompletionRate == 100 && GarbageLevel > 0) {
            GarbageLevel = 0;
            ChangeTrashLevel();
        } else if (CompletionRate >= 75 && GarbageLevel > 1) {
            GarbageLevel = 1;
            ChangeTrashLevel();
        } else if (CompletionRate >= 50 && GarbageLevel > 2) {
            GarbageLevel = 2;
            ChangeTrashLevel();
        } else if (CompletionRate < 50 && GarbageLevel != 3) {
            GarbageLevel = 3;
            ChangeTrashLevel();
        }
    }

    void ChangeTrashLevel() {
        BackAnimator.SetInteger("CurrBackground", GarbageLevel);

        /*for (int i = 0; i < GarbageBackground.childCount; i++) {
            if (GarbageBackground.GetChild(i).name != ("Lixo" + GarbageLevel)) {
                GarbageBackground.GetChild(i).gameObject.SetActive(false);
            } else {
                GarbageBackground.GetChild(i).gameObject.SetActive(true);
            }
        }*/
    }
}
