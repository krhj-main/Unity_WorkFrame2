using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public virtual void Init()
    {
        UI_Managers.Instance.SetCanvas(gameObject,true);
    }
    public virtual void ClosePopupUI()
    {
        UI_Managers.Instance.ClosePopupUI(this);
    }
}
