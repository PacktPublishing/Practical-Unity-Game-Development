using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

namespace UnityEditor
{
    [CustomGridBrush(false, false, false, "Tint Brush")]
    public class TintBrush : GridBrushBase
    {

        public Color customColor = Color.white;

        public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
        {
            base.Paint(gridLayout, brushTarget, position);

            if (brushTarget.layer == 31)
            {
                return;
            }

            Tilemap tilemap = brushTarget.GetComponent<Tilemap>();
            if (tilemap != null)
            {
                Tint(position, customColor, tilemap);
            }
        }

        public override void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
        {
            base.Erase(gridLayout, brushTarget, position);

            if(brushTarget.layer == 31)
            {
                return;
            }

            Tilemap tilemap = brushTarget.GetComponent<Tilemap>();
            if (tilemap != null)
            {
                Tint(position, Color.white, tilemap);
            }
        }

        private static void Tint(Vector3Int position, Color color, Tilemap tilemap)
        {
            if ((tilemap.GetTileFlags(position) & TileFlags.LockColor) != 0)
            {
                Debug.LogWarning("Some Warning"); //TODO: give more useful info
                return;
            }

            TileBase tile = tilemap.GetTile(position);
            if (tile != null)
            {
                tilemap.SetColor(position, color);
            }
        }
    }

    [CustomEditor(typeof(TintBrush))]
    public class TintBrushEditor : GridBrushEditorBase
    {
        public override GameObject[] validTargets
        {
            get
            {
                return GameObject.FindObjectsOfType<Tilemap>().Select(x => x.gameObject).ToArray();
            }
        }
    }
}
