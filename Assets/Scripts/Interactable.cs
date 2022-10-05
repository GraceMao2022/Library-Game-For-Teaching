using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; ////

/* Interactable.cs

    This is a generic script used on objects that you want to interact with. It makes use
    of UnityEvent.

*/

public class Interactable : MonoBehaviour
{
    public bool isInRange; // true if the player is within the range of the interactable object
    public KeyCode interactKey; // the key that the user presses to interact
    public UnityEvent interactAction; // the event that occurs for the interaction


    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            ////GetKeyDown() vs GetKey(): getkeydown does not detect the holding of a key,
            ////which is used here because we don't want the event to fire infinitely
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke(); //Fire Event
            }
        }
    }

    // detect if the player has entered the collider (isTrigger is true) of the interactable object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    // detect if the player has exited the collider (isTrigger is true) of the interactable object
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
