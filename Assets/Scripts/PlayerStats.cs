public static class PlayerStats
{
    private static int score;
    private static int maxPossible;

    public static int GetScore() {
        return score;
    }

    public static void SetScore(int value) {
        score = value;
    }

    public static int GetMaxPossible() {
        return maxPossible;
    }

    public static void SetMaxPossible(int maxValue) {
        maxPossible = maxValue;
    }

}
