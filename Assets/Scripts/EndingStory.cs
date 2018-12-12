using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EndingStory : MonoBehaviour {
    public GameObject[] fundosLixo, frames;
    public Animator fade;
    public TextMeshProUGUI text;
    public LevelChanger levelChanger;
    public SpriteRenderer[] dogSpriteRenderer;
    public Sprite[] sprites;

    // Use this for initialization
    void Start()
    {
        //Debug.Log("OH " + gameObject.name);
        int garbageLevel = 3;
        float completion = StaticProgressManager.GetCompletion();

        if (completion >= 100) {
            garbageLevel = 0;
            NewSprite(2);
            text.SetText("Você reciclou " + completion + "% do lixo eletrônico espalhado.\nParabéns! O mundo agora está mais limpo!");
        } else if (completion >= 75) {
            garbageLevel = 1;
            NewSprite(1);
            text.SetText("Você reciclou " + completion + "% do lixo eletrônico espalhado.\nHuuum... Quase lá, mas ainda existe um pouco de lixo por aí.");
        } else if (completion >= 50) {
            garbageLevel = 2;
            NewSprite(0);
            text.SetText("Você reciclou " + completion + "% do lixo eletrônico espalhado.\nNossa. Poderia ter se esforçado um pouco mais!");
        } else {
            garbageLevel = 2;
            NewSprite(0);
            text.SetText("Você reciclou " + completion + "% do lixo eletrônico espalhado.\nNossa. Poderia ter se esforçado um pouco mais!");
            // That's impossible, since the player needs at least 50% to end the game
            Debug.LogError("Something's wrong! Check EndingStory script");
        }

        foreach (GameObject fundo in fundosLixo) {
            if (fundo.name != ("Lixo" + garbageLevel)) {
                fundo.SetActive(false);
            } else {
                fundo.SetActive(true);
            }
        }
    }

    public void NewSprite(int spriteId) {
        foreach (SpriteRenderer dog in dogSpriteRenderer) {
            dog.sprite = sprites[spriteId];
        }
    }

    public void OnAnimationEnd() {
        fade.SetTrigger("FadeOut");
    }

    public void OnFadeEnd() {
        frames[0].SetActive(false);
        frames[1].SetActive(true);
    }

    public void OnClick() {
        levelChanger.FadeToScene(2);
    }
}
