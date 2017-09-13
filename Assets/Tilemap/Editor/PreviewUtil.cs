using System.Reflection;
using UnityEngine;

public static class PreviewUtil
{
	public static Texture2D RenderStaticPreview(Sprite sprite, int width, int height)
	{
		System.Type t = GetType("UnityEditor.SpriteUtility");
		if (t != null)
		{
			MethodInfo method = t.GetMethod("RenderStaticPreview",
				new System.Type[] {typeof (Sprite), typeof (Color), typeof (int), typeof (int)});
			if (method != null)
			{
				object ret = method.Invoke("RenderStaticPreview", new object[] {sprite, Color.white, width, height});
				if (ret is Texture2D)
					return ret as Texture2D;
			}
		}
		return null;
	}

	private static System.Type GetType(string TypeName)
	{
		var type = System.Type.GetType(TypeName);
		if (type != null)
			return type;

		if (TypeName.Contains("."))
		{
			var assemblyName = TypeName.Substring(0, TypeName.IndexOf('.'));
			var assembly = Assembly.Load(assemblyName);
			if (assembly == null)
				return null;
			type = assembly.GetType(TypeName);
			if (type != null)
				return type;
		}

		var currentAssembly = Assembly.GetExecutingAssembly();
		var referencedAssemblies = currentAssembly.GetReferencedAssemblies();
		foreach (var assemblyName in referencedAssemblies)
		{
			var assembly = Assembly.Load(assemblyName);
			if (assembly != null)
			{
				type = assembly.GetType(TypeName);
				if (type != null)
					return type;
			}
		}
		return null;
	}
}

