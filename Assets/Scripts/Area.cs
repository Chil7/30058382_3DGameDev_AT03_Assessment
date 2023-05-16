using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField] private Area[] neighbour;

    //Bool for if area is searched
    public bool isSearched = false;

    //Returns the Neighbours of the area
    public Area[] Neighbour { get { return neighbour; } }
}