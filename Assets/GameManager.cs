using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public enum Colours
{
    Red,
    Blue,
    Green,
    Yellow,
}

public class GameManager : MonoBehaviour
{
    public List<Plate> colourPlates;
    
    private void Awake()
    {
//          colour = GameObject.FindObjectOfType<Plate>(false).ToList();


    }
}
