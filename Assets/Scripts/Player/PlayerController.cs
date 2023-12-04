using SimpleInputNamespace;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Animator animator;
    
    [SerializeField] private EnemySpawner enemySpawner;

    [SerializeField] private float speed = 1100f;

    private void Update()
    {
        if (joystick.xAxis.value !=0 || joystick.yAxis.value != 0)
        {
            Vector3 position = new(joystick.xAxis.value, 0, joystick.yAxis.value);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(position.x, 0, position.z)), 2f);

            characterController.SimpleMove(speed * Time.deltaTime * position);

            if(animator.GetBool("IsRunning") == false)
                animator.SetBool("IsRunning", true); 

            if(animator.GetBool("IsAttacking") == true)
                animator.SetBool("IsAttacking", false);
        }
        else
        {
            if (animator.GetBool("IsRunning") == true)
                animator.SetBool("IsRunning", false);

            if (enemySpawner.enemies.Count != 0)
            {
                if (animator.GetBool("IsAttacking") == false)
                    animator.SetBool("IsAttacking", true);
            }
        }
    }
}
