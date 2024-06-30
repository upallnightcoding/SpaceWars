using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiCntrl : MonoBehaviour
{
    [SerializeField] private Slider fighterAmmoSlider;
    [SerializeField] private Image fighterAmmoColor;
    [SerializeField] private TMP_Text fighterAmmoText;

    [SerializeField] private Slider fighterHealthSlider;
    [SerializeField] private TMP_Text fighterHealthText;

    [SerializeField] private GameObject youreDeadText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayYoureDead()
    {
        youreDeadText.SetActive(true);
    }

    public void UpdateFighterHealth(float fraction)
    {
        fighterHealthSlider.value = fraction;
        fighterHealthText.text = ((int)(fraction * 100)).ToString() + "%";
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
        fighterAmmoColor.color = color;
        fighterAmmoSlider.value = fraction;
        fighterAmmoText.text = ((int)(fraction * 100)).ToString() + "%";
    }

    private void OnEnable()
    {
        EventManager.Instance.OnUpdateAmmo += UpdateAmmo;
        EventManager.Instance.OnReloadAmmo += ReLoadAmmo;
        EventManager.Instance.OnUpdateFighterHealth += UpdateFighterHealth;
        EventManager.Instance.OnDisplayYoureDead += DisplayYoureDead;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnUpdateAmmo -= UpdateAmmo;
        EventManager.Instance.OnReloadAmmo -= ReLoadAmmo;
        EventManager.Instance.OnUpdateFighterHealth -= UpdateFighterHealth;
        EventManager.Instance.OnDisplayYoureDead -= DisplayYoureDead;
    }
}
