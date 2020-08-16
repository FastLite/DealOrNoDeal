using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.UI; // this is to make referecnes

public class GuessTheDoor : MonoBehaviour

{

    public Text resultTxtField; // this is too hook code to the UI
    public Text guessesLeftTxtField;

    public GameObject gameLevelPanelGO;
    public GameObject gameOverPanelGO;

    //DOOR1 DOOR2 DOOR3 DOOR4 DOOR5

    private int maxDoors = 5;
    public int maxGuesses = 2; // max number of guesses

    public int chosenDoor; // player selected door


    //[SerializeField] 
    private int randomDoor; // script will generate random door with prize

    private int totalGuesses; //keeping the track of guesses

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomDoor();
        resultTxtField.text = "Welcome ! Now chose the door";
    }

    //Our first function as it known if c#
    [ContextMenu("Test Rand Generator")]
    void GenerateRandomDoor()
    {
        randomDoor = UnityEngine.Random.Range(1, maxDoors + 1);
        //resultTxtField.text = "Yay new game ! This is a test " + randomDoor;
        Debug.Log("Yay new game ! This is a test " + randomDoor);
        guessesLeftTxtField.text = (maxGuesses - totalGuesses) + " guesses left";

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void SetGuessValue(int guessVal) //this function will be called from the UI, it will pass the value we enter int he UI to the chosenDoor variable
    {
        chosenDoor = guessVal;
        //PlayNext();

    }

    [ContextMenu("Test Gameplay")]
    public void PlayNext()
    {

        guessesLeftTxtField.text = (maxGuesses - totalGuesses - 1)  + " guesses left";

        if (isGameOver) return;
        if (totalGuesses < maxGuesses)
        {
            if (chosenDoor == randomDoor)
            {
                resultTxtField.text = "you guesssed the right door! treasure is yours.";
                Debug.Log("you guesssed the right door! treasure is yours.");
                isGameOver = true; // game is over, it's important

                gameLevelPanelGO.SetActive(false);
                gameOverPanelGO.SetActive(true);
            }
            else
            {
                resultTxtField.text = "Wrong. Try again ? ";
                Debug.Log("Wrong. Try again ? ");

            }

            totalGuesses++;
        }
        // || = or
        // && = and
        // ! = not
        if (isGameOver != true && totalGuesses == maxGuesses) //isGameOver !=true = !isGameOver
        {
            //what to do ?
            //end game
            //let the user know about ending
            //
            resultTxtField.text = "Game Over -- maximum reached The right door was door number " + randomDoor;
            Debug.Log("Game Over -- maximum reached");
            isGameOver = true;
            Debug.Log("The right door was door number " + randomDoor);

            gameLevelPanelGO.SetActive(false);
            gameOverPanelGO.SetActive(true);
        }
    }

    [ContextMenu("Test restar game")]
    public void RestartGame()
    {
         if (isGameOver == true)
        {
            isGameOver = false;
            totalGuesses = 0;
            randomDoor = 0;
            GenerateRandomDoor();
            resultTxtField.text = "Welcome ! Now chose the door";

            gameLevelPanelGO.SetActive(true);
            gameOverPanelGO.SetActive(false);
        }
    }

}

