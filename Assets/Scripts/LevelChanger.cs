using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    private static int sceneToLoad;

    // Load without fading
    public void LoadScene (int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    // Fade before loading (needs LevelChanger prefab)
    public void FadeToScene (int sceneIndex) {
        sceneToLoad = sceneIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(sceneToLoad);
    }
}
