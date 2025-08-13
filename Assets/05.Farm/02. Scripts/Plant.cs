using System;
using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private enum PlantState { Level1, Level2, Level3 }
    private PlantState plantState;

    private DateTime startTime, growthTime, harvestTime;
    public int plantIndex;
    public bool isHarvestable = false;

    private void Awake()
    {
        startTime = DateTime.Now;
        growthTime = startTime.AddSeconds(5);
        harvestTime = growthTime.AddSeconds(10);


    }

    IEnumerator Start()
    {
        SetState(PlantState.Level1);

        while (true)
        {
            if (DateTime.Now >= growthTime && plantState == PlantState.Level1)
            {
                SetState(PlantState.Level2);
            }
            else if (DateTime.Now >= harvestTime && plantState == PlantState.Level2)
            {
                SetState(PlantState.Level3);
                isHarvestable = true;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void SetState(PlantState newState)
    {
        if (plantState != newState || plantState == PlantState.Level1)
        {
            plantState = newState;
            for (int i = 0; i < 3; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            transform.GetChild((int)plantState).gameObject.SetActive(true);
        }
    }
}
