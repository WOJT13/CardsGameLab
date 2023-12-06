using System.Collections.Generic;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Manages a list of game difficulty levels.
    /// </summary>
    [System.Serializable]
    public class DifficultyLevelsList
    {
        private List<DifficultyLevel> difficultyLevels = new List<DifficultyLevel>();

        /// <summary>
        /// Adds a new difficulty level to the list.
        /// </summary>
        public void Create(DifficultyLevel difficultyLevel)
        {
            difficultyLevels.Add(difficultyLevel);
        }

        /// <summary>
        /// Retrieves a list of all available difficulty levels.
        /// </summary>
        /// <returns>The list of difficulty levels.</returns>
        public List<DifficultyLevel> GetAll()
        {
            return difficultyLevels;
        }

        /// <summary>
        /// Retrieves a difficulty level by its name.
        /// </summary>
        /// <param name="name">The name of the difficulty level to find.</param>
        /// <returns>The difficulty level with the specified name, or null if not found.</returns>
        public DifficultyLevel GetByName(string name)
        {
            return difficultyLevels.FirstOrDefault(dl => dl.name == name);
        }

        /// <summary>
        /// Updates an existing difficulty level with new data.
        /// </summary>
        /// <param name="difficultyLevel">The updated difficulty level data.</param>
        public void Update(DifficultyLevel difficultyLevel)
        {
            DifficultyLevel levelToUpdate = difficultyLevels.FirstOrDefault(dl => dl.name == difficultyLevel.name);
            if (levelToUpdate != null)
            {
                levelToUpdate.startBombsCount = difficultyLevel.startBombsCount;
                levelToUpdate.startDoubleUpsCount = difficultyLevel.startDoubleUpsCount;
                levelToUpdate.startCardsCount = difficultyLevel.startCardsCount;
                levelToUpdate.icon = difficultyLevel.icon;
                levelToUpdate.parameters = difficultyLevel.parameters;
            }
        }

        /// <summary>
        /// Deletes a difficulty level by its name.
        /// </summary>
        /// <param name="name">The name of the difficulty level to delete.</param>
        public void Delete(string name)
        {
            DifficultyLevel levelToDelete = difficultyLevels.FirstOrDefault(dl => dl.name == name);
            if (levelToDelete != null)
            {
                difficultyLevels.Remove(levelToDelete);
            }
        }
    }
}