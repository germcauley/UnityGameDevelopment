using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public static MenuController instance;

    [SerializeField]
    private GameObject[] birds;

    private bool isGreenBirdUnlocked, isRedBirdUnlocked;

    private void Awake()
    {
        MakeInstance();
    }


    // Use this for initialization
    void Start () {
		
	}

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void CheckIfBirdsAreUnlocked()
    {
        if(GameControllers.instance.IsRedBirdUnlocked () == 1)
        {
            isRedBirdUnlocked = true;
        }

        if(GameControllers.instance.IsGreenBirdUnlocked () ==1)
        {
            isGreenBirdUnlocked = true;
        }
    }


    public void ChangeBird()
    {
        if(GameControllers.instance.GetSelectedBird() == 0)
        {
            if (isGreenBirdUnlocked)
            {
                birds[0].SetActive(false);
                GameControllers.instance.SetSelectedBird(1);
                birds [GameControllers.instance.GetSelectedBird()].SetActive(true);

            }else if (GameControllers.instance.GetSelectedBird () == 1)
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
            } else if (GameControllers.instance.GetSelectedBird() == 2)
            {
                birds[2].SetActive(false);
                GameControllers.instance.SetSelectedBird(0);
                birds[GameControllers.instance.GetSelectedBird()].SetActive(true);

            }
        }
    }




	
	// Update is called once per frame
	void Update () {
		
	}
}
