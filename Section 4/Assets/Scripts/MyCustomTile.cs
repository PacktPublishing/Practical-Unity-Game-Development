using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine.Tilemaps
{
    [Serializable]
    public class MyCustomTile : Tile
    {
        [SerializeField]
        public Sprite wallTile;

        [SerializeField]
        public Sprite specialTile;

        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            base.GetTileData(position, tilemap, ref tileData);

            if(wallTile != null && specialTile != null)
            {
                if(tilemap.GetTile(position + new Vector3Int(-1,0,0)) == this &&
                   tilemap.GetTile(position + new Vector3Int(1, 0, 0)) == this &&
                   tilemap.GetTile(position + new Vector3Int(0, 1, 0)) == this &&
                   tilemap.GetTile(position + new Vector3Int(0, -1, 0)) == this)
                {
                    tileData.sprite = specialTile;
                } else
                {
                    tileData.sprite = wallTile;
                }
            }
        }

#if UNITY_EDITOR
        [MenuItem("Assets/Tiles/MyCustomTile")]
        public static void CreateTile()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save My Custom Tile",
                                                    "New MyCustomTile",
                                                    "asset",
                                                    "Save My Custom Tile",
                                                    "Assets");
            if (path == "")
                return;

            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<MyCustomTile>(), path);
        }
        #endif
    }
}
