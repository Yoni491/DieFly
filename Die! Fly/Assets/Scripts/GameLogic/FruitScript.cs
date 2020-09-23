using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using JetBrains.Annotations;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    //[SerializeField]
    //GameObject m_FruitHalf1 = null;
    //[SerializeField]
    //GameObject m_FruitHalf2 = null;
    //AudioSource m_AudioSource;
    //bool m_IsSlashed;

    //void Start()
    //{
    //    m_AudioSource = GetComponent<AudioSource>();
    //}

    //void Update()
    //{
    //     if(transform.position.y < -5)
    //     {
    //          if(!m_IsSlashed)
    //          {
    //               MainManager.LoseLife(1);
    //           }
    //        Destroy(gameObject);
    //     }
    //    transform.Rotate(new Vector3(1, 0.4f));
    //}

    // void sliceFruitInHalf()
    // {
    //      Vector3 fruitHalfsVec = m_FruitHalf1.transform.position - m_FruitHalf2.transform.position;
    //      m_FruitHalf1.SetActive(true);
    //      m_FruitHalf2.SetActive(true);
    //      fruitHalfsVec = Vector3.Normalize(fruitHalfsVec);
    //      fruitHalfsVec = Vector3.Scale(new Vector3(100, 100, 100), fruitHalfsVec);
    //      m_FruitHalf1.GetComponent<Rigidbody>().AddForce(fruitHalfsVec);
    //      m_FruitHalf2.GetComponent<Rigidbody>().AddForce(Vector3.Scale(new Vector3(-1, -1, -1), fruitHalfsVec));
    //      GetComponent<MeshRenderer>().enabled = false;
    //      GetComponent<MeshCollider>().enabled = false;
    // }

    // void OnCollisionEnter(Collision collision)
    // {
    //      m_IsSlashed = true;
    //      sliceFruitInHalf();
    //      InGamePanel.updateScore(1);
    //      InGamePanel.addCombo(1);
    //      m_AudioSource.time = 1;
    //      m_AudioSource.Play();
    // }

}
