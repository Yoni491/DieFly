using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonScript : MonoBehaviour
{
     public void TriggerClick()
     {
          InGamePanel.ReturnToMainMenu();
     }
}
