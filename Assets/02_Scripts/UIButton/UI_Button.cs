using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;


public class UI_Button : UI_Base
{
    enum Buttons
    {
        PointButton,
    }
    enum Texts
    {
        PointText,
        ScoreText,
    }
    enum GameObjects
    {
        TestObject,
        Image,
    }
    enum Images
    {
        Image,
    }
    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        Get<Text>((int)Texts.ScoreText).text = "Test";


        /*
        UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        evt.OnDragHnadler += ((PointerEventData data) => { go.transform.position = data.position; });
        */
        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);

        GameObject go = GetImage((int)Images.Image).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }
    int _score = 0;

    
    public void OnButtonClicked(PointerEventData data)
    {
        _score++;

        GetText((int)Texts.ScoreText).text = $"Á¡¼ö : {_score}";
    }
}
