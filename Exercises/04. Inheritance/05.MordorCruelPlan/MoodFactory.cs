public static class MoodFactory
{
    public static Mood GetMood(int happinessPoints)
    {
        Mood mood = null;

        if (happinessPoints < -5)
        {
            mood = new Angry();
        }
        else if (happinessPoints <= 0)
        {
            mood = new Sad();
        }
        else if (happinessPoints <= 15)
        {
            mood = new Happy();
        }
        else
        {
            mood = new JavaScript();
        }
        
        return mood;
    }
}