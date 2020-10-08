﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
     [SerializeField]
     private Text m_TimerText = null;
     [SerializeField]
     private Text m_Level = null;
     private float m_Timer = 0;
     private float m_LevelTime = 60;

     // Start is called before the fir
     private void Start()
     {

     }

     // Update is called once per frame
     private void Update()
     {
          m_Timer += Time.deltaTime;
          m_TimerText.text = "time left: " + (m_LevelTime - (int)m_Timer) + " sec";
          if(m_Timer >= m_LevelTime)
          {
               m_Timer = 0;
               m_Level.text = "LEVEL " + ++FlyManager.s_Level;
          }
     }
}
