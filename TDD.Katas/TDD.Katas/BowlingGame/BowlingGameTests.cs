using FluentAssertions;
using NUnit.Framework;

namespace TDD.Katas.BowlingGame
{
    [TestFixture]
    public class BowlingGameTests
    {
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }

        [Test]
        public void Game_WhenAllEmptyRolls_Returns0()
        {
            // Arranged
            const int expectedScoreValue = 0;

            RollMany(20, 0);

            // Act
            var result = _game.Score();

            // Assert
            result.Should().Be(expectedScoreValue);
        }

        [Test]
        public void Game_WhenAll20RolesAre1_Return20()
        {
            // Arrange
            const int expectedScoreValue = 20;

            // Act
            RollMany(20, 1);

            var result = _game.Score();

            // Assert 
            result.Should().Be(expectedScoreValue);
        }

        [Test]
        public void Game_WhenSingleSpare_ReturnsScoreWithDoubledPins()
        {
            // Arrange
            const int expectedScoreValue = 16;

            RollSpare();
            _game.Roll(3);
            RollMany(17, 0);

            // Act
            var result = _game.Score();

            // Assert
            result.Should().Be(expectedScoreValue);
        }

        [Test]
        public void Game_WhenStrike_GivesBonusTo2NexRolls()
        {
            // Arrange
            const int expectedScoreValue = 24;

            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);

            // Act
            var result = _game.Score();

            // Assert   
            result.Should().Be(expectedScoreValue);
        }

        [Test]
        public void Game_WhenAllStrikes_ReturnsMaxScore()
        {
            // Arrange
            const int expectedScoreValue = 300;
            RollMany(12, 10);

            // Act
            var result = _game.Score();

            // Assert
            result.Should().Be(expectedScoreValue);
        }

        private void RollMany(int n, int pins)
        {
            for (var i = 0; i < n; i++)
            {
                _game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }
    }
}