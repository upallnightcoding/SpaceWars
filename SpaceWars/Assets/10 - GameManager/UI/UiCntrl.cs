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

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gamePlayPanel;
    [SerializeField] private GameObject levelUpPanel;

    [SerializeField] private TMP_Text gamePlayXpText;
    [SerializeField] private TMP_Text levelUpXpText;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /******************/
    /** Menu Options **/
    /******************/

    public void NewGame()
    {
        EventManager.Instance.InvokeOnDisplayNewGamePanel();

        DisplayLevelUpPanel();
    }

    public void PlayRound()
    {
        EventManager.Instance.InvokeOnPlayRound();
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

    public void DisplayPlayRoundPanel()
    {
        mainMenuPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        levelUpPanel.SetActive(false);
    }

    public void DisplayLevelUpPanel()
    {
        mainMenuPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
        levelUpPanel.SetActive(true);
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
        EventManager.Instance.OnDisplayPlayRoundPanel += DisplayPlayRoundPanel;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnUpdateAmmo -= UpdateAmmo;
        EventManager.Instance.OnReloadAmmo -= ReLoadAmmo;
        EventManager.Instance.OnUpdateFighterHealth -= UpdateFighterHealth;
        EventManager.Instance.OnDisplayYoureDead -= DisplayYoureDead;
        EventManager.Instance.OnDisplayPlayRoundPanel -= DisplayPlayRoundPanel;
    }
}
