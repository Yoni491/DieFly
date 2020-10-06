using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelScript : MonoBehaviour
{
    [SerializeField]
    Text Timer = null;
    [SerializeField]
    Text Level = null;
    float timer = 0;
    // Start is called before the fir
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Timer.text = "time left: " + (60 - (int)timer) + " sec";
        if (timer >=5)
        {
            timer = 0;
            Level.text = "LEVEL " + ++FlyManager.s_Level;
        }
    }
}
