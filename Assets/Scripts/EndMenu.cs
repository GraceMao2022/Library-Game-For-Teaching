using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; ////

/* EndMenu.cs

    The methods that are used in ButtonEvents for the buttons on the EndMenu

*/

public class EndMenu : MonoBehaviour
{
    // Changes the scene back to the StartMenu to replay the game
    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }

    // Close the game application 
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
