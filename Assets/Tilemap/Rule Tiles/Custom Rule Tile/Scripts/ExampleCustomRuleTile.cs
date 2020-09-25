using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Windows;

[CreateAssetMenu]
public class ExampleCustomRuleTile : RuleTile<ExampleCustomRuleTile.Neighbor> 
{
    public bool desert;

    public class Neighbor : RuleTile.TilingRule.Neighbor 
    {
        public const int SameTerrain = 3;
        public const int DifferentTerrain = 4;
    }

    public override bool RuleMatch(int neighbor, TileBase tile)
    {
        var customRule = tile as ExampleCustomRuleTile;
        switch (neighbor) 
        {
            case Neighbor.SameTerrain: 
                return customRule && this.desert == customRule.desert;
            case Neighbor.DifferentTerrain: 
                return customRule && this.desert != customRule.desert;
        }
        return base.RuleMatch(neighbor, tile);
    }
}
