namespace MishaTheRodantSlayer.Core.Basics
{
    public static class Data
    {
        public static int ScreenWidth { get; set; } = 1600;
        public static int ScreenHeight { get; set; } = 900;
        public static bool ExitGame { get; set; } = false;
        public enum Screens { Menu, Game, Settings, Credits }
        public enum Directions { Right, Left, Up, Down }
        // public static Screens CurrentScene { get; set; } = Screens.Menu;
        public static Screens CurrentScene { get; set; } = Screens.Game;
    }
}