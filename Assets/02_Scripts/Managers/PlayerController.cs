using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 3f;

    bool _moveToDest = false;
    Vector3 _destPos;
    float wait_run_ratio;

    UI_Button uiPopup;


    //InputManager _input = new InputManager();
    // Start is called before the first frame update
    void Start()
    {
        //_input.KeyAction = OnKeyBoard;
        UnityManagers.Input.KeyAction -= OnKeyBoard;
        UnityManagers.Input.KeyAction += OnKeyBoard;
        UnityManagers.Input.MouseAction -= OnMouseClicked;
        UnityManagers.Input.MouseAction += OnMouseClicked;

        //ResourcesManager.Instance.Instantiate("UI_Button");


        uiPopup = UI_Managers.Instance.ShowPopupUI<UI_Button>("UI_Button");
        uiPopup = UI_Managers.Instance.ShowPopupUI<UI_Button>("UI_Button");
        uiPopup = UI_Managers.Instance.ShowPopupUI<UI_Button>("UI_Button");
        uiPopup = UI_Managers.Instance.ShowPopupUI<UI_Button>("UI_Button");
        uiPopup = UI_Managers.Instance.ShowPopupUI<UI_Button>("UI_Button");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UI_Managers.Instance.ClosePopupUI(uiPopup);
        }        
    }

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
    }

    PlayerState _state = PlayerState.Idle;

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }


        if (_moveToDest)
        {
            Vector3 dir = _destPos - transform.position;
            dir.y = 0;
            if (dir.magnitude < 0.01f)
            {
                _moveToDest = false;
            }
            else
            {
                float moveDist = Mathf.Clamp(_speed * Time.deltaTime,0,dir.magnitude);

                transform.position += dir.normalized * moveDist;
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),20 * Time.deltaTime);
            }
        }

        if (_moveToDest)
        {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("Blend",wait_run_ratio);
            anim.Play("AN_Run");
        }
        else
        {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10.0f * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("Blend", wait_run_ratio);
            anim.Play("AN_Idle");
        }
    }
    void UpdateDie()
    {

    }
    void UpdateMoving()
    {

    }
    void UpdateIdle()
    {

    }

    void OnKeyBoard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);
            transform.Translate(Vector3.forward * Time.unscaledDeltaTime * 3f);
            // transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            // transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
            // transform.position += Vector3.back * Time.deltaTime * _speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            // transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.Translate(Vector3.right * Time.deltaTime * _speed);
            // transform.position += Vector3.right * Time.deltaTime * _speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
            // transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        _moveToDest = false;
    }
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Ground")))
        {
            _destPos = hit.point;
            _moveToDest = true;
        }
    }

    
}
