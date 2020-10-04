using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
    private Vector3 m_CurrentflyingPoint = new Vector3(0,0,0);
    private int m_CurrentLife, m_MaxLife;
    private int m_FlyingMethod;
    private float m_Speed;
    private float RotationSpeed = 300f;
    private bool isFlyingToPoint = false;
    private bool isFlyingToFood = false;
    //private AudioClip m_Sound;
    // material

    public void CreateFly(int i_MaxLife, float i_Speed, int i_FlyingMethod)
    {
        m_CurrentLife = i_MaxLife;
        m_MaxLife = i_MaxLife;
        m_Speed = i_Speed;
        m_FlyingMethod = i_FlyingMethod;
    }

    void Update()
    {
        FlyingAlgorithm();
        if (isFlyingToPoint)
        {
            Quaternion rotTarget = Quaternion.LookRotation(m_CurrentflyingPoint - this.transform.position);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, RotationSpeed * Time.deltaTime);
        }
    }

    void FlyingAlgorithm()
    {
        float step = m_Speed * Time.deltaTime;
        if ((FlyManager.s_PlayerInteractionPoints[1].position.y - 0.3 > transform.position.y) && !isFlyingToPoint) //make it enum !@!@#!@#!@#!@#
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, m_Speed, 0);
        }
        else if (!isFlyingToPoint)
        {
            FlyToNewPoint();
        }
        if(isFlyingToPoint)
        {
            if (Vector3.Distance(transform.position, m_CurrentflyingPoint) < 0.1f)
            {
                if (isFlyingToFood)
                {
                    EatFood();
                }
                else
                {
                    FlyToNewPoint();
                }
            }
        }
    }

    void FlyToNewPoint()
    {
        if (Random.Range(0, 8) < 1)//flying to food
        {
            m_CurrentflyingPoint = FlyManager.s_FoodPoints[0].position;
            isFlyingToFood = true;
        }
        else//flying around
        {
            float tempX = Random.Range(FlyManager.s_PlayerInteractionPoints[0].position.x, FlyManager.s_PlayerInteractionPoints[1].position.x);
            float tempY = Random.Range(FlyManager.s_PlayerInteractionPoints[0].position.y, FlyManager.s_PlayerInteractionPoints[1].position.y);
            float tempZ = Random.Range(FlyManager.s_PlayerInteractionPoints[0].position.z, FlyManager.s_PlayerInteractionPoints[1].position.z);
            m_CurrentflyingPoint = new Vector3(tempX, tempY, tempZ);
        }
        GetComponent<Rigidbody>().velocity = Vector3.Normalize(m_CurrentflyingPoint - transform.position) * m_Speed;
        isFlyingToPoint = true;
    }
    void EatFood()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Weapon")
        {
            //TODO: ADD SCORE(WITH FUNCTION)
            Destroy(gameObject);
        }
    }
}
