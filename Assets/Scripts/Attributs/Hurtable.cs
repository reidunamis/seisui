using UnityEngine;
using System.Collections;

public class Hurtable : MonoBehaviour {
	
	protected Animator animator;

	void Start() 
	{		
		animator = GetComponent<Animator>();
	}
		
	void Hurt(Transform positionAttaquant)
	{
		animator.SetTrigger("Hurt");
		float testPosition = positionAttaquant.position.x - rigidbody2D.transform.position.x;
		float force = 10f;
		if(testPosition > 0)
		{
			force *= -1f;
		}

		rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x+force, rigidbody2D.velocity.y+3f);
		//rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x+force, rigidbody2D.velocity.y+1f));
	}
}
