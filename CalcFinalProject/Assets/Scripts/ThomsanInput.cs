using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThomsanInput : MonoBehaviour
{
    public TMP_Text title;
    public TMP_InputField beta;
    public int index;
    public float betaValue;

    public void SetUp(string title, float betaValue, int index)
    {
        this.title.text = title;
        this.betaValue = betaValue;
        this.index = index;
        beta.text = betaValue.ToString();
    }

    public void ValueChanged()
    {
        betaValue = float.Parse(beta.text);
        ThomsanParticleManager.instance.startingValues[index] = betaValue;
    }
}
