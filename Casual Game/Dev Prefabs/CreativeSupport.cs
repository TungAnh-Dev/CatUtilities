using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreativeSupport : MonoBehaviour
{
    public GameObject dropDown;
    public GameObject dropDownSkin;
    public Button toggleShowDropDown;
    public Button hideAllUIButton;
    public GameObject mainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        hideAllUIButton.onClick.AddListener(OnToggleUIButton);
        toggleShowDropDown.onClick.AddListener(OnToggleDropdownSelectLevel);
    }
    void OnToggleUIButton()
    {
        if (mainCanvas.gameObject.activeSelf)
        {
            mainCanvas.gameObject.SetActive(false);
        }
        else mainCanvas.gameObject.SetActive(true);
    }
    void OnToggleDropdownSelectLevel()
    {
        if (dropDown.gameObject.activeSelf)
        {
            dropDown.gameObject.SetActive(false);
            dropDownSkin.gameObject.SetActive(false);
        }
        else
        {
            dropDown.gameObject.SetActive(true);
            dropDownSkin.gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
