public class FiniteStateMachine
{
    private void WanderTheMaze()
    {
        while (true)
        {
            if (spotPacMan)
            {
                ChasePacMan();
            }

            if (powerPellet)
            {
                FleePacMan();
            }
            
            // wander algorithm
        }
    }

    private void ChasePacMan()
    {
        while (true)
        {
            if (loseSightOfPacMan)
            {
                WanderTheMaze();
            }

            if (powerPellet)
            {
                FleePacMan();
            }
            
            // chase algorithm
        }
    }

    private void FleePacMan()
    {
        while (true)
        {
            if (!powerPellet)
            {
                WanderTheMaze();
            }

            if (eaten)
            {
                ReturnToBase();
            }
            
            // flee algorithm
        }
    }

    private void ReturnToBase()
    {
        // return to base algorithm
        
        WanderTheMaze();
    }
    
    
    private bool spotPacMan;
    private bool powerPellet;
    private bool loseSightOfPacMan;
    private bool eaten;
    
}