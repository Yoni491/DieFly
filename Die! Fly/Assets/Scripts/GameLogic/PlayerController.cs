using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject m_WeaponManager = null;
     void Update()
     {
        if (Input.anyKeyDown)
        {
            m_WeaponManager.GetComponent<WeaponScript>().AttackWithWeapon();
        }
     }
}
