using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace AdditionalClasses
{    
    public struct AbilityData
    {
        public readonly string name;
        public readonly string description;
        public readonly float boost;

        public AbilityData(string name, string description, float boost)
        {
            this.name = name;
            this.description = description;
            this.boost = boost;
        }
    }

    public struct DecryptionObject
    {
        #region Public Fields

        public string coordinate;
        public string lootLiteral;

        #endregion
    }
    
    public struct Palette
    {
        #region Public Fields

        public Color32 first;
        public Color32 second;
        public Color32 third;

        public Palette(Color32 first, Color32 second, Color32 third)
        {
            this.first = first;
            this.second = second;
            this.third = third;
        }
        #endregion
    }
}