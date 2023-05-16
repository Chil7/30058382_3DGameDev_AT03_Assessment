using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField] private Area[] neighbour;

    //Bool for if area is searched
    public bool isSearched = false;
    public bool timerActive = false;

    //Timer for isSearched Reset
    private float searchResetTimer = 15f;

    //Returns the Neighbours of the area
    public Area[] Neighbour { get { return neighbour; } }

    private void Update()
    {
        if (isSearched == true && timerActive == false)
        {
            StartCoroutine(SearchedReset());
        }
    }

    IEnumerator SearchedReset()
    {
        timerActive = true;
        while (searchResetTimer > 0 && timerActive == true)
        {
            yield return new WaitForSeconds(1f);
            searchResetTimer--;
        }
        isSearched = false;
        timerActive = false;
    }
}
