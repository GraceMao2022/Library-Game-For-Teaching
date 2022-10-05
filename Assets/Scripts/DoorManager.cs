//Class is for the door

using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    private int nextSceneToLoad;//the number of the next level in Scenes in Build

    /**
    *   Method to move to the next level
    *   Is called when player "interacts" with the door
    */
    public void NextLevel()
    {
         nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;//gets the number of the next level
         SceneManager.LoadScene(nextSceneToLoad);//loads in the next level
    }
}
