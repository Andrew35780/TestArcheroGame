using UnityEngine;

public class AttackDistantBehaviour : StateMachineBehaviour
{
    private Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(new Vector3(player.position.x, animator.transform.position.y, player.position.z));

        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance > 10f) //1.75f
            animator.SetBool("IsAttacking", false);
    }
}
