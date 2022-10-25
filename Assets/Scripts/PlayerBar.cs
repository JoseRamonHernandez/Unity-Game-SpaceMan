using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public enum BarType{
    healthBar,
    manaBar
}

public class PlayerBar : MonoBehaviour
{

    private Slider slider;
    public BarType type;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        switch(type){
            case BarType.healthBar:
                slider.maxValue = playerController.MAX_HEALTH;
            break;
            case BarType.manaBar:
                slider.maxValue = playerController.MAX_MANA; 
                break; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(type){
            case BarType.healthBar:
                slider.value = GameObject.Find("Player").GetComponent<playerController>().GetHealth();
            break;
            case BarType.manaBar:
                slider.value = GameObject.Find("Player").GetComponent<playerController>().GetMana();
            break;
        }
    }
}
