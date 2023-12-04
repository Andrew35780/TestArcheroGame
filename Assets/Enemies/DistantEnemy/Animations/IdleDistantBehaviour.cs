using UnityEngine;

public class IdleDistantBehaviour : StateMachineBehaviour
{
    private Transform player;
    private float chaseRange = 10;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance < chaseRange)
            animator.SetBool("IsAttacking", true);
    }
}
