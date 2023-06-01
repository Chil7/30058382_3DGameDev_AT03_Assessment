using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    //crosshairs
    [SerializeField] private GameObject default_crosshair;
    [SerializeField] private GameObject attack_crosshair;
    [SerializeField] private GameObject key_crosshair;

    private void Update()
    {
        //Change crosshair depending on what the camera is looking
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, 5))
        {
            if (hit.collider.gameObject.TryGetComponent<IInteraction>(out IInteraction inter))
            {
                KeyCrosshair();
            }

            if (hit.collider.gameObject.TryGetComponent<Enemy>(out Enemy _enemy))
            {
                AttackCrosshair();
            }
        }
        else
        {
            DefaultCrosshair();
        }
    }

    public void KeyCrosshair()
    {
        key_crosshair.SetActive(true);
        attack_crosshair.SetActive(false);
        default_crosshair.SetActive(false);
    }

    public void AttackCrosshair()
    {
        key_crosshair.SetActive(false);
        attack_crosshair.SetActive(true);
        default_crosshair.SetActive(false);
    }

    public void DefaultCrosshair()
    {
        key_crosshair.SetActive(false);
        attack_crosshair.SetActive(false);
        default_crosshair.SetActive(true);
    }
}
