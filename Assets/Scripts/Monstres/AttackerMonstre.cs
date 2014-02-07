using UnityEngine;
using System.Collections;

public class AttackerMonstre : MonoBehaviour {

	protected Animator animator;
	public Transform frontA;
	public Transform frontB;
	public Transform character;
	public LayerMask layerEnnemy;
	int i = 0;
	// Use this for initialization
	void Start () {		
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		i++;
		if(i >= 60)
		{
			i=0;
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
