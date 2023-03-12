using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Node : ScriptableObject
{

    public NodeComponent component = new NodeComponent();

    [Header("Core Component")]
    public BehaviourTreeComponent treeComponent;

    [Header("Editor component")]
    public Vector2 position;
    [TextArea(5, 5)] public string description;

    public NodeComponent.State Update() 
    {
        if (!component.started)
        {
            OnStart();
            component.started = true;
        }

        component.state = OnUpdate();

        if (component.state == NodeComponent.State.SUCCESS || component.state == NodeComponent.State.FAILURE)
        {
            OnStop();
            component.started = false;
        }

        return component.state;
    }

    public virtual Node Clone() 
    {
        return Instantiate(this);
    }

    public virtual void Abort()
    {
        OnStop();
        component.started = false;
        component.state = NodeComponent.State.FAILURE;
    }

    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract NodeComponent.State OnUpdate(); 

#region Draw Gizmos

    public virtual void DrawGizmos() 
    {

    } 

#endregion
}
