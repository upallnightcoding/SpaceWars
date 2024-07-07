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

    [SerializeField] private GameObject yourDeadBanner;
    [SerializeField] private GameObject endEngagementBanner;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject engagePanel;
    [SerializeField] private GameObject levelUpPanel;

    [SerializeField] private TMP_Text gamePlayXpText;
    [SerializeField] private TMP_Text levelUpXpText;

    [SerializeField] private TMP_Text engageCountDownText;

    [SerializeField] private GameObject engageCountDown;

    /******************/
    /** Menu Options **/
    /******************/

    public void HideEngageCountDown()
        => engageCountDown.SetActive(false);

    public void ShowEndEngagementBanner()
        => endEngagementBanner.SetActive(true);

    public void DisplayEngageCountDown(int count)
    {
        if (count != 0)
        {
            engageCountDownText.fontSize = 200;
            engageCountDownText.text = count.ToString();
        } else
        {
            engageCountDownText.fontSize = 52;
            engageCountDownText.text = "Engage";
        }
    }

    public void NewGame()
    {
        EventManager.Instance.InvokeOnDisplayNewGamePanel();

        DisplayLevelUpPanel();
    }

    public void LoadGame()
    {
        EventManager.Instance.InvokeOnDisplayLoadGamePanel();
    }

    public void UpdateXP(long value)
    {
        gamePlayXpText.text = value.ToString() + " XP";
        levelUpXpText.text = value.ToString() + " XP";
    }

    public void DisplayEngagePanel()
    {
        mainMenuPanel.SetActive(false);
        engagePanel.SetActive(true);
        levelUpPanel.SetActive(false);
    }

    public void DisplayLevelUpPanel()
    {
        mainMenuPanel.SetActive(false);
        engagePanel.SetActive(false);
        levelUpPanel.SetActive(true);
    }

    public void DisplayYoureDead()
    {
        yourDeadBanner.SetActive(true);
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
        //EventManager.Instance.OnDisplayEngagePanel += DisplayEngagePanel;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnUpdateAmmo -= UpdateAmmo;
        EventManager.Instance.OnReloadAmmo -= ReLoadAmmo;
        EventManager.Instance.OnUpdateFighterHealth -= UpdateFighterHealth;
        EventManager.Instance.OnDisplayYoureDead -= DisplayYoureDead;
        //EventManager.Instance.OnDisplayEngagePanel -= DisplayEngagePanel;
    }
}
