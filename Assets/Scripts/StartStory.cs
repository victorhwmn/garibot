using UnityEngine.UI;
using UnityEngine;

public class StartStory : MonoBehaviour {
    public GameObject[] fundosLixo;
    public LevelChanger levelChanger;


    // Use this for initialization
    void Start()
    {
        return;

        int garbageLevel = 3;
        float completion = StaticProgressManager.GetCompletion();

        if (completion >= 100)
        {
            garbageLevel = 0;
        }
        else if (completion >= 75)
        {
            garbageLevel = 1;
        }
        else if (completion >= 50)
        {
            garbageLevel = 2;
        }
        else
        {
            garbageLevel = 2;
            // That's impossible, since the player needs at least 50% to end the game
            Debug.LogError("Something's wrong! Check StartStory script");
        }

        foreach (GameObject fundo in fundosLixo)
        {
            if (fundo.name != ("Lixo" + garbageLevel))
            {
                fundo.SetActive(false);
            }
            else
            {
                fundo.SetActive(true);
            }
        }
    }
    public void OnClick()
    {
        levelChanger.FadeToScene(3);
        StaticProgressManager.SetCompletion(0);
    }
}
