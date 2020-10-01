using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyManager : MonoBehaviour
{
     [SerializeField]
     private Transform[] m_SpawnPoints = null;
     [SerializeField]
     private Transform[] m_PlayerInteractionPoints = null; 
     // This points mark the square around the player which the butterflys start flying around the player.

     private float m_Timer;
     private float m_TimeToCreateButterfly;
     void Start()
     {
          m_TimeToCreateButterfly = Random.Range(2, 3);
     }

     void Update()
     {
          m_Timer += Time.deltaTime;
          if (m_Timer >= m_TimeToCreateButterfly)
          {
               m_Timer = 0;
               m_TimeToCreateButterfly = Random.Range(2, 3);
               addNewButterflyToGame();
          }
     }

     private void addNewButterflyToGame()
     {

     }
}

public class Butterfly
{
     private int m_CurrentLife, m_MaxLife;
     private float m_Speed;
     private int m_FlyingMethod;
     //private AudioClip m_Sound;
     // material, prefabs

     public Butterfly(int i_CurrentLife, int i_MaxLife, float i_Speed, int i_FlyingMethod)
     {
          m_CurrentLife = i_CurrentLife;
          m_MaxLife = i_MaxLife;
          m_Speed = i_Speed;
          m_FlyingMethod = i_FlyingMethod;
     }
}