using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerScript : MonoBehaviour
{
    [SerializeField]
    GameObject m_Pointer=null;
    [SerializeField]
    Material m_startingMaterial = null;
    [SerializeField]
    Material m_HitMaterial = null;
    static GameObject s_Pointer;
    static Material s_HitMaterial;
    static float s_TimeToBlink = 0;
    static bool b_IsBlinking = false;
    // Start is called before the first frame update
    void Start()
    {
        s_Pointer = m_Pointer;
        s_HitMaterial = m_HitMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            RaycastHit hit;
            int layerMask = 7;
            if (Physics.Raycast(transform.position, transform.forward, out hit,100.1f, layerMask))
            {
                if(hit.collider!=null)
                {
                    if (hit.collider.GetComponent<MainMenuButtonScript>() != null)
                    {
                        hit.collider.GetComponent<MainMenuButtonScript>().triggerClick();
                    }
                    else if(hit.collider.GetComponent<WeaponContainerScript>() != null)
                    {
                        hit.collider.GetComponent<WeaponContainerScript>().triggerClick();
                    }
                }
            }
        }
        if (b_IsBlinking)
        {
            s_TimeToBlink += Time.deltaTime;
            if (s_TimeToBlink >= 0.3f)
            {
                b_IsBlinking = false;
                s_Pointer.GetComponent<MeshRenderer>().material = m_startingMaterial;
                s_TimeToBlink = 0;
            }
        }
    }
    public static void MakePointerBlink()
    {
        s_Pointer.GetComponent<MeshRenderer>().material = s_HitMaterial;
        b_IsBlinking = true;
    }

}
