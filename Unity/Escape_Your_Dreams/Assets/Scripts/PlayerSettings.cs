using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    private RotateCamera cameraMovement;
    private Camera mainCamera;
    [SerializeField]
    private bool applySettingsToScene = true;
    private void Start()
    {
        if (applySettingsToScene)
        {
            cameraMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<RotateCamera>();
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            loadAllSettings();
        }
    }

    public void setMouseSensitivity(float speed)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", speed);
        cameraMovement.MouseSensitivity = speed;
    }

    public void setFOV(int fov)
    {
        PlayerPrefs.SetFloat("FOV", fov);
        mainCamera.fieldOfView = fov;
    }

    private void loadAllSettings()
    {
        cameraMovement.MouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 0.1f);
        mainCamera.fieldOfView = PlayerPrefs.GetInt("FOV", 60);
    }
}
