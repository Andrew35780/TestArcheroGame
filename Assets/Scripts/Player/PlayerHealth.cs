using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float totalHealth = 10f;
    [SerializeField] private Image playerHealthBar;

    private bool isGameOver;
    private int damageCount = 2;
    private float playerHealth;

    private void Start()
    {
        playerHealth = totalHealth;
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameOver)
            SceneManager.LoadScene("Level1");
    }

    private void OnTriggerEnter(Collider other) // EnemyBullet doesnt work with controller and not trigger collider. Work with controller and trigger collider
    {
        if (other.name == "DamageItem" || other.tag == "EnemyBullet")
        {
            playerHealth -= damageCount;
            playerHealthBar.fillAmount = playerHealth / totalHealth;
        }

        if (playerHealth <= 0)
            isGameOver = true;
    }
}
