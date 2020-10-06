using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_SpawnPoints = null;
    [SerializeField]
    private Transform[] m_PlayerInteractionPoints = null;// right - 0, left - 1
    [SerializeField]
    private Transform[] m_FoodPoints = null;
    [SerializeField]
    private GameObject[] m_FlyPrefabs = null;
    // This points mark the square around the player which the butterflys start flying around the player.

    public static Transform[] s_PlayerInteractionPoints;
    public static Transform[] s_FoodPoints;
    private float m_Timer;
    private float m_TimeToCreateFly;

    void Start()
    {
       s_PlayerInteractionPoints = m_PlayerInteractionPoints;
       s_FoodPoints = m_FoodPoints;
       m_TimeToCreateFly = Random.Range(0, 1);
    }

    void Update()
    {
         m_Timer += Time.deltaTime;
         if (m_Timer >= m_TimeToCreateFly)
         {
              m_Timer = 0;
              m_TimeToCreateFly = Random.Range(1112f, 1111);
              addNewFlyToGame();
         }
    }

    private void addNewFlyToGame()
    {

        int butterflyNum = Random.Range(0, 3);
        int life=0;
        float speed = 1.3f;
        if (butterflyNum == 0)
        {
            life = 1;
        }
        else if (butterflyNum == 1)
        {
            life = 3;
        }
        else if (butterflyNum == 2)
        {
            life = 10;
        }
        GameObject g_butterfly = Instantiate(m_FlyPrefabs[butterflyNum], m_SpawnPoints[0].position, Quaternion.identity, this.transform);
        g_butterfly.GetComponent<FlyScript>().CreateFly(life, speed, 1);
    }
}

