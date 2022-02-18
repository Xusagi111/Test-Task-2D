using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Extension : MonoBehaviour
{
    [SerializeField] private List<GameObject> ListExternsionObject = new List<GameObject>();
    [SerializeField] private bool _isExtension;
    [SerializeField] private GameObject panelCountEnergy;
    [SerializeField] private Text CountEnergy;
    [SerializeField] private int _energy;
    public static Action EventAction;
    private void Start()
    {
        ActiveExtension();
        if (_isExtension)
        {
            EventAction = �heatingEnergy;
            UpdateDisplayUI();
        }
    }
    private void ActiveExtension()
    {
        foreach (var item in ListExternsionObject)
        {
            item.SetActive(_isExtension);
        }
        panelCountEnergy.SetActive(_isExtension);
    }
    private void �heatingEnergy()
    {
        int CurrentCountEnergy = int.Parse(CountEnergy.text);
        CurrentCountEnergy -= 1;
        CountEnergy.text = CurrentCountEnergy.ToString();
    }
    private void UpdateDisplayUI()
    {
        CountEnergy.text =  _energy.ToString();
    }
}
