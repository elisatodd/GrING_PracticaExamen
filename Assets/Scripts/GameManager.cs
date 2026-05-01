using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int coinCount = 0;

    public System.Action<int> OnCoinChanged;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin(int amount = 1)
    {
        coinCount += amount;
        OnCoinChanged?.Invoke(coinCount);
        Debug.Log("Coins: " + coinCount);
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
