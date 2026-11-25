
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text coinText;

    private int totalCoins = 0;
    private int collectedCoins = 0;

    public TMP_Text timeText;
    public float starTime = 10;
    private float timeLeft;

    private void Start()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        totalCoins = coins.Length;
        UpdateCoinText();

        timeLeft = starTime;
    }

    private void Update()
    {
        if (timeLeft <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Max(timeLeft, 0f);

        timeText.text = "Time: " + timeLeft.ToString("F2");
    }

    public void CollectCoin()
    {
        collectedCoins++;

        if (collectedCoins == totalCoins)
        {
            loadNextLevel();
        }

        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + collectedCoins + "/" + totalCoins;
    }

    void loadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
}

