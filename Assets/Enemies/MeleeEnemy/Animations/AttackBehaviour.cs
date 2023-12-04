using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    private Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);

        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance > 1.75f) //1.75f
            animator.SetBool("IsAttacking", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
