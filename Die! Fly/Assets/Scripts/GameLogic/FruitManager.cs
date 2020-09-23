//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FruitManager : MonoBehaviour
//{
//   //  [SerializeField] Transform []m_Fruits = null;
//     [SerializeField] Transform m_Bomb = null;
//     float m_Timer = 0;
//     float m_TimeToEject;
//     int m_RandomFruitIndex;
//     int m_NumOfFruitToLaunch;

//     void Start()
//     {
//          m_TimeToEject = UnityEngine.Random.Range(2, 3);
//     }

//     void Update()
//     {
//          m_Timer += Time.deltaTime;
//          if(m_Timer >= m_TimeToEject)
//          {
//               m_Timer = 0;
//               m_TimeToEject = UnityEngine.Random.Range(2, 3);
//               LaunchFruits();
//          }
//     }

//     private void LaunchFruits()
//    {
//        Transform fruit;
//        Transform ejectedBomb;

//        m_NumOfFruitToLaunch = UnityEngine.Random.Range(2, 4);

//        //for (int i = 0; i < m_NumOfFruitToLaunch; i++)
//        //{
//        //    m_RandomFruitIndex = UnityEngine.Random.Range(0, m_Fruits.Length - 1);
//        //    fruit = Instantiate(m_Fruits[m_RandomFruitIndex]);
//        //    fruit.position = transform.position + new Vector3(0, 0, UnityEngine.Random.Range(-1.2f, 1.2f));
//        //    fruit.GetComponent<Rigidbody>().AddForce(new Vector3(0, UnityEngine.Random.Range(350, 400), 0));
//        //}

//        if (UnityEngine.Random.Range(1f, 4f) < 1.5f)
//        {
//            ejectedBomb = Instantiate(m_Bomb);
//            ejectedBomb.position = transform.position + new Vector3(0, 0, UnityEngine.Random.Range(-1.2f, 1.2f));
//            ejectedBomb.GetComponent<Rigidbody>().AddForce(new Vector3(0, UnityEngine.Random.Range(350, 400), 0));
//        }
//    }
//}
