using Model;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    /// <summary>
    /// Manages game difficulty levels and initializes them.
    /// </summary>
    public class DifficultyManager : MonoBehaviour
    {
        /// <summary>
        /// The list of available difficulty levels.
        /// </summary>
        public DifficultyLevelsList difficultyLevelsList = new DifficultyLevelsList();

        /// <summary>
        /// The icon representing the "Easy" difficulty level.
        /// </summary>
        public Sprite easyIcon;

        /// <summary>
        /// The icon representing the "Hard" difficulty level.
        /// </summary>
        public Sprite hardIcon;

        /// <summary>
        /// Called on object initialization.
        /// Initializes and adds predefined difficulty levels to the list.
        /// </summary>
        private void Awake()
        {
            var easyLevel = new DifficultyLevel
            {
                name = "Easy",
                icon = easyIcon,
                parameters = new List<Parameter>()
            };
            easyLevel.parameters.Add(new Parameter() { name = "ParametrA", min = 1, max = 10 });
            easyLevel.bombCount = 3;
            difficultyLevelsList.Create(easyLevel);

            var hardLevel = new DifficultyLevel
            {
                name = "Hard",
                icon = hardIcon,
                parameters = new List<Parameter>()
            };
            hardLevel.parameters.Add(new Parameter() { name = "ParametrA", min = 1, max = 10 });
            hardLevel.parameters.Add(new Parameter() { name = "ParametrB", min = 5, max = 15 });
            hardLevel.bombCount = 5;
            difficultyLevelsList.Create(hardLevel);

            DataManager.Instance.difficultyLevelsList = difficultyLevelsList;
        }
    }
}