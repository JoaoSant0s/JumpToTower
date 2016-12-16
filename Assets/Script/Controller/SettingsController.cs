using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsController : MonoBehaviour {
    public delegate void MenuActivity();
    public static event MenuActivity OnMenuActivity;


    [SerializeField]
    GameObject settingsPanel;

    [SerializeField]
    Button buttonReturn;

    void Start () {
        buttonReturn.onClick.AddListener(ButtonReturn);
        MenuController.OnSettingsActivity += SettingsActivity;
    }
	
	void OnDestroy () {
        MenuController.OnSettingsActivity -= SettingsActivity;
    }

    void ButtonReturn() {
        if (OnMenuActivity != null) {
            OnMenuActivity();
            settingsPanel.SetActive(false);
        }
    }


    void SettingsActivity() {
        settingsPanel.SetActive(true);
    }
}
