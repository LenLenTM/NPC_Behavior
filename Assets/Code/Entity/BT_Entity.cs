﻿using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BT_Entity : Tree
{
    public static float ViewRange = 2f;
    public Hunger Hunger = new Hunger(55f);
    public Sleep Sleep = new Sleep(0f);
    public static Work Work = new Work(55f);

    private TextMeshPro _hungerIndicator;
    private TextMeshPro _tirednessIndicator;
    private TextMeshPro _work2DoIndicator;

    protected override Node SetupTree()
    {
        InitChildren();

        // Define possible actions for Entity here. (first: highest priority, last: fallback action).
        Node root = new Selector(new List<Node>()
        {
            // flee from enemy
            new Sequence(new List<Node>()
            {
                new EnemyInRange(transform),
                new GoToTarget(transform)
            }),
            
            // eat
            new Sequence(new List<Node>()
            {
                new IsHungry(Hunger, transform),
                new GoToTarget(transform),
                new Eating(Hunger)
            }),
            
            // sleep
            new Sequence(new List<Node>()
            {
                new IsTired(Sleep, transform),
                new GoToTarget(transform),
                new Sleeping(Sleep)
            }),
            
            
            // work
            new Sequence(new List<Node>()
            {
                new Needs2Work(transform),
                new GoToTarget(transform),
                new Working()
            }),
            
            // leisure activities
            new Sequence(new List<Node>()
            {
                new ChooseLeisureActivity(transform),
                new GoToTarget(transform),
                new Not( new List<Node>()
                {
                    new WatchingMovie()
                }),
                new Not( new List<Node>()
                {
                    new BeingWithFriends()
                }),
                new Not( new List<Node>()
                {
                    new Gaming()
                })
            }),
            
            // going home
            new Sequence(new List<Node>()
            {
                new GoingHome(),
                new GoToTarget(transform)
            })
            
        });

        root.SetData("target", transform);
        root.SetData("hunger", (double)0);
        root.SetData("sleep", false);
        root.SetData("leisure", "");
        root.SetData("leisureTime", (int)0);
        
        return root;
    }

    private void InitChildren()
    {
        _hungerIndicator = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        _tirednessIndicator = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>();
        _work2DoIndicator = gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshPro>();
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