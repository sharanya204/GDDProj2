using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLose : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D coll)
    {

        //if three lives are up
        if (coll.CompareTag("Player"))
        {
            Debug.Log("hit player");
            GameObject gm = GameObject.FindWithTag("GameController");
            gm.GetComponent<GameManager>().LoseGame();
        }
    }
}
