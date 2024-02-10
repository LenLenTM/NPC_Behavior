public class FiniteStateMachine
{

    private bool spotPacMan;
    private bool powerPellet;
    private bool loseSightOfPacMan;
    private bool eaten;

    private void WanderTheMaze()
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

    private void ChasePacMan()
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

    private void FleePacMan()
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

    private void ReturnToBase()
    {
        // return to base algorithm
        
        WanderTheMaze();
    }
    
}