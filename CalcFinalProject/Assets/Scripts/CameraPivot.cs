using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public Transform orgin;
    public Transform targetObject;
    public float smoothness;
    public float targetsmooth;
    public float jumptosmooth;
    public float timeSpeed;
    // Start is called before the first frame update
    
    public int index;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            smoothness = jumptosmooth;
            index++;
            if (index >= LorenzParticleManager.instance.particles.Count + ThomsanParticleManager.instance.particles.Count) 
                index = 0;
            if (index < LorenzParticleManager.instance.particles.Count)
            {
                targetObject = LorenzParticleManager.instance.particles[index].transform;
            }
            else
            {
                targetObject = ThomsanParticleManager.instance.particles[index-LorenzParticleManager.instance.particles.Count].transform;
            }
        }
    }

    private void LateUpdate()
    {
        if (targetObject == null)
        {
            targetObject = orgin;
        }

        smoothness = Mathf.Lerp(smoothness, targetsmooth,Time.deltaTime*timeSpeed);
        
        var newPosition = targetObject.position;
        //We are moving slowly to the new position. The smooth factors determines how fast 
        //the camera will move to its new postion
        transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime*smoothness);
        
    }
}
