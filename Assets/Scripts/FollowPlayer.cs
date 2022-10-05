using UnityEngine;
//class is for the Camera, makes the camera follow the player
public class FollowPlayer : MonoBehaviour
{
    public Transform player;//what we the camera to follow, the player object

    public Vector3 offset;//stores 3 floats
    ////this will be the distance between the camera and the player, since we want the player to be in the middle, we will only be changing
    ////the z value to -10, everything else we will leave at 0
    ////need to change the z value since even though this is 2d, the game is set on a 3d plane and the camera will be behind the game if 
    //// z not changed

    /**
    *Updates every frame, makes sure that the camera's position is on the player
    */
    void Update()
    {
        transform.position = player.position + offset;//changes the camera's position to be the focused on the player
    }
}
