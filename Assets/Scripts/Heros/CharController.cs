using UnityEngine;
using System.Collections;


public class CharController : MonoBehaviour {
	
	protected Animator animator;

	public float maxSpeed = 4f;
	bool facingLeft = true;
	public float jumpForce = 15f;
	
	void Start () 
	{
		animator = GetComponent<Animator>();
	}

	void FixedUpdate ()
	{
		
		//get the current state
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		animator.SetBool("Grounded", Etat.grounded);
		
		animator.SetFloat ("SpeedVertical", rigidbody2D.velocity.y);
		
		float h = Input.GetAxis("Horizontal");
		if(!Etat.hurted)
		{
			Debug.Log ("not hurted");
			if(!Etat.walled && !stateInfo.IsName("Attack ground"))
			{
				float speed = h*maxSpeed;
				
				rigidbody2D.velocity = new Vector2(speed,rigidbody2D.velocity.y);
				//rigidbody2D.AddForce(new Vector2(speed, 0f));
				animator.SetFloat("Speed", Mathf.Abs(h));
			}
			else
			{			
				rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
				animator.SetFloat("Speed", 0);
			}
			if(Etat.grounded && Input.GetButton("Jump") && !stateInfo.IsName("Attack ground"))
			{
				animator.SetBool("Grounded",false);
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,jumpForce);
			}
		}
		else{
			Debug.Log ("hurted");
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