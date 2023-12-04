using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    private Transform player;

    private float timer;
    private float chaseRange = 10;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 3)
            animator.SetBool("IsPatrolling", true); //TODO ?

        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance < chaseRange)
            animator.SetBool("IsRunning", true);
    }
}
