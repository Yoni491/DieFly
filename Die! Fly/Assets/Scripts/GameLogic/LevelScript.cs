using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelScript : MonoBehaviour
{
    [SerializeField]
    Text Timer = null;
    [SerializeField]
    Text Level = null;
    float m_timer = 0;
    float m_LevelTime = 60;
    // Start is called before the fir
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        Timer.text = "time left: " + (m_LevelTime - (int)m_timer) + " sec";
        if (m_timer >= m_LevelTime)
        {
            m_timer = 0;
            Level.text = "LEVEL " + ++FlyManager.s_Level;
        }
    }
}
