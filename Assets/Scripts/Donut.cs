using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Donut : MonoBehaviour, ITouchable
{
    public IReadOnlyReactiveProperty<bool> Touched => touched;
    private ReactiveProperty<bool> touched = new ReactiveProperty<bool>();

    public void Touch(Vector2 touchPos)
    {
        touched.Value = true;
        
        // 判定処理を書く
        Judge.Apply(touchPos, transform.position);
    }
}
