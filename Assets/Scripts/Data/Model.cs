using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public sealed class Model
    {
        public ModelName name;
        public GameObject model;

        public Model(ModelName name, GameObject model)
        {
            this.name = name;
            this.model = model;
        }
    }
}