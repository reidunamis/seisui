using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	
	protected Animator animator;
	public LayerMask layerEnnemy;	
	public Transform frontA;
	public Transform frontB;
	Collider2D colliderAttacked;
	// Use this for initialization
	void Start () {		
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (colliderAttacked);
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if(!stateInfo.IsName("Attack ground"))
		{
			if(CharController.grounded && Input.GetButtonDown("Attack"))
			{
				animator.SetTrigger("Attack");
				Collider2D touche = null;
				touche = Physics2D.OverlapArea(frontA.position, frontB.position, layerEnnemy);
				if(touche)
				{
					touche.SendMessage("Hurt", transform);
				}
			}
		}
	}
}
