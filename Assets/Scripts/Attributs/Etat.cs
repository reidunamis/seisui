using UnityEngine;
using System.Collections;

public class Etat : MonoBehaviour {
	
	public Transform groundCheck;
	public Transform wallCheckA;
	public Transform wallCheckB;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	Animator animator;

	public static bool grounded = false;
	public static bool walled = false;
	public static bool hurted = false;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {		
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		walled = Physics2D.OverlapArea(wallCheckA.position, wallCheckB.position, whatIsGround);
		//hurted = stateInfo.IsName("Hurt");	
		hurted = animator.GetNextAnimatorStateInfo(0).IsName("Hurt") || stateInfo.IsName("Hurt");
	}
}
