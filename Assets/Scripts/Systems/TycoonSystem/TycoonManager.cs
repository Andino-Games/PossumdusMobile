using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TycoonManager : MonoBehaviour
{
    public static TycoonManager instance;
    public List<TycoonMethods> allTycoonElements = new();
    public List<TycoonMethods> activatedTycoonElements = new();
    
    public event Action<float> onProgressUpdated;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterTycoonElement(TycoonMethods element)
    {
        if(!allTycoonElements.Contains(element))
        {
            allTycoonElements.Add(element);
        }
    }

    public void ActivateTycoonElement(TycoonMethods element)
    {
        if(!activatedTycoonElements.Contains(element))
        {
            activatedTycoonElements.Add(element);
            UpdateProgress();
        }
    }

    private void UpdateProgress()
    {
        float progress = (float)activatedTycoonElements.Count/allTycoonElements.Count;
        onProgressUpdated?.Invoke(progress);
    }
}
