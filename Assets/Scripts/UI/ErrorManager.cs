using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorManager : MonoBehaviour
{
    [SerializeField] private Text errorText;
    [SerializeField] private Text itemPickedUpText;

    [SerializeField] private bool isActive = false;

    private float errorTimeCountdown;
    private float errorTimeSec = 3f;

    private float popUpCountdown;
    private float popUpTimeSec = 2f;

    public static ErrorManager errorManager { get; private set; }

    private void Start()
    {
        if (errorManager == null)
        {
            errorManager = this;
        }

        errorTimeCountdown = errorTimeSec;
        popUpCountdown = popUpTimeSec;
        errorText.gameObject.SetActive(false);
        itemPickedUpText.gameObject.SetActive(false);
    }

    public void Error (int num, string item)
    {
        if (isActive == false)
        {
            isActive = true;
            errorText.gameObject.SetActive(true);
            StartCoroutine(RefreshError());

            switch (num)
            {
                case 3:
                    errorText.text = "It needs a plank";
                    break;

                case 2:
                    errorText.text = "Door is locked, it needs a " + item;
                    break;

                case 1:
                    errorText.text = "You can only pick one " + item + " at a time";
                    break;
            }
        }
    }

    public void Popup (string item)
    {
        itemPickedUpText.gameObject.SetActive(true);
        itemPickedUpText.text = "You picked up a " + item;
        StartCoroutine(RefreshPopUp());
    }

    IEnumerator RefreshError()
    {
        while (errorTimeCountdown > 0)
        {
            yield return new WaitForSeconds(1f);
            errorTimeCountdown--;
        }
        errorTimeCountdown = errorTimeSec;
        isActive = false;
        errorText.gameObject.SetActive(false);
    }

    IEnumerator RefreshPopUp()
    {
        while (popUpCountdown > 0)
        {
            yield return new WaitForSeconds(1f);
            popUpCountdown--;
        }
        popUpCountdown = popUpTimeSec;
        itemPickedUpText.gameObject.SetActive(false);
    }
}
