using UnityEditor;

public static class AssetUpdater
{
    [MenuItem( "Assets/ForceReserializeAssets" )]
    private static void ForceReserializeAssets()
    {
        AssetDatabase.ForceReserializeAssets();
    }
}
