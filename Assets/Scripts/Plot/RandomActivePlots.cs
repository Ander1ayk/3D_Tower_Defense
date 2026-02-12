using System.Collections.Generic;
using UnityEngine;

public class RandomActivePlots : MonoBehaviour
{
    [Header("Plots to Activate")]
    [SerializeField]private GameObject[] plotsToActivate;
    [SerializeField] private int maxActivePlots = 25;

    private void Start()
    {
        ActivateRandomPlots();
    }
    private void ActivateRandomPlots()
    {
        if (plotsToActivate.Length == 0 || plotsToActivate == null) return;

        foreach (GameObject plot in plotsToActivate)
        {
            if(plot != null)
            plot.SetActive(false);
        }
        List<GameObject> shuffledList = new List<GameObject>(plotsToActivate);

        for(int i = 0; i < shuffledList.Count; i++)
        {
            GameObject temp = shuffledList[i];
            int randomIndex = Random.Range(i, shuffledList.Count);
            shuffledList[i] = shuffledList[randomIndex];
            shuffledList[randomIndex] = temp;
        }
        int countToActive = Mathf.Min(maxActivePlots, shuffledList.Count);
        for(int i = 0; i < countToActive; i++)
        {
            if (shuffledList[i] != null)
                shuffledList[i].SetActive(true);
        }
    }
}
