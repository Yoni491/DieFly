using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStore : MonoBehaviour
{
    public static void PurchaseWeapon(WeaponContainer i_ChoosedContainer)
    {
        if (i_ChoosedContainer.m_TheGlass.activeInHierarchy)
        {
            if (InGamePanel.m_Money >= i_ChoosedContainer.m_Price)
            {
                InGamePanel.m_Money -= i_ChoosedContainer.m_Price;
                InGamePanel.displayNewMoneyValue();
                WeaponScript.EquipWeapon(i_ChoosedContainer.m_TheWeapon);
                i_ChoosedContainer.m_TheGlass.SetActive(false);
            }
        }

        else
        {
            WeaponScript.EquipWeapon(i_ChoosedContainer.m_TheWeapon);
        }
    }
}