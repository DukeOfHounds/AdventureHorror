using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MovmentInterface
{
    public void UpdateCamera(float mouseX, float mouseY);

    public void UpdatePosition(float horizontal1D, float vertical1D);

    public void Jump();

}
