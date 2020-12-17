using UnityEngine;

public class ArraySpawner
{
	public static void Spawn(string name,GameObject[] prefabs, Array2D array2D, float margin, Vector3 pos,Transform parent) {
        Transform grid = new GameObject(name).transform;
        grid.parent = parent;

        int[,] cells = array2D.GetCells();

        float firstPosX = array2D.GridSize.x / 2f;
        float firstPosY = array2D.GridSize.y / 2f;

        GameObject prefab;
        Vector3 position = pos;

        for(int i = 0; i < array2D.GridSize.x; i++) {
            for(int j = 0; j < array2D.GridSize.y; j++) {
                int index = cells[j, i];

                prefab = prefabs[index];
                position = new Vector3((i - firstPosX + 0.5f) * margin, 0, -(j - firstPosY + 0.5f) * margin);
                position += pos;
                
                if (prefab) {
                    MonoBehaviour.Instantiate(prefab, position, Quaternion.identity, grid);
                }
            }
        }
	}
}