using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LorenzParticleManager : MonoBehaviour
{
    public static LorenzParticleManager instance;
    // Start is called before the first frame update
    public GameObject particlePrefab;

    public Slider numParticlesSlider;
    public int numberOfParticles;
    public Vector3[] startingValues;
    public List<GameObject> particles;
    public bool isVisable;
    
    public Slider speedSlider;
    public float speed;

    private void Awake()
    {
        if (instance != null)
        {Destroy(gameObject);}
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void Restart()
    {
        //delete particles
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            GameObject child = transform.GetChild(i).gameObject;
            Destroy(child);
        }
        
        //clear list
        particles.Clear();

        //spawn particles
        for (int i = 0; i < numberOfParticles; i++)
        {
            var particle = Instantiate(particlePrefab, this.gameObject.transform);
            particle.GetComponent<Tracer>().beta = startingValues[i].x;
            particle.GetComponent<Tracer>().rho = startingValues[i].y;
            particle.GetComponent<Tracer>().beta = startingValues[i].z;
            particles.Add(particle);
        }
        
        //set particle manager variables to particles
        foreach (var particle in particles)
        {
            particle.GetComponent<TrailRenderer>().enabled = isVisable;
            particle.GetComponent<Renderer>().enabled = isVisable;
            particle.GetComponent<Tracer>().isPaused = !isVisable;
        }
    }

    public void SpeedChange()
    {
        speed = speedSlider.value;
        foreach (var particle in particles)
        {
            particle.GetComponent<Tracer>().speed = speed;
        }
    }

    public void ParticleCountChange()
    {
        numberOfParticles = (int)numParticlesSlider.value;
    }
    public void ToggleParticles()
    {
        isVisable = isVisable ? false : true;
        foreach (var particle in particles)
        {
            particle.GetComponent<TrailRenderer>().enabled = isVisable;
            particle.GetComponent<Renderer>().enabled = isVisable;
            particle.GetComponent<Tracer>().isPaused = !isVisable;
        }
    }
}
