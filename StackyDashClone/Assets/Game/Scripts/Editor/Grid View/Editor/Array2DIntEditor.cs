using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Array2D))]
public class Array2DIntEditor : Array2DEditor
{
    protected override int CellWidth { get { return 18; } }
    protected override int CellHeight { get { return 18; } }

    protected override void SetValue(SerializedProperty cell, int i, int j) {
        int[,] previousCells = (target as Array2D).GetCells();

        cell.intValue = default(int);

        if (i < gridSize.vector2IntValue.y && j < gridSize.vector2IntValue.x) {
            cell.intValue = previousCells[i, j];
        }
    }
}
