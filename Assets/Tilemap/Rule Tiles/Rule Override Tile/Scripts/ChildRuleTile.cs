using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class ChildRuleTile : RuleTile<ChildRuleTile.Neighbor> 
{
    public class Neighbor : RuleTile.TilingRule.Neighbor 
    {
        public new const int This = 1;
        public new const int NotThis = 2;
    }

    public override bool RuleMatch(int neighbor, TileBase tile) 
    {
        switch (neighbor) 
        {
            case Neighbor.This:
            {
                if (tile != null && tile != m_Self) 
                {
                    if (tile is RuleOverrideTile)
                    {
                        var overrideTile = (RuleOverrideTile) tile;
                        return (overrideTile.m_Tile == m_Self);
                    }
                    else if (m_Self is RuleOverrideTile)
                    {
                        var overrideTile = (RuleOverrideTile) m_Self;
                        return (overrideTile.m_Tile == tile);
                    }
                }
            }
            break;
        }
        return base.RuleMatch(neighbor, tile);
    }
}
