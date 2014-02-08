using UnityEngine;
using System.Collections;

public class Hurtable : MonoBehaviour {
	
	protected Animator animator;

	void Start() 
	{		
		animator = GetComponent<Animator>();
	}
		
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Hurt"))
		{
			animator.SetTrigger("Hurt");
			float testPosition = other.gameObject.transform.position.x - rigidbody2D.transform.position.x;
			float force = 2f;
			if(testPosition > 0)
			{
				force *= -1f;
			}
			Debug.Log ("on lance le hurt");
			Etat.hurted = true;
			//rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x+force, rigidbody2D.velocity.y+1f);
			//rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x+force, rigidbody2D.velocity.y+1f));
		}

	}
}
