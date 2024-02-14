using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Random = UnityEngine.Random;

public class ColourButton : NetworkBehaviour
{
    public IEnumerator coroutine;

    public Colours correctColour;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        StartSequence();
    }

    private void Start()
    {
        
    }


    void StartSequence()
    {
        coroutine = RandomColour();

        StartCoroutine(coroutine);

        //ShuffleColour();

    }

    IEnumerator RandomColour()
    {
        
        
        
        
        yield return new WaitForSeconds(5f);
        
        // From https://stackoverflow.com/questions/3132126/how-do-i-select-a-random-value-from-an-enumeration
        Array values = Enum.GetValues(typeof(Colours));
        Colours randomColour = (Colours)values.GetValue(Random.Range(0,values.Length));



        correctColour = randomColour;
        
        // Call ColourSet()
        ColourSetClientRpc(correctColour);

    }

    // Function that sets the colour. This is clientRpc
    [ClientRpc]
    void ColourSetClientRpc(Colours colours)
    {
        Debug.Log("WOO!");
        if (colours == Colours.Red)
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (colours == Colours.Green)
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }

        if (colours == Colours.Yellow)
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }

        if (colours == Colours.Blue)
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        
    }
    
    
    void ShuffleColour()
    {
        
        
    }










}
