using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	
	protected Animator animator;
	public LayerMask layerEnnemy;	
	public Transform positionCoup;
	public GameObject coup;
	// Use this for initialization
	void Start () {		
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if(!stateInfo.IsName("Attack ground"))
		{
			if(Etat.grounded && Input.GetButtonDown("Attack"))
			{
				animator.SetTrigger("Attack");
				Instantiate(coup, positionCoup.position, positionCoup.rotation);
			}
		}
	}
}
