using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
     [SerializeField] Text m_Scores = null;
     [SerializeField] Text m_Dates = null;
     static Text s_Score;
     static Text s_Date;
     static int m_MaxScores = 10;
     static int m_ScoresAmount = 0;
     static PlayerScore[] m_CurrentScores = new PlayerScore[m_MaxScores];

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
               if(i >= m_ScoresAmount)
               {
                    m_CurrentScores[i] = newScore;
                    m_ScoresAmount++;
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

          for(int i = 0; i < m_ScoresAmount; i++)
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
          m_ScoreDate =  System.DateTime.Now.ToString();
     }

    public string ScoreDate { get => m_ScoreDate; set => m_ScoreDate = value; }
}