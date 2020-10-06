using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponContainerScript : MonoBehaviour
{

    [SerializeField]
    public GameObject m_TheGlass = null;
    [SerializeField]
    public GameObject m_TheWeapon = null;
    [SerializeField]
    public int m_Price = 0;

    void OnCollisionEnter(Collision collision)
    {
        //WeaponStore.PurchaseWeapon(this);
    }
}
public class WeaponContainer
{
    [SerializeField]
    public GameObject m_TheGlass = null;
    [SerializeField]
    public GameObject m_TheWeapon = null;
    [SerializeField]
    public int m_Price = 0;

    void OnCollisionEnter(Collision collision)
    {
        WeaponStore.PurchaseWeapon(this);
    }
}
