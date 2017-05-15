using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	//movement variables
	public float maxSpeed;

	//jumping variables
	static public bool grounded = false;
	private float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	public static float wheelVar;// important
	public static float pinballVar;// important
	public static float drumVar;// important
	public static float platformVar;// important
	public static float skateboardVar;// important
	public static float christmassVar;// important
	public static float endVar;// important

	private CsoundUnity csound;
	[HideInInspector] static public bool jump = true;  
	static public bool moving = false;
	private Rigidbody2D myRB;
	private Animator myAnim;
	private bool facingRight;
	public float takeOffHeight = 0;
	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
		csound = GetComponent<CsoundUnity> ();
		wheelVar = 0;
		drumVar = 0;
		platformVar = 0;
	}

	// Update is called once per frame
	void Update() {
		csound.setChannel ("absoluteHeightSlider", this.transform.position.y);
		csound.setChannel ("wheelSlider", wheelVar);
		csound.setChannel ("AfterDemoSlider", drumVar);
		csound.setChannel ("PlatformSlider", platformVar);
		csound.setChannel ("PinballSlider", pinballVar);
		csound.setChannel ("SkateboardSlider", skateboardVar);
		csound.setChannel ("CristmasLightsSlider", christmassVar);
		csound.setChannel ("EndSlider", endVar);
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

		if (grounded && Input.GetAxis("Jump") > 0) {
			//if(Input.GetButtonDown("Jump") && grounded){

			grounded = false;
			myAnim.SetBool("isGrounded", false);
			//dont change x axis, only y (because of jumping)
			myRB.AddForce(new Vector2(0, jumpHeight));
			//takeOffHeight = this.transform.position.y;
			//csound.setChannel ("heightSlider", this.transform.position.y);

			//print ("----------------------------------------------JUMP");
		}
		if(Input.GetButtonDown("Jump")){
			jump = true;
			////float jumpheight = this.transform.position.y;
			////csound.setChannel ("jumpSlider", this.transform.position.y);
			takeOffHeight = this.transform.position.y;
			//print ("JUMP");
			csound.setChannel ("heightSlider", this.transform.position.y);

		}
		if (!grounded) {
			csound.setChannel ("relativeHeightSlider", this.transform.position.y - takeOffHeight);
			//print ("relative thing" + (this.transform.position.y - takeOffHeight));
		} 
		if (grounded) {
			csound.setChannel ("relativeHeightSlider", 0);
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



		if (myRB.velocity.x != 0)
		{
			//print ("MOVING" + myRB.velocity.x);
			moving = true;
		}
		else{
			//print ("NOT MOVING");
			moving = false;
		}


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

	void OnCollisionEnter2D(Collision2D collision)
	{
		print ("Printting collision" + collision.transform.tag);
		if (collision.transform.tag == "movingPlatform")
		{
			transform.parent = collision.transform;
		}
		if (collision.transform.tag == "ferrisProximity")
		{
			csound.setChannel ("wheelSlider", 1);
			print ("in ferris proximity");
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.transform.tag == "movingPlatform")
		{
			transform.parent = null;
		}
	}
}
