using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //Setting text for the timer
    public Text timerMinutes;
    public Text timerSeconds;
    public Text timerSeconds100;

    //Setting variables for timer
    private float startTime;
    private float stopTime = 0;
    private float timerTime;
    private bool isRunning = true;

    //Getting text from UI and count for the reward to beat the game
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count;

    // Use this for initialization
    void Start()
    {
        //Setting starting time
        startTime = Time.time;

        //Setting the count for the reward to beat the game
        count = 0;

        //Setting the function get count text
        SetCountText();

        //Setting win text to false so it becomes true once the player has won
        winTextObject.SetActive(false);
    }

    public void TimerStart()
    {
        //How to start the timer when the game stops
        if (isRunning)
        {
            print("START");
            isRunning = true;
            startTime = Time.time;
        }
    }

    public void TimerStop()
    {
        //How to stop timer once the reward is collected
        if (isRunning)
        {
            print("STOP");
            isRunning = true;
        }
    }

    public void TimerReset()
    {
        //How to reset the timer once the game resets
        print("RESET");
        stopTime = 0;
        isRunning = true;
        timerMinutes.text = timerSeconds.text = timerSeconds100.text = "00";
    }

    // Update is called once per frame
    void Update()
    {
        //Setting up variables to run timer
        timerTime = stopTime + (Time.time - startTime);
        int minutesInt = (int)timerTime / 60;
        int secondsInt = (int)timerTime % 60;
        int seconds100Int = (int)(Mathf.Floor((timerTime - (secondsInt + minutesInt * 60)) * 100));

        //How timer continues to run once the game starts
        if (isRunning)
        {
            timerMinutes.text = (minutesInt < 10) ? "0" + minutesInt : minutesInt.ToString();
            timerSeconds.text = (secondsInt < 10) ? "0" + secondsInt : secondsInt.ToString();
            timerSeconds100.text = (seconds100Int < 10) ? "0" + seconds100Int : seconds100Int.ToString();
        }

        //How to make sure timer stops once reward is picked up
        if (count >= 1)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        //How to make scene reset once reward is picked up
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // EXZ_EXZ comment
    }

    private void OnTriggerEnter(Collider other)
    {
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("Pickup"))
        {
            //How to make reward disappear once it's collected
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }
    }

    public void SetCountText()
    {
        //How to set reward text
        countText.text = "Rewards: " + count.ToString();

        //Make win text show up
        if (count >= 1)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
            isRunning = false;
        }
    }
}
