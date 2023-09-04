using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VariableManager : MonoBehaviour
{
    public RectTransform background;
    
    public ThomsanParticleManager thomsanParticleManager;
    public Slider thomsanNumberSlider;
    public int numberOfThomsan;
    public GameObject ThomsanPrefab;
    public List<GameObject> thomsanInputs;

    public LorenzParticleManager lorenzParticleManager;
    public Slider LorenzNumberSlider;
    public int numberOfLorenz;
    public GameObject LorenzPrefab;
    public List<GameObject> lorenzInputs;
    
    
    public void UpdateAllInputs()
    {
        numberOfThomsan = (int)thomsanNumberSlider.value;
        numberOfLorenz = (int)LorenzNumberSlider.value;
        
        //delete children and clear
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            GameObject child = transform.GetChild(i).gameObject;
            Destroy(child);
        }
        thomsanInputs.Clear();
        lorenzInputs.Clear();
        
        
        for (int i = 0; i < numberOfThomsan; i ++)
        {
            var thomsanInput = Instantiate(ThomsanPrefab);
            thomsanInput.transform.SetParent(this.transform);
            thomsanInputs.Add(thomsanInput);

            if (thomsanParticleManager.startingValues[i] != null)
            {
                thomsanInput.GetComponent<ThomsanInput>().SetUp("Thomsan Particle:" + (i+1), thomsanParticleManager.startingValues[i], i);
            }
        }
        for (int i = 0; i < numberOfLorenz; i ++)
        {
            var lorenzInput = Instantiate(LorenzPrefab);
            lorenzInput.transform.SetParent(this.transform);
            lorenzInputs.Add(lorenzInput);
            if (lorenzParticleManager.startingValues[i] != null)
            {
                lorenzInput.GetComponent<LorenzInput>().SetUp("Lorenz Particle:" + (i+1), lorenzParticleManager.startingValues[i], i);
            }
        }

        background.sizeDelta = new Vector2(background.sizeDelta.x, 50 * (numberOfLorenz + numberOfThomsan) + 100);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        UpdateAllInputs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
