using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; ////

/* StartMenu.cs

    The methods that are used in ButtonEvents for the buttons on the StartMenu

*/

public class StartMenu : MonoBehaviour
{
    // Change the scene to the next scene to start the game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Close the game application 
    public void QuitGame()
    {
        Debug.Log("QUIT"); // this is for testing on the Unity editor
        Application.Quit(); // this will actually close the game application once you've
                            // exported the game
    }
}
