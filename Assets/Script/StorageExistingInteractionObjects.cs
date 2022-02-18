using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageExistingInteractionObjects : MonoBehaviour
{
    [SerializeField] List<GameObject> Figure = new List<GameObject>();
    public GameObject GetFigure()
    {
        return Figure[0];
    }
    public void SetFigure(GameObject figurs)
    {
        
        if (Figure.Count > 1)
        {
            ResetFigure();
        }
        Figure.Add(figurs);
    }
    public void ResetFigure()
    {
        Figure.Clear();
    }
}
