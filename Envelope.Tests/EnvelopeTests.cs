using System;
using Xunit;

namespace Envelope.Tests
{
    public class EnvelopeTests
    {
        [Theory]
        [InlineData(100, 90, 20, 30)]
        [InlineData(60, 50, 40, 40)]
        [InlineData(11, 9, 10, 8)]
        public void IsContainsTestPredictTrue
            (double firstHeight, double firstWidth, double secondHeight, double secondWidth)
        {
            Envelope firstEnvelope = new Envelope(firstHeight, firstWidth);
            Envelope secondEnvelope = new Envelope(secondHeight, secondWidth);

            bool expected = true;

            bool actual = firstEnvelope.IsContains(secondEnvelope);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(20, 10, 990, 30)]
        [InlineData(1, 1, 2, 5)]
        [InlineData(1, 9, 8, 8)]
        public void IsContainsTestPredictFalse
            (double firstHeight, double firstWidth, double secondHeight, double secondWidth)
        {
            Envelope firstEnvelope = new Envelope(firstHeight, firstWidth);
            Envelope secondEnvelope = new Envelope(secondHeight, secondWidth);

            bool expected = false;

            bool actual = firstEnvelope.IsContains(secondEnvelope);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConstructorThowArgumentExeptionTest()
        {
            Envelope envelope;

            Assert.Throws<ArgumentException>(() => envelope = new Envelope(0, 0));
        }
    }
}