using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStore : MonoBehaviour
{
    public static void PurchaseWeapon(GameObject i_Container , GameObject i_TheWeapon, int i_Price,int i_Dmg)
    {
        if (i_Container.activeInHierarchy)
        {
            if (InGamePanel.m_Money >= i_Price)
            {
                InGamePanel.m_Money -= i_Price;
                InGamePanel.displayNewMoneyValue();
                i_Container.SetActive(false);
                WeaponScript.EquipWeapon(i_TheWeapon);
                WeaponScript.s_CurrentWeaponDmg = i_Dmg;
            }
        }
        else
        {
            WeaponScript.EquipWeapon(i_TheWeapon);
            WeaponScript.s_CurrentWeaponDmg = i_Dmg;
        }
    }
}