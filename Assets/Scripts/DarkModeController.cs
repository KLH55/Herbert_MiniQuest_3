using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkModeController : MonoBehaviour
{
    public Image background;
    public Text displayText;
    public Text darkModeToggleText;
    public Text inputPlaceholder;
    public Text inputText;
    public Text fontToggleText;

    private bool darkMode;
    // Start is called before the first frame update
    void Start()
    {
        Toggle toggle = GetComponent<Toggle>();
        // darkMode = toggle.isOn;
        
        int pref = PlayerPrefs.GetInt("theme", 1); // uses 1 as default if not already set
        if (pref == 1) // darkmode is the preference
        {
            toggle.isOn = true;
            darkMode = true;
        }
        else // otherwise, go with lightmode
        {
            toggle.isOn = false;
            darkMode = false;
        }

        SetTheme();
        toggle.onValueChanged.AddListener(ProcessChange);
    }

    void ProcessChange(bool value)
    {
        darkMode = value;
        PlayerPrefs.SetInt("theme", darkMode ? 1 : 0);
        SetTheme();
    }

    void SetTheme()
    {
        if (darkMode)
        {
            background.color = Color.black;
            displayText.color = Color.white;
            darkModeToggleText.color = Color.white;
            inputPlaceholder.color = Color.white;
            inputText.color = Color.white;
            fontToggleText.color = Color.white;
        }
        else
        {
            background.color = Color.white;
            displayText.color = Color.black;
            darkModeToggleText.color = Color.black;
            inputPlaceholder.color = Color.black;
            inputText.color = Color.black;
            fontToggleText.color = Color.black;
        }
    }
}
