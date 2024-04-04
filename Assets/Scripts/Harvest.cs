using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Harvest : MonoBehaviour
{
    [SerializeField] public Sprite[] _sprites;

    private string _plantName;
    private int _harvestAmount;
    private DateTime _harvestTime;

    public void SetHarvest(string plantName, int harvestAmount)
    {
        // Set harvest sprite and amount
        GetComponent<SpriteRenderer>().sprite = Planter._instance.GetPlantResourseByName(plantName)._harvestSprite;
        _plantName = plantName;
        _harvestAmount = harvestAmount;
        _harvestTime = System.DateTime.Now;

        GetComponent<ClickableObject>().OnClicked.AddListener(() => { CollectHarvest(_plantName, _harvestAmount, _harvestTime.ToString()); });
    }

    public void CollectHarvest(string plantName, int harvestAmount, string harvestTime)
    {
        // Assignment 2
        // Call the harvester to harvest this element
        Harvester._instance.CollectHarvest(plantName, harvestAmount, harvestTime);

        Destroy(gameObject);
    }
}
