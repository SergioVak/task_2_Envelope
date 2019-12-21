﻿using Xunit;

namespace Envelope.Tests
{
    public class EnvelopeValidatorTests
    {
        [Theory]
        [InlineData(21,2)]
        [InlineData(33,123)]
        [InlineData(-1, 10)]
        public void ValidateHeightAndWidthResultTrue(double height, double width)
        {
            EnvelopeValidator validator = new EnvelopeValidator();
            Envelope envelope = new Envelope(height, width);

            bool expected = true;
            bool actual = validator.Validate(envelope).IsValid;

            Assert.Equal(expected, actual);
        }
    }
}
