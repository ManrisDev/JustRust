public static class GlobalVar
{
    private static int level_index = 0;
    private static int lives = 8;

    public static int Get_level_index()
    {
        return level_index;
    }

    public static void Set_level_index(int level_index_)
    {
        level_index = level_index_;
    }

    public static int Get_lives()
    {
        return lives;
    }

    public static void Set_lives(int lives_)
    {
        lives = lives_;
    }
}
