using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class CustomTypeRuleTile : RuleTile<CustomTypeRuleTile.Neighbor> 
{
    public class Neighbor : RuleTile.TilingRule.Neighbor 
    {
        public const int SameType = 3;
    }

    public override bool RuleMatch(int neighbor, TileBase tile) 
    {
        switch (neighbor) {
            case 2: return tile == null || !(tile is CustomTypeRuleTile); 
            case Neighbor.SameType: return tile is CustomTypeRuleTile;
        }
        return base.RuleMatch(neighbor, tile);
    }
}
