using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; ////

/* PrintScore.cs

    This prints the final score to the EndMenu

*/

public class PrintScore : MonoBehaviour
{
    public Text text; // the text that will show the final score

    // print the final score to the text
    void Start()
    {
        text.text = "Your Score: " + GlobalManager.score.ToString();
    }
}
