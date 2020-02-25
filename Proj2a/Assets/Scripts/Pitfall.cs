using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{
    #region targeting_variables
    public Transform player;
    #endregion

    #region Unity_functions

    //runs once on creation
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    #endregion

    #region pitfall_functions
    private void Playerfalls()
    {

        player.GetComponentInParent<PlayerController>().Die();
        Debug.Log("player is dead");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pitfall"))
        {
            Playerfalls();
        }

    }
    #endregion
}
