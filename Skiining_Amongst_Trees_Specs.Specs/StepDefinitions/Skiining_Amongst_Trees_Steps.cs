using Skiing_Amongst_Trees;

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

        [Given(@"the file TreeMap\.txt")]
        public void GivenTheFileTreeMap_Txt()
        {
            string filePath = @"E:\Program Files\Git\SnowSE\etl---skiing-through-trees-Cortlynd101\Skiing_Amongst_Trees\TreeMap.txt";
            context.Add("filePath", filePath);
        }

        [When(@"reading the board")]
        public void WhenReadingTheBoard()
        {
            SkiBoard skiBoard = new SkiBoard();
            skiBoard = skiBoard.createSkiBoard(context.Get<string>("filePath"), skiBoard);
            context.Add("skiBoard", skiBoard);

        }

        [Then(@"the columns should be (.*)")]
        public void ThenTheColumnsShouldBe(int p0)
        {
            context.Get<SkiBoard>("skiBoard").columnCounter.Should().Be(p0);
        }

        [Then(@"the rows should be (.*)")]
        public void ThenTheRowsShouldBe(int p0) 
        {
            context.Get<SkiBoard>("skiBoard").rowCounter.Should().Be(p0);
        }

        [Given(@"the slope \((.*),(.*)\)")]
        public void GivenTheSlope(int p0, int p1)
        {
            context.Get<SkiBoard>("skiBoard").updatePosition(p0, p1);
        }

        [When(@"position is updated")]
        public void WhenPositionIsUpdated()
        {
            var position = context.Get<SkiBoard>("skiBoard").currentPosition;
            context.Add("positionRow", position.Item1);
            context.Add("positionColumn", position.Item2);
        }

        [Then(@"the new position should be \((.*),(.*)\)")]
        public void ThenTheNewPositionShouldBe(int p0, int p1)
        {
            context.Get<int>("positionRow").Should().Be(p0);
            context.Get<int>("positionColumn").Should().Be(p1);
        }

        [Given(@"current column is equal to (.*) and current row is (.*)")]
        public void GivenCurrentColumnIsEqualToAndCurrentRowIs(int p0, int p1)
        {
            context.Get<SkiBoard>("skiBoard").updatePosition(p0, p1-p1);
        }


        [Then(@"position in current row starts back at column (.*)")]
        public void ThenPositionInCurrentRowStartsBackAtColumn(int p0)
        {
            context.Get<int>("positionColumn").Should().Be(p0);
        }

        [When(@"you traverse the mountain with slope \((.*),(.*)\)")]
        public void WhenYouTraverseTheMountainWithSlope(int p0, int p1)
        {
            context.Get<SkiBoard>("skiBoard").traverseMountain(p0, p1);
        }


        [Then(@"the final position should be \((.*),(.*)\)")]
        public void ThenTheFinalPositionShouldBe(int p0, int p1)
        {
            var position = context.Get<SkiBoard>("skiBoard").currentPosition;
            context.Add("positionRow", position.Item1);
            context.Add("positionColumn", position.Item2);
            context.Get<int>("positionColumn").Should().Be(p0);
            context.Get<int>("positionRow").Should().Be(p1);
        }



    }
}