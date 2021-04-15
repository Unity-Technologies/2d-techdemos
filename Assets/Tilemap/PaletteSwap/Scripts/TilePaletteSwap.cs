using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class TilePaletteSwap : MonoBehaviour
{
    private Tilemap m_Tilemap;

    public int m_ActiveTilePaletteIdx = 0;
    public List<GameObject> m_TilePalettes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        m_Tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SwapPalette(m_ActiveTilePaletteIdx - 1);
        if (Input.GetKeyDown(KeyCode.S))
            SwapPalette(Random.Range(0, m_TilePalettes.Count));
        if (Input.GetKeyDown(KeyCode.D))
            SwapPalette(m_ActiveTilePaletteIdx + 1);
    }

    /// <summary>
    /// This swaps the Tiles in the Tilemap from the current Palette to the next Palette.
    /// Tiles in each Palette are mapped based on their relative position. This requires each
    /// Palette to have the same size.
    /// Please modify this to introduce your own swapping behaviour!
    /// </summary>
    /// <param name="newTilePaletteIdx">Palette Index to swap to</param>
    public void SwapPalette(int newTilePaletteIdx)
    {
        var currentTilePaletteIdx = m_ActiveTilePaletteIdx;
        newTilePaletteIdx = (m_TilePalettes.Count + newTilePaletteIdx) % m_TilePalettes.Count;
        if (newTilePaletteIdx >= m_TilePalettes.Count || currentTilePaletteIdx == newTilePaletteIdx)
            return;

        var currentTilePaletteTilemap = m_TilePalettes[currentTilePaletteIdx].GetComponentInChildren<Tilemap>();
        var newTilePaletteTilemap = m_TilePalettes[newTilePaletteIdx].GetComponentInChildren<Tilemap>();

        if (currentTilePaletteTilemap.size == newTilePaletteTilemap.size)
        {
            var d = new Dictionary<TileBase, TileBase>();
            var n  = new BoundsInt(newTilePaletteTilemap.origin, newTilePaletteTilemap.size).allPositionsWithin;
            n.Reset();
            foreach (var c in new BoundsInt(currentTilePaletteTilemap.origin, currentTilePaletteTilemap.size).allPositionsWithin)
            {
                n.MoveNext();
                var currentTile = currentTilePaletteTilemap.GetTile(c);
                var newTile = newTilePaletteTilemap.GetTile(n.Current);
                if (currentTile != null && newTile != null)
                {
                    d[currentTile] = newTile;
                }
            }
            foreach (var pair in d)
            {
                m_Tilemap.SwapTile(pair.Key, pair.Value);
            }
        }
        m_ActiveTilePaletteIdx = newTilePaletteIdx;
    }
}
