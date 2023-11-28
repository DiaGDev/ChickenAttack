using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour
{
    // list to store objects inside the collider
    private List<GameObject> detectedObjects = new List<GameObject>();

    // add objects to the list when they enter the collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!detectedObjects.Contains(other.gameObject))
        {
            detectedObjects.Add(other.gameObject);
        }
    }

    // remove objects from the list when they exit the collider
    void OnTriggerExit2D(Collider2D other)
    {
        if (detectedObjects.Contains(other.gameObject))
        {
            detectedObjects.Remove(other.gameObject);
        }
    }

    // print the list of objects when the space key is pressed
    void Update()
    {
        bool foundPlayer1 = false;
        bool foundPlayer2 = false;

        foreach (GameObject obj in detectedObjects)
        {
            if (obj.CompareTag("Player1"))
            {
                foundPlayer1 = true;
            }
            else if (obj.CompareTag("Player2"))
            {
                foundPlayer2 = true;
            }
        }

        if (foundPlayer1 && foundPlayer2)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
