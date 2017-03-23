using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //movement variables
    public float maxSpeed;

    //jumping variables
    private bool grounded = false;
    private float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    private Rigidbody2D myRB;
    private Animator myAnim;
    private bool facingRight;

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        if (grounded && Input.GetAxis("Jump") > 0) {
            grounded = false;
            myAnim.SetBool("isGrounded", false);
            //dont change x axis, only y (because of jumping)
            myRB.AddForce(new Vector2(0, jumpHeight));
        }
    }


    // Fixed is called at a specific ammount of time, so its always exactly the same
    //Becasue the physics engine operates in FixedUpdate
	void FixedUpdate () {

        //check if we are grounded (true or flase). If no, we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        //remember that every frame we do this
        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        //raw axis does give you the decimals, only -1, 0, 1 ... the other one gives you everything in between
        //is the player pressing a button? if so, take that value and put in move
        float move = Input.GetAxis("Horizontal");
        // get a value regardles of the key they press
        myAnim.SetFloat("speed", Mathf.Abs(move));
        // wow, why change the velocity??! Because this is sort of arcade game. We'll use the rigid body for jumping and what not
        //the y value of this vecotr2d is not being changed
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        } else if (move < 0 && facingRight) {
            flip();

        }
	}

    void flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
