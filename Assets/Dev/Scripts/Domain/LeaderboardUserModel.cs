namespace Dev.Scripts.Domain
{
    public class LeaderboardUserModel
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public int Rank { get; private set; }

        public LeaderboardUserModel(string name, int score, int rank)
        {
            Name = name;
            Score = score;
            Rank = rank;
        }
    }
}