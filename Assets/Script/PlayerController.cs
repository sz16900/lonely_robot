using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls input for moving player.
public class PlayerController : MonoBehaviour {


    //movement variables
    public float maxSpeed;

    //jumping variables
    static public bool grounded = false;
    private float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    // Variables exported to CSound.
    public static float wheelVar;
    public static float pinballVar;
    public static float drumVar;
    public static float platformVar;
    public static float skateboardVar;
    public static float christmassVar;
    public static float endVar;

    private CsoundUnity csound;
    [HideInInspector]
    static public bool jump = true;
    static public bool moving = false;
    private Rigidbody2D myRB;
    private Animator myAnim;
    private bool facingRight;
    public float takeOffHeight = 0;

    // Use this for initialization
    void Start() {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        csound = GetComponent<CsoundUnity>();
        wheelVar = 0;
        drumVar = 0;
        platformVar = 0;
    }

    // Update is called once per frame
    void Update() {
        csound.setChannel("absoluteHeightSlider", this.transform.position.y);
        csound.setChannel("wheelSlider", wheelVar);
        csound.setChannel("AfterDemoSlider", drumVar);
        csound.setChannel("PlatformSlider", platformVar);
        csound.setChannel("PinballSlider", pinballVar);
        csound.setChannel("SkateboardSlider", skateboardVar);
        csound.setChannel("CristmasLightsSlider", christmassVar);
        csound.setChannel("EndSlider", endVar);
        SetGrounded();

        if (Input.GetButtonDown("Jump")) {
            SetJump();
        }
        if (grounded && Input.GetAxis("Jump") > 0) {
            Jumping();
        }
        if (!grounded) {
            csound.setChannel("relativeHeightSlider", this.transform.position.y - takeOffHeight);
        }
        if (grounded) {
            csound.setChannel("relativeHeightSlider", 0);
        }
    }

    private void SetGrounded() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // Sets the heght of jump and trigger sound channel.
    private void SetJump() {
        jump = true;
        takeOffHeight = this.transform.position.y;
        csound.setChannel("heightSlider", this.transform.position.y);
    }

    // Sets animation for jumping.
    private void Jumping() {
        grounded = false;
        myAnim.SetBool("isGrounded", false);
        //dont change x axis, only y (because of jumping)
        myRB.AddForce(new Vector2(0, jumpHeight));
    }

    // Fixed is called at a specific ammount of time, so its always exactly the same
    //Becasue the physics engine operates in FixedUpdate
    void FixedUpdate() {

        //check if we are grounded (true or flase). If no, we are falling
        SetGrounded();
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

        if (myRB.velocity.x != 0) {
            //print ("MOVING" + myRB.velocity.x);
            moving = true;
        } else {
            //print ("NOT MOVING");
            moving = false;
        }

        if (move > 0 && !facingRight) {
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

    void OnCollisionEnter2D(Collision2D collision) {
        print("Printting collision" + collision.transform.tag);
        if (collision.transform.tag == "movingPlatform") {
            transform.parent = collision.transform;
        }
        if (collision.transform.tag == "ferrisProximity") {
            csound.setChannel("wheelSlider", 1);
            print("in ferris proximity");
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.transform.tag == "movingPlatform") {
            transform.parent = null;
        }
    }
}
