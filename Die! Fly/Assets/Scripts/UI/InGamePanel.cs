using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGamePanel : MonoBehaviour
{
    [SerializeField] Text m_ScoreText = null;
    [SerializeField] Text m_StreakText = null;
    [SerializeField] Text m_ComboText = null;
    [SerializeField] GameObject m_ComboPanel = null;
    static Text s_ScoreText;
    static Text s_StreakText;
    static Text s_ComboText;
    static GameObject s_ComboPanel;
    public static int m_Score;
    public static int m_Streak;
    public static int m_Combo;
    static float s_Timer;
    static float s_LastFruitSliceTime;
    static int s_ComboStreak;

     public void ReturnToMainMenu()
     {
          SceneManager.LoadScene("MainMenu");
     }

     private void Start()
     {
          s_ScoreText = m_ScoreText;
          s_StreakText = m_StreakText;
          s_ComboText = m_ComboText;
          s_ComboPanel = m_ComboPanel;
     }

     private void Update()
     {
          s_Timer += Time.deltaTime;
     }

     public static void updateScore(int scoreToAdd)
     {
          m_Score += scoreToAdd;
          s_ScoreText.text = "Score: " + m_Score.ToString();
          updateStreak(1);
     }

     public static void updateStreak(int streakToAdd)
     {
          if(streakToAdd == 0)
          {
               m_Streak = 0;
          }

          else
          {
               m_Streak += streakToAdd;
          }

          s_StreakText.text = "Streak: " + m_Streak.ToString();
     }

     public static void addCombo(int comboToAdd)
     {
          if(comboToAdd == 0)
          {
               resetCombo();
          }

          else
          {
               if(s_Timer - s_LastFruitSliceTime < 0.25f || s_LastFruitSliceTime == 0)
               {
                    s_LastFruitSliceTime = s_Timer;
                    s_ComboStreak++;
               }

               else
               {
                    if(s_ComboStreak <= 1)
                    {
                         resetCombo();
                    }

                    s_LastFruitSliceTime = s_Timer;
                    s_ComboStreak = 1;

               }

               m_Combo += comboToAdd;
               if(m_Combo > 1)
               {
                    s_ComboPanel.SetActive(true);
               }

               s_ComboText.text = m_Combo.ToString();
          }
     }

     public static void resetCombo()
     {
          updateScore(m_Combo * (m_Combo / 10 > 2 ? m_Combo / 10 : 2));
          s_LastFruitSliceTime = 0;
          s_Timer = 0;
          m_Combo = 0;
          s_ComboPanel.SetActive(false);
     }
}