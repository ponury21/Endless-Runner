using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nameInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se= new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
    }
        private void SubmitName(string arg0)
    {
        UIManager.Instance.SetName(arg0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}