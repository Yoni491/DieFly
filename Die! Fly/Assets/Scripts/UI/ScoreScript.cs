using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
     [SerializeField]
     private Text m_Scores = null;
     [SerializeField]
     private Text m_Dates = null;
     private static Text s_Score;
     private static Text s_Date;
     private static int m_MaxScores = 10;
     private static int s_ScoresAmount;
     private static PlayerScore[] m_CurrentScores = new PlayerScore[m_MaxScores];

     private void Start()
     {
          s_Score = m_Scores;
          s_Date = m_Dates;
     }

     public static void AddScore(int i_Score)
     {
          PlayerScore newScore = new PlayerScore(i_Score);

          for(int i = 0; i < m_MaxScores; i++)
          {
               if(i >= s_ScoresAmount)
               {
                    m_CurrentScores[i] = newScore;
                    s_ScoresAmount++;
                    break;
               }

               if(i_Score > m_CurrentScores[i].m_Score)
               {
                    PlayerScore temp = m_CurrentScores[i];
                    m_CurrentScores[i] = newScore;
                    newScore = temp;
               }
          }
     }

     public static void UpdateLeaderboard()
     {
          string leaderboardScore = "";
          string leaderboardDate = "";

          for(int i = 0; i < s_ScoresAmount; i++)
          {
               leaderboardScore += (i + 1) + ". " + m_CurrentScores[i].m_Score + "\n";
               leaderboardDate += m_CurrentScores[i].ScoreDate + "\n";
          }

          s_Score.text = leaderboardScore;
          s_Date.text = leaderboardDate;
     }
}

public class PlayerScore
{
     public int m_Score;
     private string m_ScoreDate;

     public PlayerScore(int Score)
     {
          m_Score = Score;
          m_ScoreDate = DateTime.Now.ToString();
     }

     public string ScoreDate
     {
          get => m_ScoreDate;
          set => m_ScoreDate = value;
     }
}