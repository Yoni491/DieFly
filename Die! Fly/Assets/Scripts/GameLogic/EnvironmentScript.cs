using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentScript : MonoBehaviour
{
     [SerializeField]
     private Transform m_DirectLight = null;
     private Quaternion m_DirectLightStartPos;
     private float m_RotationFactor = 0.005f;
     private float m_NightValue = 0.99f;

     [SerializeField]
     private GameObject[] m_Cars = null;
     [SerializeField]
     private Transform[] m_StartPositions;
     [SerializeField]
     private Transform[] m_EndPositions;
     private GameObject m_Car;
     private int m_PositionIndex, m_CarIndex;

     // Start is called before the first frame update
     void Start()
     {
          m_PositionIndex = Random.Range(0, 1);
          m_CarIndex = Random.Range(0, 2);
          m_Car = m_Cars[m_CarIndex];
          m_DirectLightStartPos = m_DirectLight.transform.rotation;
     }

     // Update is called once per frame
     void Update()
     {
          Vector3 carPosition = m_Car.transform.position;

          m_Car.transform.position = new Vector3(carPosition.x, carPosition.y, carPosition.z + 0.3f);
          m_DirectLight.Rotate(m_RotationFactor, 0, 0);

          if(m_DirectLight.rotation.x >= m_NightValue)
          {
               // set new level
               m_DirectLight.transform.rotation = m_DirectLightStartPos;
          }

          if(m_Car.transform.position.z >= m_EndPositions[m_PositionIndex].position.z)
          {
               m_Car.transform.position = new Vector3(carPosition.x, carPosition.y, m_StartPositions[m_PositionIndex].position.z);
               m_PositionIndex = Random.Range(0, 1);
               m_CarIndex = Random.Range(0, 3);
               m_Car = m_Cars[m_CarIndex];
               Debug.Log(m_PositionIndex);
               Debug.Log(m_CarIndex);
          }
     }
}
