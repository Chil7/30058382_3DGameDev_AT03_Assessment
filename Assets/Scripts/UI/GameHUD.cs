using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;

    //crosshairs
    [SerializeField] private GameObject[] crosshairs;

    [SerializeField] private GameObject default_crosshair;
    [SerializeField] private GameObject attack_crosshair;
    [SerializeField] private GameObject key_crosshair;
    [SerializeField] private GameObject pickup_crosshair;
    [SerializeField] private GameObject plank_crosshair;

    private void Update()
    {
        //Change crosshair depending on what the camera is looking
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, 5))
        {


            if (hit.collider.gameObject.TryGetComponent<IInteraction>(out IInteraction inter1) && hit.collider.gameObject.TryGetComponent<Door>(out Door door))
            {
                UpdateCrosshair(key_crosshair);
            }

            if (hit.collider.gameObject.TryGetComponent<IInteraction>(out IInteraction inter2) && hit.collider.gameObject.TryGetComponent<MissingPlanks>(out MissingPlanks missingPlanks))
            {
                UpdateCrosshair(plank_crosshair);
            }

            if (hit.collider.gameObject.TryGetComponent<IInteraction>(out IInteraction inter3) && hit.collider.gameObject.TryGetComponent<Sword>(out Sword sword))
            {
                UpdateCrosshair(pickup_crosshair);
            }

            if (hit.collider.gameObject.TryGetComponent<Enemy>(out Enemy _enemy))
            {
                UpdateCrosshair(attack_crosshair);
            }
        }
        else
        {
            UpdateCrosshair(default_crosshair);
        }
    }

    public void UpdateCrosshair(GameObject _crosshair)
    {
        foreach (GameObject crosshair in crosshairs)
        {
            if (crosshair != _crosshair)
            {
                crosshair.SetActive(false);
            }
            else
            {
                crosshair.SetActive(true);
            }
        }
    }
}
