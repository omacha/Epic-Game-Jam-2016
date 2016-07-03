using UnityEngine;
using System.Collections;

public class AttackThrow : StateMachineBehaviour {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool ("AttackThrow", false);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		RangedWeapon ranged = GameObject.FindObjectOfType<RangedWeapon> ();
		GameObject obj = (GameObject)Instantiate (ranged.prefab, ranged.firePoint.transform.position, ranged.firePoint.transform.rotation);
		obj.GetComponent<ProjectileController> ().SetDamage (ranged.damage);

		if (ranged.hitSounds.Length > 0) {
			int index = (int)Mathf.Floor (Random.value * ranged.hitSounds.Length);
			AudioClip hitSound = ranged.hitSounds [index];
			obj.GetComponent<ProjectileController> ().SetHitSound (hitSound);
		}

		Vector3 curScale = obj.transform.localScale;
		Vector3 playerScale = GameObject.FindGameObjectWithTag("Player").transform.localScale;
		curScale.x = Mathf.Sign (playerScale.x) * Mathf.Abs (curScale.x);
		obj.transform.localScale = curScale;
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
