using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[NodeAttribute("Unity/Animation")]
public class AnimationNode : ActionNode
{
    public override void CopyNode(ActionNode copyNode)
    {
        
    }

    protected override NodeComponent.State OnUpdate()
    {
        return NodeComponent.State.SUCCESS;
    }
}
