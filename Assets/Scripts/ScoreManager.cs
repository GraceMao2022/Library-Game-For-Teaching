using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; ////
using UnityEngine.SceneManagement; ////

/* ScoreManager.cs

    This is the score manager that changes the score and resets the score, and
    puts the score onto text shown on the screen

*/

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // creates a static instance of ScoreManager. This allows
                                        // other classes to access its methods through ScoreManager.method()
    public Text text; // the Text object on our Canvas that displays the score

    void Start()
    {
        // initializing instance of ScoreManager
        if (instance == null)
        {
            instance = this;
        }

       // reset score stored in GlobalManager when level 1
       if(SceneManager.GetActiveScene().buildIndex == 1)
            GlobalManager.score = 0; ////create GlobalManager at this step

        // initialize score text for each level
        text.text = "X" + GlobalManager.score.ToString();
    }

    // change the total score depending on the value of the coins (gems)
    public void ChangeScore(int coinValue)
    {
        GlobalManager.score += coinValue;
        //Debug.Log(score.ToString());

        // set the text to X#
        text.text = "X" + GlobalManager.score.ToString();
    }

    // reset total score to 0
    public void ResetScore()
    {
        GlobalManager.score = 0;
    }
}
