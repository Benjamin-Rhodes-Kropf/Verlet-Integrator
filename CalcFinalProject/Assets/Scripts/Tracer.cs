using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{

	[Header("Settings")] 
	public float scale;
	public float speed = 0;
	public bool isPaused;

	[Header("Equations")] 
	public Equation equation;
	
	[Header("Lorenz")]
	public double sigma=10.0;
	public double rho=28.0;
	public double beta=8.0/3.0;
	
	[Header("Thomsan")] 
	//double beta=0.208186;
	public double b =0.19;
	
	int n=3;
	double [] x;
	double [] xprime;
	double [] xstore;
	double [] k1;
	double [] k2;
	double [] k3;
	double [] k4;
	public Color color = Color.blue;

	// Use this for initialization
	void Start () {
		x = new double[n];
		x [0] = transform.position.x;
		x [1] = transform.position.y;
		x [2] = transform.position.z;
		xprime = new double[n];
		xstore = new double[n];
		k1 = new double[n];
		k2 = new double[n];
		k3 = new double[n];
		k4 = new double[n];
		GetComponent<Renderer> ().material.color = color;
		GetComponent<TrailRenderer> ().material.color = color;
	}

	void RatesOfChange(double [] xin) {
		double x = xin [0];
		double y = xin [1];
		double z = xin [2];

		if (equation == Equation.Lorenz)
		{
			xprime [0] = sigma * (y - x);
			xprime [1] = x * (rho - z) - y;
			xprime [2] = x * y - beta * z;
		}
		
		if (equation == Equation.Thomsan)
		{
			xprime [0] =1*(Math.Sin(y) - b*x);
			xprime [1] =1*(Math.Sin(z) - b*y);
			xprime [2] =1*(Math.Sin(x) - b*z);
		}
	}

	void FixedUpdate() {
		if (isPaused)
		{
			return;
		}
		double h = (double) Time.fixedDeltaTime*speed;

		RatesOfChange (x); // start using current position
		for (int i = 0; i < n; i++) {
			k1 [i] = xprime [i] * h; 
			xstore [i] = x [i] + 0.5*k1 [i];
		}
		RatesOfChange (xstore); 
		for (int i = 0; i < n; i++) {
			k2 [i] = xprime [i] * h; 
			xstore [i] = x [i] + 0.5*k2 [i];
		}
		RatesOfChange (xstore);
		for (int i = 0; i < n; i++) {
			k3 [i] = xprime [i] * h; 
			xstore [i] = x [i] + k3 [i];
		}
		RatesOfChange (xstore);
		for (int i = 0; i < n; i++) {
			k4 [i] = xprime [i] * h; 
			x [i] = x [i] + (1.0 / 6.0) *
				(k1 [i] + 2.0 * k2 [i] +
				2.0 * k3 [i] + k4 [i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 ((float)x[0]*scale,(float)x[1]*scale,(float)x[2]*scale);
	}
}

public enum Equation // your custom enumeration
{
	Lorenz, 
	Thomsan,
};