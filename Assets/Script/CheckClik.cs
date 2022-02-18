using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckClik : MonoBehaviour
{
    public GameTagFigurs gameTagFigurs;
    private StorageExistingInteractionObjects BaseCheck;
    private GameObject GetGameObject;
    private MainLogic mainLogic;

    private void Start()
    {
        BaseCheck = GetBaseCheck();
        mainLogic = FindObjectOfType<MainLogic>();
    }
    public StorageExistingInteractionObjects GetBaseCheck()
    {
        return FindObjectOfType<StorageExistingInteractionObjects>();
    }
    private void OnMouseDown()
    {
        if (gameObject.TryGetComponent<CheckClik>(out CheckClik checkClik))
        {
            GameTagFigurs CurrentEnumType = checkClik.gameTagFigurs;
            BaseCheck.SetFigure(gameObject);
            GetGameObject = BaseCheck.GetFigure();
            mainLogic.PlayLogic(CurrentEnumType, gameObject, GetGameObject);
        }
        Debug.Log("Нажатие");
    }
    
}
