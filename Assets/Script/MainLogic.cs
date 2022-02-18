using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameTagFigurs
{
    Circle,
    Square,
    Triangle,
}
public class MainLogic : MonoBehaviour
{
    StorageExistingInteractionObjects BaseCheck;
    private void Start()
    {
        BaseCheck = GetComponent<StorageExistingInteractionObjects>();
    }
    public void PlayLogic(GameTagFigurs gameTagFigurs, GameObject CurrentGameobj, GameObject GetGameObj)
    {
        switch(gameTagFigurs)
        {
             case GameTagFigurs.Circle:
                if (GetGameObj.GetComponent<CheckClik>().gameTagFigurs == GameTagFigurs.Square) 
                {
                    CheckTransformFigure(CurrentGameobj, GetGameObj);
                }
                else
                {
                    BaseCheck.ResetFigure();
                }
                break;
            case GameTagFigurs.Square:
                if (GetGameObj.GetComponent<CheckClik>().gameTagFigurs == GameTagFigurs.Triangle)
                {
                    GetTransformationTriagle(CurrentGameobj, GetGameObj);
                }
                break;
            case GameTagFigurs.Triangle:
                break;
        }
    }
    public void CheckTransformFigure(GameObject GetFigure, GameObject CurrentFigure)
    {
        Vector3 GetfigureScale = GetFigure.transform.localScale; 
        Vector3 CurrentFigureScale = CurrentFigure.transform.localScale;
        if((GetfigureScale.x * 0.7) >= CurrentFigureScale.x  || (GetfigureScale.y * 0.7) >= CurrentFigureScale.y) 
        {
            CurrentFigure.transform.position = GetFigure.transform.position;
            CurrentFigure.gameObject.GetComponent<SpriteRenderer>().sortingOrder = GetFigure.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
            CurrentFigure.gameObject.GetComponent<SpriteRenderer>().sortingOrder +=1;
            RemoveClickToFigure(GetFigure, CurrentFigure);
            SavePlayerState.SaveCountState(1);
        }
        BaseCheck.ResetFigure();
    }
    public void GetTransformationTriagle(GameObject CurrentGameObject, GameObject GetGameObj)
    {
        Vector3 CurrentfigureScale = CurrentGameObject.transform.localScale;
        if(CurrentfigureScale.x >1 || CurrentfigureScale.y > 1 )
        {
            CurrentfigureScale = new Vector3(CurrentfigureScale.x - 1, CurrentfigureScale.y - 1, CurrentfigureScale.z);
            CurrentGameObject.transform.localScale = CurrentfigureScale;
            Destroy(GetGameObj);
            Extension.EventAction?.Invoke();
        }
        BaseCheck.ResetFigure();
        
    }
    public void RemoveClickToFigure(GameObject gameObject, GameObject gameObject1)
    {
        gameObject.layer = 2;
        gameObject1.layer = 2;
    }
}
