using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{

    #region carrotpoints_variables
    [SerializeField]
    [Tooltip("Giving player points for eating carrot")]
    private int carrotPoints;
    #endregion

    #region functions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerController>().GainPoints(carrotPoints);
            //sound effect
            Destroy(gameObject);
        }
    }
    #endregion
}
