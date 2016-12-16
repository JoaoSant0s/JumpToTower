using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class GoalModule : ICloneable {

    public enum GoalType {
        coin
    }

    [SerializeField]
    private GoalType type;
    [SerializeField]
    private float mount;

    public GoalType Type {
        get { return 
                type;
        }
    }

    public float Mount {
        get {
            return mount;
        }
        set {
            mount += value;
        }
    }

    public object Clone() {
        return this.MemberwiseClone();
    }
}
