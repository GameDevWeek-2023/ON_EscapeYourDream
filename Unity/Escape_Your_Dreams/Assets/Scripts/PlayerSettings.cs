using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    private RotateCamera cameraMovement;
    private Camera mainCamera;
    [SerializeField]
    private bool applySettingsToScene = true;
    public Slider sliderView;
    public Slider sliderMouse;
    private void Start()
    {
        if (applySettingsToScene)
        {
            cameraMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<RotateCamera>();
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            loadAllSettings();
        }
        getAllSettings(out float mouseSensitivity, out int fov);
    }

    private void setMouseSensitivity(float speed)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", speed);
        if (applySettingsToScene)
        {
            cameraMovement.MouseSensitivity = speed;
        }
    }

    public void resetSetting()
    {
        setFOV(60);
        setMouseSensitivity(0.1f);
        getAllSettings(out float mouseSensitivity, out int fov);
    }

    public void doMouseSensitivity()
    {
        float moveMouse = sliderMouse.value;
        setMouseSensitivity(moveMouse);
    }

    public void doFieldofView()
    {
        int moveView = (int)sliderView.value;
        setFOV(moveView);
    }

    private void setFOV(int fov)
    {
        PlayerPrefs.SetInt("FOV", fov);
        if (applySettingsToScene)
        {
            mainCamera.fieldOfView = fov;
        }
    }

    private void loadAllSettings()
    {
        cameraMovement.MouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 0.1f);
        mainCamera.fieldOfView = PlayerPrefs.GetInt("FOV", 60);
    }

    public void getAllSettings(out float mouseSensitivity, out int fov)
    {
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 0.1f);
        fov = PlayerPrefs.GetInt("FOV", 60);
        sliderMouse.value = mouseSensitivity;
        sliderView.value = (float)fov; 
    }
}
