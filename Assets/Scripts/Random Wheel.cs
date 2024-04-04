using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWheel : MonoBehaviour
{
    string[] giftNames;
    float[] giftWeights;

    // Start is called before the first frame update
    void Start()
    {
        giftWeights = new float[10];

        SetGift("Plushy", 8);
        SetGift("Bag", 2);
        SetGift("Key Tag", 5);
        SetGift("Backpack", 1);
        SetGift("Hat", 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUpWeights ()
    {

    }

    void SetGift (string _giftName, float _weight)
    {
        for (int i=0; i<giftNames.Length; i++)
        {
            if (giftNames[i] == _giftName)
            {
                giftWeights[i] = _weight;
            }
        }
    }

    void GenerateRandom ()
    {

    }
}
