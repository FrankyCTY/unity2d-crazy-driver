using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{   
    [SerializeField] GameObject thingToFollow;


    // Late update so that the thingToFollow is update first and then we follow it
     private void LateUpdate() 
    {
        // Adding -10f z on top of thingToFollow so that the camera is float in the air and can capture the scene
        // Object's position should be follow the crazy driver's position
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10f);
    }
}
