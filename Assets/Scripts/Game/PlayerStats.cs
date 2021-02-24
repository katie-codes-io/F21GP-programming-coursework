public static class PlayerStats
{
    //=========================================================//
    // Declare private variables
    private static int plants     = 0;
    private static int bugs       = 0;
    private static int plantScore = 10;
    private static int bugScore   = 5;
    private static int goldScore;

    //=========================================================//
    // Declare setters
    public static void SetPlants(int value) {
        plants = value;
    }

    public static void SetBugs(int value) {
        bugs = value;
    }

    public static void SetGoldScore(int value) {
        goldScore = value;
    }

    //=========================================================//
    // Declare getters
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

    public static int GetGoldScore() {
        return goldScore;
    }

    public static int GetTotalScore() {
        return GetBugScore() + GetPlantScore();
    }

}
