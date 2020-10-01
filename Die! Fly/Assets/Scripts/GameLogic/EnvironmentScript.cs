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
     private Transform[] m_StartPositions = null;
     [SerializeField]
     private Transform[] m_EndPositions = null;
     private GameObject m_Car;
     private int m_PositionIndex, m_CarIndex;
     private float m_CarSpeed = 0.3f;

     // Start is called before the first frame update
     void Start()
     {
          m_CarIndex = Random.Range(0, 2);
          m_Car = m_Cars[m_CarIndex];

          m_DirectLightStartPos = m_DirectLight.transform.rotation;
     }

     // Update is called once per frame
     void Update()
     {
          Vector3 carPosition = m_Car.transform.position;

          m_DirectLight.Rotate(m_RotationFactor, 0, 0);
          resetLighting();

          m_Car.transform.position = new Vector3(carPosition.x, carPosition.y, carPosition.z + m_CarSpeed);
          resetCar(carPosition);
     }

     private void resetLighting()
     {
          if (m_DirectLight.rotation.x >= m_NightValue)
          {
               // set new level
               m_DirectLight.transform.rotation = m_DirectLightStartPos;
          }
     }

     private void resetCar(Vector3 i_CarPosition)
     {
          if (m_Car.transform.position.z >= m_EndPositions[m_PositionIndex].position.z)
          {
               m_PositionIndex = Random.Range(0, 2);
               m_Car.transform.position = new Vector3(m_StartPositions[m_PositionIndex].position.x, i_CarPosition.y, m_StartPositions[m_PositionIndex].position.z);
               m_CarIndex = Random.Range(0, 3);
               m_Car = m_Cars[m_CarIndex];
          }
     }

}
