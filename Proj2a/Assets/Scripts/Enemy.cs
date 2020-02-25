using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Change Notes 2/24/2020: Added a jump function for the enemy (Lines 91 to 108). The enemy jumps
    // when it hits a trigger with the tag "edge". A new prefab was made to act as the
    // edge trigger. - MB

    #region movement_variables
    public float movespeed;
    bool moving;
    public float enemyJumpforceX;
    public float enemyJumpforceY;
    #endregion

    #region physics_components
    Rigidbody2D enemyRB;
    #endregion

    #region targeting_variables
    public Transform player;
    #endregion

    #region Unity_functions

    //runs once on creation
    private void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        moving = true;
    }

    //runs every frame
    private void Update()
    {
        //Debug.Log(transform.position);
        Move();
    }
    #endregion

    #region movement_functions

    //move at player
    private void Move()
    {
        if (moving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * movespeed);
            if (transform.position == player.position)
            {
                //Debug.Log("found player");
                moving = false;
            }
        }
        //StartCoroutine(Investigate(player));
    }

    IEnumerator Investigate(Transform t)
    {
        //Debug.Log("in coroutine");
        while (moving)
        {
            //enemyRB.AddForce(Vector2.right * 0.01f);
            //transform.position = Vector3.Lerp(transform.position, t.position, 0.5f);
            
            transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * movespeed);
            if (transform.position == t.position)
            {
                //Debug.Log("found player");
                moving = false;
            }
            yield return null;
        }
    }
    #endregion

    #region attack_functions
    private void EatPlayer()
    {

        player.GetComponentInParent<PlayerController>().Die();
        Debug.Log("player is dead");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            EatPlayer();
        }

    }
    #endregion

    #region jump_functions
    private void EnemyJump()
    {
        Debug.Log("Dog jumped");
        enemyRB.velocity = new Vector2(enemyRB.velocity.x, 0);
        enemyRB.AddForce(new Vector2(enemyJumpforceX, enemyJumpforceY));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Edge"))
        {
            Debug.Log("Dog Jumped");
            EnemyJump();
        }

    }
    #endregion
}
