using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Debug.Log("hit player");
            GameObject playergm = coll.gameObject;
            //playergm.GetComponent<PlayerController>
            playergm.GetComponent<PlayerController>().SavePlayerState();
            GameObject gm = GameObject.FindWithTag("GameController");
            gm.GetComponent<GameManager>().WinGame();
        }
    }
}
