using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject levelCompletePanel = null;
    private int score = 0;

    public static event Action<int> OnScoreChange;

    private void Awake()
    {
        Coin.OnCoinPickup += OnCoinPickup;
        Player.onReachFinish += OnLevelFinished;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCoinPickup()
    {
        score++;
        OnScoreChange?.Invoke(score);
    }

    private void OnLevelFinished()
    {
        if (levelCompletePanel == null)
            return;
        
        levelCompletePanel.SetActive(true);
    }

    private void OnDestroy() 
    {
        Coin.OnCoinPickup -= OnCoinPickup;
        Player.onReachFinish -= OnLevelFinished;
    }
}
