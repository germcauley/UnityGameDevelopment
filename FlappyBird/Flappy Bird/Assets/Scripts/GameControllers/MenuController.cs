using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public static MenuController instance;

    [SerializeField]
    private GameObject[] birds;

    private bool isGreenBirdUnlocked, isRedBirdUnlocked;

    [SerializeField]
    private Animator notificationAnim;

    [SerializeField]
    private Text notificationText;

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        birds[GameControllers.instance.GetSelectedBird()].SetActive(true);
        CheckIfBirdsAreUnlocked();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void CheckIfBirdsAreUnlocked()
    {
        if (GameControllers.instance.IsRedBirdUnlocked() == 1)
        {
            isRedBirdUnlocked = true;
        }

        if (GameControllers.instance.IsGreenBirdUnlocked() == 1)
        {
            isGreenBirdUnlocked = true;
        }
    }

    public void PlayGame()
    {
        SceneFaderScript.instance.FadeIn("Gameplay");
    }

  

    public void ChangeBird()
    {

        if (GameControllers.instance.GetSelectedBird() == 0)
        {

            if (isGreenBirdUnlocked)
            {
                birds[0].SetActive(false);
                GameControllers.instance.SetSelectedBird(1);
                birds[GameControllers.instance.GetSelectedBird()].SetActive(true);
            }

        }
        else if (GameControllers.instance.GetSelectedBird() == 1)
        {

            if (isRedBirdUnlocked)
            {

                birds[1].SetActive(false);
                GameControllers.instance.SetSelectedBird(2);
                birds[GameControllers.instance.GetSelectedBird()].SetActive(true);

            }
            else
            {

                birds[1].SetActive(false);
                GameControllers.instance.SetSelectedBird(0);
                birds[GameControllers.instance.GetSelectedBird()].SetActive(true);

            }

        }
        else if (GameControllers.instance.GetSelectedBird() == 2)
        {
            birds[2].SetActive(false);
            GameControllers.instance.SetSelectedBird(0);
            birds[GameControllers.instance.GetSelectedBird()].SetActive(true);
        }

    }

 
} // class































































