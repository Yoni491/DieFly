using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
     [SerializeField] GameObject m_HowToPopUp = null;
     [SerializeField] GameObject m_ScoreboardPopUp = null;
     [SerializeField] GameObject m_LostPopUp = null;
     [SerializeField] Text m_LostPopUpText = null;
     public static bool b_PlayerLost;

     public void startGame()
     {
          SceneManager.LoadScene("Game");
     }

     public void showScores()
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
               m_LostPopUpText.text = "Your score is: " + InGamePanel.s_Score.ToString();
               m_LostPopUp.SetActive(true);
               b_PlayerLost = false;
               InGamePanel.s_Score = 0;
          }
     }
}
