using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealOrNoDeal : MonoBehaviour
{

    public Text resultTxt;
    public Text logTxt;
    public Text boxesLeftTxt;

    public GameObject gameLevelPanelGO;
    public GameObject gameOverPanelGO;

    public int boxesMax = 4;
    public static int[] range = { 10, 100, 1000, 10000, 100000, 1000000 };

    public int box1;
    public int box2;
    public int box3;
    public int box4;
    public int box5;
    public int box6;

    public Text ten;
    public Text hungred;
    public Text thousand;
    public Text tenThousand;
    public Text hungredThousand;
    public Text millione;

    public static int[] result = shuffle(range);



    public int chosenBox;
    public int reservedBox;

    private int totalChosenBoxes;

    private bool isGameOver;







    // Start is called before the first frame update
    void Start()
    {
        if (logTxt == null) this.logTxt = GameObject.Find("logTxt").GetComponent<Text>();
        logTxt.text = "";
        if(boxesLeftTxt ==null) this.boxesLeftTxt = GameObject.Find("boxesLeftTxt").GetComponent<Text>();
        boxesLeftTxt.text = "Boxes left: " + boxesMax;
    }


    public static int[] shuffle(int[] array)
    {
        var rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            int temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
        return array;
    }

    [ContextMenu("Assigner")]
    void AssignArray()
    {

        box1 = result[0];
        box2 = result[1];
        box3 = result[2];
        box4 = result[3];
        box5 = result[4];
        box6 = result[5];
        Debug.Log(box1);
        Debug.Log(box2);
        Debug.Log(box3);
        Debug.Log(box4);
        Debug.Log(box5);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGuessValue(int guessVal)
    {
        chosenBox = guessVal;

    }
    [ContextMenu("Gameplay")]
    public void PlayNext()
    {
        if (reservedBox == -1 && chosenBox != -1)
        {
            reservedBox = chosenBox;
            totalChosenBoxes = 1;
        }
        
        if (isGameOver) return;
        if (totalChosenBoxes < boxesMax)
        {
            if (reservedBox != chosenBox)
            {
                logTxt.text = result[chosenBox - 1] + "$ disappears";
                leftBoxClearing(chosenBox);
                GameObject ob = GameObject.Find("Box" + chosenBox);
                ob.SetActive(false);
                totalChosenBoxes++;
            }
            else
            {
                logTxt.text = "you chosed box № " + chosenBox;
            }


            

            int boxesLeft = boxesMax - totalChosenBoxes;
            boxesLeftTxt.text = "Boxes left to chose: " + boxesLeft;
        }

        if (!isGameOver && totalChosenBoxes == boxesMax)
        {
            isGameOver = true;

            gameLevelPanelGO.SetActive(false);
            gameOverPanelGO.SetActive(true);
            resultTxt.text = "You won with box№ " + reservedBox + "\n Your total: " + result[reservedBox - 1] + "$";
        }
    }
    [ContextMenu("Restart game")]
    public void RestartGame()
    {
        totalChosenBoxes = 0;
        isGameOver = false;
        AssignArray();
        resultTxt.text = "";
    }
    private void leftBoxClearing(int chosenBox)
    {
        if (result[chosenBox-1] == 10) ten.text = "";
        if (result[chosenBox-1] == 100) hungred.text = "";
        if (result[chosenBox-1] == 1000) thousand.text = "";
        if (result[chosenBox-1] == 10000) tenThousand.text = "";
        if (result[chosenBox-1] == 100000) hungredThousand.text = "";
        if (result[chosenBox-1] == 1000000) millione.text = "";
    }

}