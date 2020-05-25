using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameInput : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private TMP_InputField ipAddressInputField = null;
    [SerializeField] private Button continueButton = null;

    public static string DisplayName { get; private set; }
    private const string PlayerPrefNameKey = "PlayerName";

    private void Start()
    {
        //SetUpInputField();
        //SetPlayerName();
    }

    /*
    private void SetUpInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefNameKey))
            return;

        string defaultName = PlayerPrefs.GetString(PlayerPrefNameKey);
        nameInputField.text = defaultName;

        SetPlayerName(defaultName);
    }
    */

    public void SetPlayerName()
    {
        Debug.Log(nameInputField.text);
        continueButton.interactable = !string.IsNullOrEmpty(nameInputField.text);
    }

    public void SavePlayerName()
    {
        DisplayName = nameInputField.text;
        Debug.Log(DisplayName);
        PlayerPrefs.SetString(PlayerPrefNameKey, DisplayName);
    }
}
