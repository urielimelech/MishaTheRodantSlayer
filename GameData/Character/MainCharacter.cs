using System.Collections.Generic;

namespace GameData.Character;

public class MainCharacter : Character
{
    private readonly List<string> movementFrameNames;
    private readonly string standingFrameName;
    public MainCharacter() : base()
    {
        movementFrameNames = [
            "misha_walk_0",
            "misha_walk_1",
            "misha_walk_2"
        ];
        standingFrameName = "misha_stand";
    }

    public List<string> GetMovementFrameNames()
    {
        return movementFrameNames;
    }
    public string GetStandingFrameName()
    {
        return standingFrameName;
    }
}