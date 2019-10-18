using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ColorSync : RealtimeComponent
{
    private MeshRenderer _meshRenderer;
    private ColorSyncModel _model;
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();   
    }

    // Update is called once per frame
    private ColorSyncModel model {
        set {
            if (_model != null) {
                _model.colorDidChange -= ColorDidChange;
            }
            _model = value;

            if (_model != null) {
                UpdateMeshRendererColor();

                _model.colorDidChange += ColorDidChange;
            }
        }
    }
    private void ColorDidChange(ColorSyncModel model, Color value) {
        UpdateMeshRendererColor();
    }

    private void UpdateMeshRendererColor() {
        _meshRenderer.material.color = _model.color;
    }
    public void SetColor(Color color) {
        _model.color = color;
    }
}
