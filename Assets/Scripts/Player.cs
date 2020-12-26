using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInputEventProvider playerInputEventProvider;

    // public IReadOnlyReactiveProperty<ITouchable> CurrentTouch => currentTouch;
    // private ReactiveProperty<ITouchable> currentTouch = new ReactiveProperty<ITouchable>();
    
    private Camera camera;
    
    private void Awake()
    {
        camera = Camera.main;
        
        playerInputEventProvider.Touch.Subscribe(touchPos =>
        {
            // タッチした後の処理
            var ray = camera.ScreenPointToRay(touchPos);
            Raycast(ray);
            
        }).AddTo(this);
    }

    private void Raycast(Ray ray)
    {
        var hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider == null) return;
        
        var touchable = hit.transform.gameObject.GetComponent<ITouchable>();
        if (touchable.Touched.Value) return;
        
        // currentTouch.Value = touchable;
        touchable.Touch(hit.point);
    }
}
