using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Canvas BookCanva;
    [SerializeField] private AutoFlip flipScript;
    [SerializeField] private Flowchart mainChart;

    PlayerMovement movementScript;
    private InputManager _inputManager; 
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        movementScript = GetComponent<PlayerMovement>();
        BookCanva.enabled = false;
        flipScript.enabled = false;
    }

    private void Start() => _inputManager = ServiceLocator.Instance.GetService<InputManager>();

    private void Update()
    {
        _inputManager.HandelAllInputs();
        movementScript.HandleAllRotations();

        if(_inputManager.BookCanva && mainChart.GetBooleanVariable("HasBook"))
        {
            BookCanva.enabled = !BookCanva.enabled;
            flipScript.enabled = !flipScript.enabled;
            _inputManager.BookCanva = false;
            if (BookCanva.enabled)
            {
                mainChart.SetBooleanVariable("BookOpen", true);
            }
            else
            {
                mainChart.SetBooleanVariable("BookOpen", false);
            }
        }
        //controlls.HandleAllInputs();
    }

    public void setLookAt(Transform obj)
    {
        transform.LookAt(obj);
    }

    private void FixedUpdate()
    {
        movementScript.handleAllMovement();
        //locomotion.handleAllMovement();
    }
}
