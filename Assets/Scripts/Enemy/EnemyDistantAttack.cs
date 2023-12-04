using System.Collections.Generic;
using UnityEngine;

public class EnemyDistantAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPoint;
    [SerializeField] private GameObject bulletPrefab;
    
    private PlayerController playerController;

    private List<GameObject> bullets = new();

    private void Start() => playerController = FindFirstObjectByType<PlayerController>();

    public void AnimationEvent_ArrowAttack() => AnimationEvent_FireArrow();

    public void AnimationEvent_FireArrow()
    {
        if (playerController == null)
            return;

        GameObject bulletObject = null;

        if (bullets.Count != 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].activeInHierarchy == false)
                    bulletObject = bullets[i];
            }
        }

        if (bulletObject == null)
        {
            bulletObject = Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation);
            bullets.Add(bulletObject);
        }
        else
        {
            bulletObject.transform.position = bulletPoint.transform.position;
            bulletObject.transform.rotation = bulletPoint.transform.rotation;
            bulletObject.SetActive(true);
        }
    }
}
