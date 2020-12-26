using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface ITouchable
{
    IReadOnlyReactiveProperty<bool> Touched { get; }
    
    void Touch(Vector2 touchPos);
}
