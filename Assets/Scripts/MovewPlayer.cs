using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovewPlayer : MonoBehaviour
{

    private void FixedUpdate()
    {
        if (Player.posOfCol +1 < transform.position.y + PlatformManager.gasp)
        {
           
            if (gameObject.name == "Main Camera")
            {
                transform.position -= new Vector3(0, PlatformManager.gasp * Time.deltaTime * 10, -0); 
            }
            else
                transform.position -= new Vector3(0, PlatformManager.gasp * Time.deltaTime * 10,0 );
        }
    }
}
