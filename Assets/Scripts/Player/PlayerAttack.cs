using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject arrowPoint;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator playerAnimator;

    private List<GameObject> arrows = new();

    private GameObject target;

    public void AnimationEvent_ArrowAttack() => AnimationEvent_FireArrow();

    public void AnimationEvent_Target() => AnimationEvent_AutoTargetEnemy();

    public void AnimationEvent_FireArrow()
    {
        if (target == null)
            return;

        GameObject arrowObject = null;

        if (arrows.Count != 0)
        {
            for (int i = 0; i < arrows.Count; i++)
            {
                if (arrows[i].activeInHierarchy == false)
                    arrowObject = arrows[i];
            }
        }

        if (arrowObject == null)
        {
            arrowObject = Instantiate(arrowPrefab, arrowPoint.transform.position, arrowPoint.transform.rotation);
            arrows.Add(arrowObject);
        }
        else
        {
            arrowObject.transform.position = arrowPoint.transform.position;
            arrowObject.transform.rotation = arrowPoint.transform.rotation;
            arrowObject.SetActive(true);
        }
    }

    public void AssignTarget()
    {
        if (enemySpawner.enemies.Count != 0)
        {
            float distance = float.MaxValue;

            for (int i = 0; i < enemySpawner.enemies.Count; i++)
            {
                if (enemySpawner.enemies[i] == null)
                {
                    enemySpawner.enemies.RemoveAt(i);

                    if (enemySpawner.enemies.Count == 0)
                    {
                        playerAnimator.SetBool("IsRunning", false);
                        playerAnimator.SetBool("IsAttacking", false);
                        return;
                    }

                    if (i == enemySpawner.enemies.Count)
                        break;
                }

                if (enemySpawner.enemies[i] != null)
                {
                    if (Vector3.Distance(transform.position, enemySpawner.enemies[i].transform.position) < distance)
                    {
                        distance = Vector3.Distance(playerController.transform.position, enemySpawner.enemies[i].transform.position);
                        target = enemySpawner.enemies[i].gameObject;
                    }
                }
            }

            if (target != null)
                playerController.transform.LookAt(new Vector3(target.transform.position.x, playerController.transform.position.y, target.transform.position.z));
        }
        else
        {
            playerAnimator.SetBool("IsRunning", false);
            playerAnimator.SetBool("IsAttacking", false);
        }
    }

    public void AnimationEvent_AutoTargetEnemy()
    {
        if (target != null)
            playerController.transform.LookAt(new Vector3(target.transform.position.x, playerController.transform.position.y, target.transform.position.z));
        else
            AssignTarget();
    }
}
