using UnityEngine;
using UnityEngine.AI;

public class RunBehaviour : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    private float attackRange = 2f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);

        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance < attackRange)
            animator.SetBool("IsAttacking", true);
            

        if (distance > 10)
            animator.SetBool("IsRunning", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 1.5f;
    }
}
