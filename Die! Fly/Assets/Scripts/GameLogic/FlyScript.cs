using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
    private Vector3 m_CurrentflyingPoint = new Vector3(0,0,0);
    private int m_CurrentLife, m_MaxLife;
    private int m_FlyingMethod;
    private float m_Speed;
    private float m_RotationSpeed = 300f;
    private bool b_IsFlyingToPoint = false;
    private bool b_IsFlyingToFood = false;
    private float m_TimeFlyingToPoint = 0;
    private float m_MaxTimeFlyingToPoint = 0;
    private float m_EatFoodTimer = 0;
    private bool b_IsEatingFood = false;
    private float m_AttackTimer = 0;
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
        if (b_IsEatingFood)
        {
            m_EatFoodTimer += Time.deltaTime;
            if (m_EatFoodTimer >= 4)
            {
                b_IsEatingFood = false;
                b_IsFlyingToFood = false;
            }
            m_AttackTimer += Time.deltaTime;
            if(m_AttackTimer>=1)
            {
                m_AttackTimer = 0;
                MainManager.LoseLife(1);
            }
        }
        else
        {
            FlyingAlgorithm();
            if (b_IsFlyingToPoint)
            {
                Quaternion rotTarget = Quaternion.LookRotation(m_CurrentflyingPoint - this.transform.position);
                this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, m_RotationSpeed * Time.deltaTime);
            }
            m_TimeFlyingToPoint += Time.deltaTime;
        }
    }

    void FlyingAlgorithm()
    {
        float step = m_Speed * Time.deltaTime;
        if ((FlyManager.s_PlayerInteractionPoints[1].position.y - 0.3 > transform.position.y) && !b_IsFlyingToPoint) //make it enum !@!@#!@#!@#!@#
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, m_Speed, 0);
        }
        else if (!b_IsFlyingToPoint)
        {
            FlyToNewPoint();
        }
        else if(b_IsFlyingToFood)
        {
            if(Vector3.Distance(transform.position, m_CurrentflyingPoint) < 0.1f)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                m_EatFoodTimer = 0;
                b_IsEatingFood = true;
            }
        }
        else if(b_IsFlyingToPoint)
        {
            if (Vector3.Distance(transform.position, m_CurrentflyingPoint) < 0.1f || (m_TimeFlyingToPoint > m_MaxTimeFlyingToPoint))
            {

                FlyToNewPoint();
                m_MaxTimeFlyingToPoint = Random.Range(0, 1f);
                m_TimeFlyingToPoint = 0;

            }
        }
    }

    void FlyToNewPoint()
    {
        if (Random.Range(0, 10) < 1)//flying to food
        {
            m_CurrentflyingPoint = FlyManager.s_FoodPoints[Random.Range(0, 2)].position;
            b_IsFlyingToFood = true;
        }
        else//flying around
        {
            float tempX = Random.Range(FlyManager.s_PlayerInteractionPoints[0].position.x, FlyManager.s_PlayerInteractionPoints[1].position.x);
            float tempY = Random.Range(FlyManager.s_PlayerInteractionPoints[0].position.y, FlyManager.s_PlayerInteractionPoints[1].position.y);
            float tempZ = Random.Range(FlyManager.s_PlayerInteractionPoints[0].position.z, FlyManager.s_PlayerInteractionPoints[1].position.z);
            m_CurrentflyingPoint = new Vector3(tempX, tempY, tempZ);
        }
        GetComponent<Rigidbody>().velocity = Vector3.Normalize(m_CurrentflyingPoint - transform.position) * m_Speed;
        b_IsFlyingToPoint = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Weapon")
        {
            if (--m_CurrentLife <= 0)
            {
                InGamePanel.updateScore(m_MaxLife);
                InGamePanel.addMoney(m_MaxLife);
                Destroy(gameObject);
            }
        }
    }
    
}
