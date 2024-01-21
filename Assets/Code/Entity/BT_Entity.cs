using System;
using System.Collections.Generic;
using Code.BehaviorTree.Nodes.Checks;
using TMPro;
using UnityEngine;

public class BT_Entity : Tree
{
    public static float ViewRange = 2f;
    public static Hunger Hunger = new Hunger(0f);
    public static double Tiredness = 0f;
    public static double LeisureNeeds = 0f;
    public static double Work2Do = 0f;

    private TextMeshPro _hungerIndicator;
    private TextMeshPro _tirednessIndicator;
    private TextMeshPro _leisureNeedsIndicator;
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
            // work
            // leisure activities
            
        });

        root.SetData("target", transform);
        root.SetData("hunger", (double)0);
        
        return root;
    }

    private void InitChildren()
    {
        _hungerIndicator = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        _tirednessIndicator = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>();
        _leisureNeedsIndicator = gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshPro>();
        _work2DoIndicator = gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshPro>();
    }

    private void LateUpdate()
    {
        Hunger.Hungry += 0.003 * World.Speed;
        Tiredness += 0.001 * World.Speed;
        LeisureNeeds += 0.0005 * World.Speed;
        PrintUpdate();
    }

    private void PrintUpdate()
    {
        _hungerIndicator.SetText("Hunger: " + Math.Round(Hunger.Hungry, 2));
        _tirednessIndicator.SetText("Tiredness: " + Math.Round(Tiredness, 2));
        _leisureNeedsIndicator.SetText("LeisureNeeds: " + Math.Round(LeisureNeeds, 2));
        _work2DoIndicator.SetText("Work2Do: " + Math.Round(Work2Do, 2));
    }
}