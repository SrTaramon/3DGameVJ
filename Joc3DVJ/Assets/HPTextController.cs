using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPTextController : MonoBehaviour
{
    public Slider sliderHP;

    private Text hp;

    private int hpPart;

    // Start is called before the first frame update
    void Start()
    {
        sliderHP = GameObject.Find("HP").GetComponent<Slider>();
        hp = GameObject.Find("HPText").GetComponent<Text>();
        hp.text = "100 HP";
    }

    // Update is called once per frame
    void Update()
    {
        hpPart = (int)((sliderHP.value)*100);
        hp.text = hpPart.ToString() + " HP";
    }
}
