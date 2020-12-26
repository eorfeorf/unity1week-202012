using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInputEventProvider : MonoBehaviour, IInputEventProvider
{
    public IReadOnlyReactiveProperty<Vector2> Touch => touch;
    private ReactiveProperty<Vector2> touch = new ReactiveProperty<Vector2>();

    private void Update()
    {
        // タッチ処理を記述
        if (Input.GetMouseButtonDown(0))
        {
            touch.Value = Input.mousePosition;
        }
    }
}
