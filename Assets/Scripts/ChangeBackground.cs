using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour {
    public Transform garbageBackground;
    public Game_Manager manager;
    public Animator backAnimator;
    private float completionRate; // percentage from 0 to 100
    private int garbageLevel = 3; // from 0 (none) to 3 (total)

	void Start () {
        garbageBackground = gameObject.transform.Find("Lixo");
    }
	
	// Update is called once per frame
	void Update () {
        completionRate = manager.ReturnLevelCompletion();
        //Debug.Log(completionRate);
        // Verifies completion rate
        if (completionRate == 100 && garbageLevel > 0) {
            garbageLevel = 0;
            ChangeTrashLevel();
        } else if (completionRate >= 75 && garbageLevel > 1) {
            garbageLevel = 1;
            ChangeTrashLevel();
        } else if (completionRate >= 50 && garbageLevel > 2) {
            garbageLevel = 2;
            ChangeTrashLevel();
        } else if (completionRate < 50 && garbageLevel != 3) {
            garbageLevel = 3;
            ChangeTrashLevel();
        }
    }

    void ChangeTrashLevel() {
        backAnimator.SetInteger("CurrBackground", garbageLevel);

        /*for (int i = 0; i < GarbageBackground.childCount; i++) {
            if (GarbageBackground.GetChild(i).name != ("Lixo" + GarbageLevel)) {
                GarbageBackground.GetChild(i).gameObject.SetActive(false);
            } else {
                GarbageBackground.GetChild(i).gameObject.SetActive(true);
            }
        }*/
    }
}
