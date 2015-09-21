using UnityEngine;
using System.Collections;

public class ClearTrigger : MonoBehaviour
{

    GameObject gameController;
    
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }

    void OnTriggerExit2D (Collider2D other)
    {
        gameController.SendMessage("IncreaseScore");
    }
    
}
