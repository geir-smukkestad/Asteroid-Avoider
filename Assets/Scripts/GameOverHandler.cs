using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text m_gameOverText;
    [SerializeField] private ScoreSystem m_scoreSystem;
    [SerializeField] private GameObject m_gameOverDisplay;
    [SerializeField] private AsteroidSpawner m_asteroidSpawner;

    public void EndGame()
    {
        m_scoreSystem.OnEndGame();
        m_asteroidSpawner.enabled = false;
        m_gameOverText.text = $"GAME OVER\nScore: {m_scoreSystem.GetScore()}";
        m_gameOverDisplay.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
