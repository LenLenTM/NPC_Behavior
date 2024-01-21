using System.Collections.Generic;
using UnityEngine;

public class BT_Entity : Tree
{
    public static float viewRange = 6f;

    protected override Node SetupTree()
    {
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
            // sleep
            // work
            // leisure activities
            
        });

        root.SetData("target", transform);
        
        return root;
    }
}