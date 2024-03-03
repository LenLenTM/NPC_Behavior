using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GOAP_Entity : MonoBehaviour
{
    public Slider HungerSlider;
    public Slider TirednessSlider;
    public Slider WorkSlider;
    public GameObject HungerValue;
    public GameObject TirednessValue;
    public GameObject WorkValue;
    
    public static float ViewRange = 2f;
    public Hunger Hunger = new Hunger(55f);
    public Sleep Sleep = new Sleep(0f);
    public static Work Work = new Work(55f);
    
    private TextMeshPro _hungerIndicator;
    private TextMeshPro _tirednessIndicator;
    private TextMeshPro _work2DoIndicator;

    private List<BaseAction> _actions;
    private List<BaseGoal> _goals;
    private Planner _planner = new Planner();

    private void InitChildren()
    {
        _hungerIndicator = HungerValue.GetComponent<TextMeshPro>();
        _tirednessIndicator = TirednessValue.GetComponent<TextMeshPro>();
        _work2DoIndicator = WorkValue.GetComponent<TextMeshPro>();
        HungerSlider.value = (float)Hunger.Hungry;
        TirednessSlider.value = (float)Sleep.Tiredness;
        WorkSlider.value = (float)Work.Work2Do;
    }

    private void InitGOAP()
    {
        _actions = new List<BaseAction>()
        {
            new Eating_GOAP(this),
            new GoTo_GOAP(this),
            new LeisureActivity_GOAP(this),
            new Sleeping_GOAP(this),
            new Working_GOAP(this)
        };

        _goals = new List<BaseGoal>()
        {
            new Home_GOAP(this),
            new Hunger_GOAP(this),
            new Leisure_GOAP(this),
            new Tiredness_GOAP(this),
            new Work_GOAP(this)
        };
    }
    
    public void ResetStats()
    {
        Hunger = new Hunger(55f);
        Sleep = new Sleep(0f);
        Work = new Work(55f);
    }

    private void Awake()
    {
        InitChildren();
        InitGOAP();
    }

    private void LateUpdate()
    {
        Hunger.Hungry += 0.002 * World.Speed;
        Sleep.Tiredness += 0.0015 * World.Speed;
        HungerSlider.value = (float)Hunger.Hungry;
        TirednessSlider.value = (float)Sleep.Tiredness;
        WorkSlider.value = (float)Work.Work2Do;
        Hunger.Hungry = HungerSlider.value;
        Sleep.Tiredness = TirednessSlider.value;
        Work.Work2Do = WorkSlider.value;
        PrintUpdate();
        _planner.PlanningAndExecution(_actions, _goals);
    }

    private void PrintUpdate()
    {
        _hungerIndicator.SetText("Hunger: " + Math.Round(Hunger.Hungry, 2));
        _tirednessIndicator.SetText("Tiredness: " + Math.Round(Sleep.Tiredness, 2));
        _work2DoIndicator.SetText("Work2Do: " + Math.Round(Work.Work2Do, 2));
    }
    
    public void UpdateHunger(double value)
    {
        Hunger.Hungry += value;
    }
        
    public void UpdateTiredness(double value)
    {
        Sleep.Tiredness += value;
    }
        
    public void UpdateWork(double value)
    {
        Work.Work2Do += value;
    }
}