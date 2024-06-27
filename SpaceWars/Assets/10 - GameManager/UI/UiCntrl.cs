using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiCntrl : MonoBehaviour
{
    [SerializeField] private Slider sliderAmmo;
    [SerializeField] private Image sliderAmmoColor;
    [SerializeField] private TMP_Text ammoText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAmmo(float fraction)
    {
        ShowAmmoPercentage(fraction, Color.blue);
    }

    public void ReLoadAmmo(float fraction)
    {
        ShowAmmoPercentage(fraction, Color.yellow);
    }

    private void ShowAmmoPercentage(float fraction, Color color)
    {
        sliderAmmoColor.color = color;
        sliderAmmo.value = fraction;
        ammoText.text = ((int)(fraction * 100)).ToString() + "%";
    }

    private void OnEnable()
    {
        EventManager.Instance.OnUpdateAmmo += UpdateAmmo;
        EventManager.Instance.OnReloadAmmo += ReLoadAmmo;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnUpdateAmmo -= UpdateAmmo;
        EventManager.Instance.OnReloadAmmo -= ReLoadAmmo;
    }
}
