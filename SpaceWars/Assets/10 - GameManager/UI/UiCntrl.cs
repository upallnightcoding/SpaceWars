using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiCntrl : MonoBehaviour
{
    [SerializeField] private Slider sliderAmmo;
    [SerializeField] private TMP_Text ammoText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAmmo(float value)
    {
        sliderAmmo.value = value;
        ammoText.text = ((int)(value * 100)).ToString() + "%";
    }

    private void OnEnable()
    {
        EventManager.Instance.OnUpdateAmmo += UpdateAmmo;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnUpdateAmmo -= UpdateAmmo;
    }
}
