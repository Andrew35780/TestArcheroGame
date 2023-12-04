using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static event Action OnEnemyDied;

    [SerializeField] private float totalHealth = 3f;
    [SerializeField] private Image healthBar;
    [SerializeField] private EnemyDieEffects effects;

    private float health;

    private void Start() => health = totalHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerArrow")
        {
            health -= 1;

            healthBar.fillAmount = health / totalHealth;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            effects.CreateExsplosion(gameObject);
            OnEnemyDied?.Invoke();
        }   
    }
}
