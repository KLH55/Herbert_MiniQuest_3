using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontSizeController : MonoBehaviour
{
    public Text displayText;
    public Text inputPlaceholder;
    public Text inputText;

    private bool largeFont;
    // Start is called before the first frame update
    void Start()
    {
        Toggle toggle = GetComponent<Toggle>();

        int pref = PlayerPrefs.GetInt("fontSize", 1);
        if (pref == 1)
        {
            toggle.isOn = true;
            largeFont = true;
        }
        else
        {
            toggle.isOn = false;
            largeFont = false;
        }
        SetTheme();
        toggle.onValueChanged.AddListener(ProccessChange);
    }

    void ProccessChange(bool value)
    {
        largeFont = value;
        PlayerPrefs.SetInt("fontSize", largeFont ? 1 : 0);
        SetTheme();
    }

    void SetTheme()
    {
        if (largeFont)
        {
            displayText.fontSize = 30;
            inputPlaceholder.fontSize = 30;
            inputText.fontSize = 30;
        }
        else
        {
            displayText.fontSize = 25;
            inputPlaceholder.fontSize = 25;
            inputText.fontSize = 25;
        }
    }
}
