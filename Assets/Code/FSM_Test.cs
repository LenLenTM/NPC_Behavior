public class FiniteStateMachine
{

    private bool spotPacMan;
    private bool powerPellet;
    private bool loseSightOfPacMan;
    private bool eaten;

    void WanderTheMaze()
    {
        while (true)
        {
            // wander algorithm

            if (spotPacMan)
            {
                ChasePacMan();
            }

            if (powerPellet)
            {
                FleePacMan();
            }
        }
    }

    void ChasePacMan()
    {
        // chase algorithm

        if (loseSightOfPacMan)
        {
            WanderTheMaze();
        }

        if (powerPellet)
        {
            FleePacMan();
        }
    }

    void FleePacMan()
    {
        // flee algorithm
        
        if (!powerPellet)
        {
            WanderTheMaze();
        }

        if (eaten)
        {
            ReturnToBase();
        }
    }

    void ReturnToBase()
    {
        // return to base algorithm
        
        WanderTheMaze();
    }
    
}