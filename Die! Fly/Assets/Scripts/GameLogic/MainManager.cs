using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

    [SerializeField]
    Text m_LifeText = null;
    int m_Life = 100;
    public static int s_Life;
    public static Text s_LifeText;

    private void Start()
    {
        s_Life = m_Life;
        s_LifeText = m_LifeText;
        s_LifeText.text = "Life: " + s_Life + "%";
    }

    private void Update()
    {

    }

    public static void LoseLife(int Amount)
    {
        s_Life -= Amount;
        s_LifeText.text = "Life: " + s_Life + "%";
        if (s_Life <= 0)
        {
            LoseGame();
        }
    }

    static void LoseGame()
    {
        PanelManager.b_PlayerLost = true;
        ScoreScript.AddScore(InGamePanel.s_Score);
        SceneManager.LoadScene("MainMenu");
    }
}

