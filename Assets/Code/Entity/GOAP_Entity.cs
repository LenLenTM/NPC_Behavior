using System;
using TMPro;
using UnityEngine;

public class GOAP_Entity : MonoBehaviour
{
    public static float ViewRange = 2f;
    public Hunger Hunger = new Hunger(55f);
    public Sleep Sleep = new Sleep(0f);
    public static Work Work = new Work(55f);
    
    private TextMeshPro _hungerIndicator;
    private TextMeshPro _tirednessIndicator;
    private TextMeshPro _work2DoIndicator;
    
    private void InitChildren()
    {
        _hungerIndicator = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        _tirednessIndicator = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>();
        _work2DoIndicator = gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshPro>();
    }

    private void Awake()
    {
        InitChildren();
    }

    private void LateUpdate()
    {
        Hunger.Hungry += 0.002 * World.Speed;
        Sleep.Tiredness += 0.0015 * World.Speed;
        PrintUpdate();
    }

    private void PrintUpdate()
    {
        _hungerIndicator.SetText("Hunger: " + Math.Round(Hunger.Hungry, 2));
        _tirednessIndicator.SetText("Tiredness: " + Math.Round(Sleep.Tiredness, 2));
        _work2DoIndicator.SetText("Work2Do: " + Math.Round(Work.Work2Do, 2));
    }
}