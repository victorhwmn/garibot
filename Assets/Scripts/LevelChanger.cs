using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    private static int sceneToLoad;

    // Load without fading
    public void LoadScene (int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    // Fades before loading (needs LevelChanger prefab)
    public void FadeToScene (int sceneIndex) {
        sceneToLoad = sceneIndex;
        animator.SetTrigger("FadeOut");
    }

    // Fades before loading next scene (needs LevelChanger prefab)
    public void FadeToNextScene() {
        FadeToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(sceneToLoad);
    }
}
