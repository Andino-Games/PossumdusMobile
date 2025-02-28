using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TycoonManager : MonoBehaviour
{
    public static TycoonManager instance;
    public List<TycoonMethods> allTycoonElements = new();
    public List<TycoonMethods> activatedTycoonElements = new();
    [SerializeField]private int _gameProgress { set; get; }
    public int GameProgress 
    { 
       get { return _gameProgress; }
        set { _gameProgress = value; }
    }
    
    public event Action<int> OnProgressUpdated;

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
       if(allTycoonElements.Count == 0)
        {
            return;
        }
       GameProgress = Mathf.RoundToInt((float) activatedTycoonElements.Count/allTycoonElements.Count * 100);
        OnProgressUpdated?.Invoke(GameProgress);
    }
}
