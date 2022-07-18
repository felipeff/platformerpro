using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private CharacterController _controller;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private float _gravity = -40.0f;

    private float _verticalVelocity = 0.0f;

    [SerializeField]
    private float _jumpHeight = 4.0f;

    private bool _doubleJump = true;

    [SerializeField]
    private int _coins = 0;
    [SerializeField]
    private int _lives = 3;

    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_controller == null)
            Debug.LogError("Something really went wrong.  I can't find the character controller");

        if (_uiManager == null)
            Debug.LogError("Something really went wrong. I can't find the UI Manager");

        _uiManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float vertical = 0.0f;

        if (Input.GetKeyDown(KeyCode.Space) && (_controller.isGrounded || _doubleJump))
        {
            vertical = Mathf.Sqrt(2.0f * Mathf.Abs(_gravity) * _jumpHeight);
            if (!_controller.isGrounded)
                _doubleJump = false;
        }
        else if (!_controller.isGrounded)
        {
            vertical = _verticalVelocity + (_gravity * Time.deltaTime);
        }
        else
        {
            //Set to -1 because I was having issues with the character controller isGrounded.
            vertical = -1.0f;
            _doubleJump = true;
        }

        Vector3 movement = new Vector3(horizontal * _speed, vertical, 0);

        _verticalVelocity = vertical;
        if(_controller.enabled)
            _controller.Move(movement * Time.deltaTime);

    }

    public void AddCoins()
    {
        _coins += 1;
        _uiManager.UpdateScore(_coins);
    }

    public void RemoveLife()
    {
        _lives--;
        _uiManager.UpdateLivesDisplay(_lives);

        if (_lives < 1) // gameover
            SceneManager.LoadScene(0);
    }
}
