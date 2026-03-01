using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    GameObject playerObject;
    [SerializeField] TMP_Dropdown resolutionDropDown;
    [SerializeField] Slider mouseSensitivitySlider;
    Resolution[] resolutions;

    public int sensativity;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        PopulateResDropDownm();
    }

    public void ChangeSensativity()
    {
        int newSensativty = (int)mouseSensitivitySlider.value;
        sensativity = newSensativty;
        playerObject.GetComponent<PlayerLook>().mouseSensitivity = newSensativty;
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void PopulateResDropDownm()
    {
        List<string> options = new List<string>();
        int currentResIndex = 0;
        resolutions = Screen.resolutions;

        int counter = 0;
        foreach(Resolution res in resolutions)
        {
            counter++;
            options.Add(res.width + "x" + res.height);
            if (res.width == Screen.width && res.height == Screen.height)
            {
                currentResIndex = counter;
            }
 
        }
        resolutionDropDown.ClearOptions();
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void ChangeResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height ,Screen.fullScreen);
    }

}
