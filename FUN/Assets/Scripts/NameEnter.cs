using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    
public class NameEnter : MonoBehaviour
{
    public string theName;
    public TMP_InputField inputField;   // Change GameObject to TMP_InputField
    public TextMeshProUGUI textDisplay;  // Change GameObject to TextMeshProUGUI

    public void StoreName()
    {
        theName = inputField.text;
        textDisplay.text = "Hello, " + theName + " chutiya hai tu "; // Add missing exclamation mark
    }
}
