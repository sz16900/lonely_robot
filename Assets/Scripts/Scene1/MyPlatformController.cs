using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlatformController : MonoBehaviour {
	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = true;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public float takeOffHeight = 0;
	public Transform groundCheck;
	private CsoundUnity csound;
	//private Transform playerTransform;
	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	//public Vector3 playerPos;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		csound = GetComponent<CsoundUnity> ();
		//float ypos = GameObject.Find("hero").transform.position.y;
		//csound.setChannel ("heightSlider", ypos);
		//playerTransform = GetComponent<>
		//Vector3 playerPos =  GameObject.Find("hero").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//float ypos = GameObject.Find("Player").transform.position.y;
		//float ypos = this.transform.position.y;
		//CharacterController controller = GetComponent<CharacterController>();

		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		csound.setChannel ("absoluteHeightSlider", this.transform.position.y);

		if(Input.GetButtonDown("Jump") && grounded){
			jump = true;
			//float jumpheight = this.transform.position.y;
			//csound.setChannel ("jumpSlider", this.transform.position.y);
			takeOffHeight = this.transform.position.y;
			print ("JUMP");
			//csound.setChannel ("heightSlider", this.transform.position.y);

		}
		if (!grounded) {
			csound.setChannel ("relativeHeightSlider", this.transform.position.y - takeOffHeight);
			print (this.transform.position.y - takeOffHeight);
		} 
		if (grounded) {
			csound.setChannel ("relativeHeightSlider", 0);
		} 
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (h));
		if (h * rb2d.velocity.x < maxSpeed) {
			rb2d.AddForce (Vector2.right * h * moveForce);
		}
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}	
		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();

		if (jump) {
			anim.SetTrigger ("Jump");
			rb2d.AddForce (new Vector2 (0f, jumpForce));
			jump = false;
		}
	}	




	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale; 
	}
}
