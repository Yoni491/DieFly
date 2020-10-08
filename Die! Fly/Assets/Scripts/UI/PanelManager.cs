using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
     [SerializeField]
     private GameObject m_HowToPopUp = null;
     [SerializeField]
     private GameObject m_ScoreboardPopUp = null;
     [SerializeField]
     private GameObject m_LostPopUp = null;
     [SerializeField]
     private Text m_LostPopUpText = null;
     public static bool b_PlayerLost;

     public void StartGame()
     {
          SceneManager.LoadScene("Game");
     }

     public void ShowScores()
     {
          ScoreScript.UpdateLeaderboard();
          m_ScoreboardPopUp.SetActive(true);
     }

     public void HowToPlay()
     {
          m_HowToPopUp.SetActive(true);
     }

     public void CloseHowToPlay()
     {
          m_HowToPopUp.SetActive(false);
     }

     public void CloseScoreboard()
     {
          m_ScoreboardPopUp.SetActive(false);
          SceneManager.LoadScene("MainMenu");
     }

     public void QuitGame()
     {
          Application.Quit();
     }

     private void OnEnable()
     {
          if(b_PlayerLost)
          {
               m_LostPopUpText.text = "Your score is: " + InGamePanel.m_Score.ToString();
               m_LostPopUp.SetActive(true);
               b_PlayerLost = false;
               InGamePanel.m_Score = 0;
          }
     }
}
