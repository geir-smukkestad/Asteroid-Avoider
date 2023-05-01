using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private GameOverHandler m_gameOverHandler;

    private void Awake()
    {
        m_gameOverHandler = FindObjectOfType<GameOverHandler>();
    }

    public void Crash()
    {
        m_gameOverHandler.EndGame();
        gameObject.SetActive(false);
    }
}
