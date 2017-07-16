namespace PV178.Homeworks.HW01
{
    /// <summary>
    /// Allows user to play a game.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// This method starts the game - it asks for player name,
        /// then process commands until the game ends.
        /// </summary>
        void Start();
    }
}
