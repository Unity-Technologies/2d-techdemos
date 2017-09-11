using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseClickBomb : MonoBehaviour
{
	public const string k_Key = "exploded";

	public TileBase m_Border;
	public TileBase m_ExplodedFloor;
	public GameObject m_Explosion;
	
	private Grid m_Grid;
	private Tilemap m_Foreground;
	private Tilemap m_BackGround;
	private GridInformation m_Info;

	// Use this for initialization
	void Start ()
	{
		m_Grid = GetComponent<Grid>();
		m_Info = GetComponent<GridInformation>();
		m_Foreground = GameObject.Find("Foreground").GetComponent<Tilemap>();
		m_BackGround = GameObject.Find("Background").GetComponent<Tilemap>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (m_Grid && Input.GetMouseButtonDown(0))
		{
			Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3Int gridPos = m_Grid.WorldToCell(world);

			ExplodeCell(gridPos);
			ExplodeCell(gridPos + new Vector3Int(-1, 0, 0));
			ExplodeCell(gridPos + new Vector3Int(-2, 0, 0));
			ExplodeCell(gridPos + new Vector3Int(1, 0, 0));
			ExplodeCell(gridPos + new Vector3Int(2, 0, 0));
			ExplodeCell(gridPos + new Vector3Int(0, -1, 0));
			ExplodeCell(gridPos + new Vector3Int(0, -2, 0));
			ExplodeCell(gridPos + new Vector3Int(0, 1, 0));
			ExplodeCell(gridPos + new Vector3Int(0, 2, 0));
		}
	}

	private void ExplodeCell(Vector3Int position)
	{
		if (m_Foreground.GetTile(position) == m_Border)
			return;

		m_Info.ErasePositionProperty(position, k_Key);
		m_Info.SetPositionProperty(position, k_Key, 1);
		foreach (var pos in new BoundsInt(position.x - 1, position.y - 1, position.z, 3, 3, 1).allPositionsWithin)
		{
			if (m_Foreground.GetTile(pos) != null)
			{
				m_BackGround.SetTile(pos, m_ExplodedFloor);
			}
		}
		m_Foreground.SetTile(position, null);

		GameObject.Instantiate(m_Explosion, m_Grid.CellToLocalInterpolated(position + new Vector3(0.5f, 0.5f)), Quaternion.identity);
	}
}
