public static class PlayerStats
{
    private static int plants     = 0;
    private static int bugs       = 0;
    private static int plantScore = 10;
    private static int bugScore   = 5;
    private static int maxScore;

    // Setters
    public static void SetPlants(int value) {
        plants = value;
    }

    public static void SetBugs(int value) {
        bugs = value;
    }

    public static void SetMaxScore(int value) {
        maxScore = value;
    }

    // Getters
    public static int GetPlants() {
        return plants;
    }

    public static int GetBugs() {
        return bugs;
    }

    public static int GetPlantScore() {
        return plantScore;
    }

    public static int GetBugScore() {
        return bugScore;
    }

    public static int GetTotalPlantScore() {
        return plants * plantScore;
    }

    public static int GetTotalBugScore() {
        return bugs * bugScore;
    }

    public static int GetMaxScore() {
        return maxScore;
    }

    public static int GetTotalScore() {
        return GetBugScore() + GetPlantScore();
    }

}
