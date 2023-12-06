using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    /// <summary>
    /// Represents a game difficulty level with associated parameters.
    /// </summary>
    [System.Serializable]
    public class DifficultyLevel
    {
        /// <summary>
        /// The name of the difficulty level.
        /// </summary>
        public string name;

        /// <summary>
        /// The icon representing the difficulty level.
        /// </summary>
        public Sprite icon;

        /// <summary>
        /// A list of parameters for this difficulty level.
        /// </summary>
        public List<Parameter> parameters;

        /// <summary>
        /// The number of bombs available at the begining of this difficulty level.
        /// </summary>
        public int startBombsCount;
        
        /// <summary>
        /// The number of doubleUps available at the begining of this difficulty level.
        /// </summary>
        public int startDoubleUpsCount;
        
        /// <summary>
        /// The number of cards available at the begining of this difficulty level.
        /// </summary>
        public int startCardsCount;
    }

    /// <summary>
    /// Represents a parameter with a name, minimum, and maximum values.
    /// </summary>
    [System.Serializable]
    public class Parameter
    {
        /// <summary>
        /// The name of the parameter.
        /// </summary>
        public string name;

        /// <summary>
        /// The minimum value for the parameter.
        /// </summary>
        public int min;

        /// <summary>
        /// The maximum value for the parameter.
        /// </summary>
        public int max;
    }
}