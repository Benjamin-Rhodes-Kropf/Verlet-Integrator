using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LorenzInput : MonoBehaviour
{
    public TMP_Text title;
    public TMP_InputField beta;
    public TMP_InputField rho;
    public TMP_InputField sigma;
    public int index;
    public Vector3 values;

    public void SetUp(string title, Vector3 values, int index)
    {
        this.title.text = title;
        this.values = values;
        this.index = index;

        beta.text = values.x.ToString();
        rho.text = values.y.ToString();
        sigma.text = values.z.ToString();
    }

    public void ValueChanged()
    {
        float.TryParse(beta.text, out float x);
        float.TryParse(rho.text, out float y);
        float.TryParse(sigma.text, out float z);
        
        values.x = x;
        values.y = y;
        values.z = z;
        LorenzParticleManager.instance.startingValues[index] = values;
    }
}
