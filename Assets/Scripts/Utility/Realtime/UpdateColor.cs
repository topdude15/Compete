using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateColor : MonoBehaviour
{
    public Color _objColor;
    private Color _previousObjColor;

    private ColorSync _colorSync;
    // Start is called before the first frame update
    void Start()
    {
        _colorSync = GetComponent<ColorSync>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_objColor != _previousObjColor) {
            _colorSync.SetColor(_objColor);
            _previousObjColor = _objColor;
        }
    }
}
    