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

    private void Start()
    {
        s_Life = m_Life;
    }

    private void Update()
    {

    }

    public static void LoseLife(int Amount)
    {
        s_Life -= Amount;
        if (s_Life <= 0)
        {
            LoseGame();
        }

        else
        {
            //s_hearts[s_Life].GetComponent<MeshRenderer>().enabled = false;
        }

    }

    static void LoseGame()
    {
        PanelManager.b_PlayerLost = true;
        ScoreScript.AddScore(InGamePanel.m_Score);
        SceneManager.LoadScene("MainMenu");
    }
}

