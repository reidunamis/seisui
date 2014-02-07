using UnityEngine;
using System.Collections;


public class CharController : MonoBehaviour {
	
	protected Animator animator;

	public float maxSpeed = 4f;
	bool facingLeft = true;
	public static bool grounded = false;
	bool walled = false;
	bool hurted = false;
	public Transform groundCheck;
	public Transform wallCheckA;
	public Transform wallCheckB;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 15f;
	
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	void FixedUpdate () 
	{	
	}

	void Update ()
	{
		
		//get the current state
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		walled = Physics2D.OverlapArea(wallCheckA.position, wallCheckB.position, whatIsGround);
		hurted = stateInfo.IsName("Hurt");
		animator.SetBool("Grounded", grounded);
		
		animator.SetFloat ("SpeedVertical", rigidbody2D.velocity.y);
		
		float h = Input.GetAxis("Horizontal");
		if(!hurted)
		{
			if(!walled && !stateInfo.IsName("Attack ground"))
			{
				float speed = h*maxSpeed;
				
				rigidbody2D.velocity = new Vector2(speed,rigidbody2D.velocity.y);
				animator.SetFloat("Speed", Mathf.Abs(h));
			}
			else
			{			
				rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
				animator.SetFloat("Speed", 0);
			}
			if(grounded && Input.GetButton("Jump"))
			{
				animator.SetBool("Grounded",false);
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,jumpForce);
			}
		}
		
		if(h < 0 && !facingLeft)
		{
			Flip ();
		}
		else if(h > 0 && facingLeft)
		{
			Flip ();
		}
	}

	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}