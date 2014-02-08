using UnityEngine;
using System.Collections;


public class CharController : MonoBehaviour {
	
	protected Animator animator;

	public float maxSpeed = 4f;
	bool facingLeft = true;
	public float jumpForce = 15f;
	float i = 0;
	
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
			i = 0;
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
			if(h < 0 && !facingLeft)
			{
				Flip ();
			}
			else if(h > 0 && facingLeft)
			{
				Flip ();
			}
		}
		else
		{
			i++;
			float xForce = 2f + Mathf.Log(1f+i)*Time.deltaTime*100;

			if(!facingLeft)
			{
				xForce *= -1;
			}
			Debug.Log(i);
			//float yForce = Mathf.Log(1f+i)*Time.deltaTime*100;
			float yForce = -Mathf.Pow(i*0.8f-3, 2) + 5;
			rigidbody2D.velocity = new Vector2(xForce,yForce);
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