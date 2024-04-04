using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    [SerializeField] public Harvest _harvest;
    [SerializeField] public Seed _seed;

    // Harvest Analytics
    private Dictionary<string, int> _harvests = new Dictionary<string, int>();

    // Harvest to sell
    // Assignment 2 - Data structure to hold collected harvests
    public List<CollectedHarvest> collectedHarvests = new List<CollectedHarvest>();

    public static Harvester _instance;
       
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }

        _instance = this;
    }

    // Assignment 2
    public List<CollectedHarvest> GetCollectedHarvest()
    {
        return null;
    }

    // Assignment 2
    public void RemoveHarvest(CollectedHarvest harvest)
    {
        collectedHarvests.Remove(harvest);
    }

    // Assignment 2 - CollectHarvest method to collect the harvest when picked up
    public void CollectHarvest(string _plantName, int _harvestAmount, string _harvestTime)
    {
        CollectedHarvest harvestToStore = new CollectedHarvest();

        harvestToStore._name = _plantName;
        harvestToStore._amount = _harvestAmount;
        harvestToStore._time = _harvestTime;

        collectedHarvests.Add(harvestToStore);

        // Adding to analytics
        if (_harvests.ContainsKey(_plantName))
            _harvests[_plantName] += _harvestAmount;
        else
            _harvests.Add(_plantName, _harvestAmount);

        UIManager._instance.ShowTotalHarvest();

        UIManager._instance.UpdateStatus($"Collected {_harvestAmount} {_plantName}");
    }
    

    public void ShowHarvest(string plantName, int harvestAmount, int seedAmount, Vector2 position)
    {
        // initiate a harvest with random amount
        Harvest harvest = Instantiate(_harvest, position + Vector2.up + Vector2.right, Quaternion.identity);
        harvest.SetHarvest(plantName, harvestAmount);
        
        // initiate one seed object
        Seed seed = Instantiate(_seed, position + Vector2.up + Vector2.left, Quaternion.identity);
        seed.SetSeed(plantName, seedAmount);
    }

    //Assignment 3
    public void SortHarvestByAmount()
    {
        // Sort the collected harvest using Quick sort
        QuickSort(collectedHarvests, 0, collectedHarvests.Count-1);
        UIManager._instance.ShowTotalHarvest();
    }

    private void QuickSort (List<CollectedHarvest> list, int left, int right)
    {
        int switchVal;

        if (left < right)
        {
            switchVal = QuickSortPartition(list, left, right);

            if (switchVal > 1)
                QuickSort(list, left, switchVal - 1);
            if (switchVal+1 < right)
                QuickSort(list, switchVal + 1, right);
        }
    }

    private int QuickSortPartition (List<CollectedHarvest> list, int left, int right)
    {
        int switchVal = list[left]._amount;
        while(true)
        {
            while (list[left]._amount < switchVal)
                left++;
            while (list[right]._amount > switchVal)
                right--;

            if (left < right)
            {
                CollectedHarvest tempVal = list[right];
                list[right] = list[left];
                list[left] = tempVal;
            }
            else
                return right;
        }
    }

}

// For Assignment 2, this holds a collected harvest object
[System.Serializable]
public struct CollectedHarvest
{
    public string _name;
    public string _time;
    public int _amount;
    
    public CollectedHarvest(string name, string time, int amount)
    {
        _name = name;
        _time = time;
        _amount = amount;
    }
}