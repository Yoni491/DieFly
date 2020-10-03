using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum eSpawnPoints
{
    START,
    COOKIE
};

public class ButterflyManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_SpawnPoints = null;
    [SerializeField]
    private Transform[] m_PlayerInteractionPoints = null;// right - 0, left - 1
    [SerializeField]
    private Transform[] m_FoodPoints = null;
    [SerializeField]
    private GameObject[] m_ButterflyPrefabs = null;
    // This points mark the square around the player which the butterflys start flying around the player.

    public static Transform[] s_PlayerInteractionPoints;
    public static Transform[] s_FoodPoints;
    private float m_Timer;
    private float m_TimeToCreateButterfly;

    void Start()
    {
       s_PlayerInteractionPoints = m_PlayerInteractionPoints;
       s_FoodPoints = m_FoodPoints;
       m_TimeToCreateButterfly = Random.Range(0, 1);
    }

    void Update()
    {
         m_Timer += Time.deltaTime;
         if (m_Timer >= m_TimeToCreateButterfly)
         {
              m_Timer = 0;
              m_TimeToCreateButterfly = Random.Range(4, 5);
              addNewButterflyToGame();
         }
    }

    private void addNewButterflyToGame()
    {

        int butterflyNum = Random.Range(0, 2);
        //Butterfly newButterfly;
        GameObject butterflyPrefab=null;
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
        butterflyPrefab = m_ButterflyPrefabs[butterflyNum];
        GameObject g_butterfly = Instantiate(butterflyPrefab, m_SpawnPoints[0].position, Quaternion.identity, this.transform);
        g_butterfly.GetComponent<ButterflyScript>().CreateButterfly(life, speed, 1);
    }
}

