// Yeah, I guess it's a cheap way to do global state, but let's be real, this is a jam game.

public static class GameState
{
    /// <summary>
    /// Scales from 0-100. This should be used in minigame code to make things more difficult.
    /// </summary>
    public static float Difficulty;
    
    /// <summary>
    /// How much time until the next sequence.
    /// </summary>
    public static float Time;
    
    /// <summary>
    /// The combo count for CodeTracer.
    /// </summary>
    public static float CodeCombo;
    
    public static int CurrentGame = BlockDistState;

    // States for GameState.CurrentGame. Affects which minigames tick active/inactive.
    public const int MenuState = 0;
    public const int BlockDistState = 1;
    public const int CodeTraceState = 2;
    public const int PianoSaysState = 3;
    public const int ArtGameState = 4;
    public const int BuildState = 5;

    public static bool IsBlockDistractionsActive()
    {
        return CurrentGame == BlockDistState;
    }

    public static bool IsCodeTracerActive()
    {
        return CurrentGame == CodeTraceState;
    }

    public static bool IsPianoSaysActive()
    {
        return CurrentGame == PianoSaysState;
    }

    public static bool IsArtGameActive()
    {
        return CurrentGame == ArtGameState;
    }

    public static bool IsBuildStationActive()
    {
        return CurrentGame == BuildState;
    }
}
