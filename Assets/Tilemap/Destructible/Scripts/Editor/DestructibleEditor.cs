using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

[CustomEditor(typeof(Destructible))]
public class DestructibleEditor : Editor
{
	public Destructible tile
	{
		get { return (target as Destructible); }
	}

	public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
	{
		return PreviewUtil.RenderStaticPreview(tile.m_DefaultSprite, width, height);
	}
}

