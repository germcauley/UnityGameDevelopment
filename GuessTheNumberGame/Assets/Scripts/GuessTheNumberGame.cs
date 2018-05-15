using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessTheNumberGame : MonoBehaviour {

    public InputField input;
    public Text infoText;

    private int guessNumber;
    private int usersGuess;


	// Use this for initialization
	void Start () {
        guessNumber = Random.Range(0, 100);
	}
	
	// Update is called once per frame
	public void CheckGuess()
    {
        usersGuess = int.Parse(input.text);

        if(usersGuess == guessNumber)
        {
            infoText.text = "You guessed the correct number!";
        }else if(usersGuess > guessNumber)
        {
            infoText.text = "You guessed too high!";

        }else if(usersGuess < guessNumber)
        {
            infoText.text = "You guessed too low!";

        }
        input.text = "";
    }
}
