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
			Etat.hurted = true;
		}

	}
}
