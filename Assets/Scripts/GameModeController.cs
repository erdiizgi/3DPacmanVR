using System.Collections.Generic;
using UnityEngine;

public class GameModeController
{
    private List<GameMode> supportedGameModes;

    private static GameModeController _inst;
    private int currentIndex;

    public static GameModeController Instance
    {
        get
        {
            if (_inst == null)
                _inst = new GameModeController();

            return _inst;
        }
    }

    private GameModeController()
    {
        supportedGameModes = new List<GameMode>
        {
            new GameMode
            {
                Name = "GameMode1",
                IsVRMode = false,
                CharacterCanStop = true
            },
         new GameMode
         {
                Name = "RunningMode",
                IsVRMode = false,
                CharacterCanStop = false
            }
        };
    }

    public GameMode GetCurrent
    {
        get
        {
            return supportedGameModes[currentIndex];
        }
    }

    public void SetNextMode()
    {
        currentIndex = (currentIndex + 1) % (supportedGameModes.Count);
    }
}