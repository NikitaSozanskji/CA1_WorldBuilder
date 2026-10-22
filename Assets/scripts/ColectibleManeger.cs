
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ColectibleManager : MonoBehaviour
{
    public static ColectibleManager instance;

    public int coins = 0;
    public TMP_Text coinText;

    private void Awake()
    {
        instance = this;
        UpdateUI();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Collected: " + coins + " / 5";
            if (coins >= 5)
            {
                SceneManager.LoadScene("level2");
            }
        }
    }
}
