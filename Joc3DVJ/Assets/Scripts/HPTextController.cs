using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPTextController : MonoBehaviour
{
    public Slider sliderHP;

    private Text hp;

    private int hpPart;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Level2"){
            sliderHP = GameObject.Find("HP").GetComponent<Slider>();
            hp = GameObject.Find("HPText").GetComponent<Text>();
        }
        else {
            sliderHP = GameObject.Find("HP2").GetComponent<Slider>();
            hp = GameObject.Find("HPText2").GetComponent<Text>();
        }
        
        hp.text = "100 HP";
    }

    // Update is called once per frame
    void Update()
    {
        hpPart = (int)((sliderHP.value)*100);
        if (!player.activeSelf){
            hpPart = 0;
            sliderHP.value = 0;
        }
        hp.text = hpPart.ToString() + " HP";
    }
}
