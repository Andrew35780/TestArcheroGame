using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    [SerializeField] private Text coinsCount;

    private int coins = 0;

    private void OnEnable() => EnemyHealth.OnEnemyDied += AddCoins;

    private void OnDisable() => EnemyHealth.OnEnemyDied -= AddCoins;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinsCount.text = coins.ToString();
    }

    public void AddCoins()
    {
        coins += 5;
        coinsCount.text = coins.ToString();
        PlayerPrefs.SetInt("Coins", coins);
    }
}
