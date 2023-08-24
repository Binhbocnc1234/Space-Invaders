using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPrototype
{
    public IPrototype Clone();
    public void SetPrototype(object prototype);
}
