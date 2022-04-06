namespace Skiining_Amongst_Trees_Specs.Specs.StepDefinitions
{
    [Binding]
    public sealed class Skiining_Amongst_Trees_Steps
    {
        private readonly ScenarioContext context;
        public static char[,] skiBoard = new char[3, 3];
        public Skiining_Amongst_Trees_Steps(ScenarioContext context)
        {
            this.context = context;
        }
    }
}