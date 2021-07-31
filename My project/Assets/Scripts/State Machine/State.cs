using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class State<T>
{
    public virtual void EnterState(T entity) { }

    public virtual void TickState(T entity) { }

    public virtual void FixedUpdateTick(T entity) { }

    public virtual void ExitState(T entity) { }
}