using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class Destructible : TileBase 
{
	public RuleTile m_Undestructible;
	public Sprite m_DefaultSprite;

	public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
	{
		tileData.sprite = m_DefaultSprite;

		if (m_Undestructible != null)
			m_Undestructible.GetTileData(position, tilemap, ref tileData);
	}

	public override void RefreshTile(Vector3Int position, ITilemap tilemap)
	{
		for (int y = -1; y <= 1; y++)
		{
			for (int x = -1; x <= 1; x++)
			{
				base.RefreshTile(position + new Vector3Int(x, y, 0), tilemap);
			}
		}
	}
}
