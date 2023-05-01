using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TMP_Text m_scoreText;
    [SerializeField] float m_scoreMultiplier;

    private float m_score;
    private bool m_isGameActive = true;

    void Update()
    {
        if (m_isGameActive)
        {
            m_score += Time.deltaTime * m_scoreMultiplier;
            m_scoreText.text = Mathf.FloorToInt(m_score).ToString();
        }
    }

    public void OnEndGame()
    {
        m_isGameActive = false;
        m_scoreText.text = "";
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(m_score);
    }
}
