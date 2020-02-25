using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Change Notes 2/24/20: I added the condition "&& canJump()" to the move right if statement (Line 64)
    // to deal with the weird physics where you can move while in the air. This means that the player
    // cannot move right if they are in the air. To deal with not being able to move right while jumping,
    // I added a jumpforceX variable to the jump code (Line 80) to give the player horizontal velocity
    // to make a jump to the next platform. - MB

    // Change Notes 2/25/20: I added a call method in the Point Functions region to show the points
    // the player has on the screen. Specifically, I added Line 34 and Line 109. - MB
  
    #region movement_variables
    public float movespeed;
    public float jumpforceY;
    public float jumpforceX;
    float x_input;
    float y_input;
    private bool shouldJump;
    //private bool canJump;
    Vector2 currDirection;
    public bool feetContact;
    #endregion

    #region points_variables
    public float points;
    public float globPoints;
    float currPoints;
    public Slider pointsSlider;
    [SerializeField] Text pointUIText;
    #endregion

    #region physics_components
    Rigidbody2D playerRB;
    #endregion

    #region Unity_functions

    //called once on creation
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        currPoints = GlobalControl.Instance.points;
    }

    //called every frame
    private void Update()
    {

        //access input values
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");

        Move();
    }
    #endregion

    #region movement_functions

    //moves or jumps player based on keyboard input and movespeed
    private void Move()
    {
        //if player is pressing right key
        if ((x_input > 0) && canJump())
        {
            
            Debug.Log("right button pressed");
            playerRB.velocity = Vector2.right * movespeed;


        }

        //if player is pressing spacebar
            else if (Input.GetKeyDown(KeyCode.Space) && canJump())
            {
                Debug.Log("space bar pressed");
                playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
                //playerRB.AddForce(Vector2.up * jumpforce);
                playerRB.AddForce(new Vector2(jumpforceX, jumpforceY));
            }
    }

    bool canJump()
    {
        return feetContact;
    }
    #endregion



    #region points_functions

    //gain points if hitting objects
    public void GainPoints(float value)
    {

        //increment points
        currPoints += value;
        Debug.Log("Points is now " + currPoints.ToString());

        pointUIText.text = ("Points: " + currPoints.ToString());
        
    }

    public void SavePlayerState()
    {
        GlobalControl.Instance.points = currPoints;
    }

    //Destroy player + end scene
    public void Die()
    {
        //destroy gameobject
        Destroy(this.gameObject);

        //trigger anything to end game - find game manager and lose game

        GameObject gm = GameObject.FindWithTag("GameController");
        Debug.Log("Died");
        gm.GetComponent<GameManager>().LoseGame();
    }
    #endregion

}
