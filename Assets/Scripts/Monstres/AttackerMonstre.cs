using UnityEngine;
using System.Collections;

public class AttackerMonstre : MonoBehaviour {

	protected Animator animator;
	public Transform frontA;
	public Transform frontB;
	public Transform character;
	public LayerMask layerEnnemy;
	public GameObject coup;
	int i = 0;
	// Use this for initialization
	void Start () {		
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		i++;
		if(i >= 60 && !Etat.hurted)
		{
			i=0;
			animator.SetTrigger("Attack");
			Instantiate(coup, frontA.position, frontA.rotation);
		}
	}
}
