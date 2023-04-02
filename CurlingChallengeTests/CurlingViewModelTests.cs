using CurlingChallenge.ViewModels;

namespace CurlingChallengeTests
{
    public class CurlingViewModelTests
    {
        [Fact]
        public void InvalidNumbers()
        {
            //Setup
            var curling = new CurlingViewModel();

            //Execute
            curling.ExecuteSimulateCommand();

            //Tests
            AssertError("Shapes", "Please enter a valid number of shapes.", curling.Errors);
            AssertError("Size", "Please enter a valid shape size.", curling.Errors);
            Assert.True(string.IsNullOrEmpty(curling.TextOutput));
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(500, true)]
        [InlineData(1000, true)]
        [InlineData(1001, false)]
        public void NumberRangeErrors(int number, bool valid)
        {
            //Setup
            var curling = new CurlingViewModel();
            curling.Shapes = number;

            //Execute
            curling.ExecuteSimulateCommand();

            //Tests
            AssertError("Shapes", "Number of shapes out of range.", curling.Errors, !valid);
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(500, true)]
        [InlineData(1000, true)]
        [InlineData(1001, false)]
        public void SizeRangeErrors(int size, bool valid)
        {
            //Setup
            var curling = new CurlingViewModel();
            curling.Size = size;

            //Execute
            curling.ExecuteSimulateCommand();

            //Tests
            AssertError("Size", "Shape size out of range.", curling.Errors, !valid);
        }

        [Fact]
        public void ValidCircle() => ValidShape("Circle");

        [Fact]
        public void ValidSquare() => ValidShape("Square");

        [Fact]
        public void ValidTriangle() => ValidShape("Triangle");

        private void ValidShape(string shape)
        {
            //Setup
            var curling = new CurlingViewModel();
            curling.Curling = curling.CurlingOptions.Single(opt => opt.DisplayLabel == shape);
            curling.Size = 10;
            curling.Shapes = 5;

            //Execute
            curling.ExecuteSimulateCommand();

            //Tests
            Assert.Empty(curling.Errors);
            Assert.False(string.IsNullOrEmpty(curling.TextOutput));
        }

        private void AssertError(string field, string message, Dictionary<string, string> errors, bool contains = true)
        {
            if(contains)
                Assert.Contains(new KeyValuePair<string, string>(field, message), errors);
            else
                Assert.DoesNotContain(new KeyValuePair<string, string>(field, message), errors);
        }
    }
}