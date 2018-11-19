using UnityEngine;

public class PauseMenu : MonoBehaviour {

    private static float OldTimeScale = 1f;
	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;

    void Start() {
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    void Update () {
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume();
			} else {
				Pause();
			}
		}
	}

	public void Resume() {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);

        Time.timeScale = OldTimeScale;
    }
    
	void Pause() {
        GameIsPaused = true;
		pauseMenuUI.SetActive(true);

        OldTimeScale = Time.timeScale;
        Time.timeScale = 0f;
	}
}
