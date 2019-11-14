using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class ExampleSiblingRuleTile : RuleTile
{

    public enum SibingGroup
    {
        Poles,
        Terrain,
    }
    public SibingGroup sibingGroup;

    public override bool RuleMatch(int neighbor, TileBase other)
    {
        if (other is RuleOverrideTile)
            other = (other as RuleOverrideTile).m_InstanceTile;

        switch (neighbor)
        {
            case TilingRule.Neighbor.This:
                {
                    return other is ExampleSiblingRuleTile
                        && (other as ExampleSiblingRuleTile).sibingGroup == this.sibingGroup;
                }
            case TilingRule.Neighbor.NotThis:
                {
                    return !(other is ExampleSiblingRuleTile
                        && (other as ExampleSiblingRuleTile).sibingGroup == this.sibingGroup);
                }
        }

        return base.RuleMatch(neighbor, other);
    }
}
