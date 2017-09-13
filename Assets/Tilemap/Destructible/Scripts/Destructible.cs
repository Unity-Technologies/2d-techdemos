using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class Destructible : TileBase 
{
	[Serializable]
	public class DecalGroup
	{
		public int m_MaskFilter;
		public Sprite m_Sprite;
		public Decal[] m_Decals;
				
		[Serializable]
		public class Decal
		{
			public int m_Mask;
			public Sprite m_DecalSprite;
		}
	}
	
	public RuleTile m_Undestructible;
	public Sprite m_DefaultSprite;
	public DecalGroup[] m_DecalGroups;
	
	public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
	{
		tileData.sprite = m_DefaultSprite;

		if (m_Undestructible != null)
		{
			m_Undestructible.GetTileData(position, tilemap, ref tileData);

			GridInformation info = tilemap.GetComponent<Transform>().gameObject.GetComponentInParent<GridInformation>();
			if (info != null && m_DecalGroups != null)
			{
				int mask = GetMask(info, position, tileData.transform);
				foreach (var decalGroup in m_DecalGroups)
				{
					if (decalGroup.m_Sprite == tileData.sprite)
					{
						foreach (var decal in decalGroup.m_Decals)
						{
							if (decal.m_Mask == (decalGroup.m_MaskFilter & mask))
							{
								tileData.sprite = decal.m_DecalSprite;
								return;
							}
						}
					}
				}
			}
		}
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

	private int GetMask(GridInformation info, Vector3Int position, Matrix4x4 transform)
	{
		int mask = HasExploded(info, position + GetTransformedPos(new Vector3Int(0, 1, 0), transform)) ? 1 : 0;
		mask += HasExploded(info, position + GetTransformedPos(new Vector3Int(1, 1, 0), transform)) ? 2 : 0;
		mask += HasExploded(info, position + GetTransformedPos(new Vector3Int(1, 0, 0), transform)) ? 4 : 0;
		mask += HasExploded(info, position + GetTransformedPos(new Vector3Int(1, -1, 0), transform)) ? 8 : 0;
		mask += HasExploded(info, position + GetTransformedPos(new Vector3Int(0, -1, 0), transform)) ? 16 : 0;
		mask += HasExploded(info, position + GetTransformedPos(new Vector3Int(-1, -1, 0), transform)) ? 32 : 0;
		mask += HasExploded(info, position + GetTransformedPos(new Vector3Int(-1, 0, 0), transform)) ? 64 : 0;
		mask += HasExploded(info, position + GetTransformedPos(new Vector3Int(-1, 1, 0), transform)) ? 128 : 0;
		
		return mask;
	}

	private bool HasExploded(GridInformation info, Vector3Int position)
	{
		return info.GetPositionProperty(position, "exploded", 0) > 0;
	}

	private Vector3Int GetTransformedPos(Vector3Int original, Matrix4x4 mat)
	{
		Vector3 transformed = mat.MultiplyPoint(new Vector3(original.x, original.y, original.z));
		return new Vector3Int(
			Mathf.RoundToInt(transformed.x),
			Mathf.RoundToInt(transformed.y),
			Mathf.RoundToInt(transformed.z)
			);
	}
}
