using System;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    /// <summary>
    /// Сводное описание для PhoneNumberTests
    /// </summary>
    [TestFixture]
    public class PhoneNumberTests
    {
        private PhoneNumber _phoneNumber;
        
        [SetUp]
        public void InitPhoneNumber()
        {
            _phoneNumber = new PhoneNumber();
        }
        
        [Test]
        public void PhoneNumber_GoodPhoneNumber_ReturnsSamePhoneNumber()
        {
            //Setup
            var sourcePhoneNumber = 79996198754;
            var expectedPhoneNumber = sourcePhoneNumber;

            //Act
            _phoneNumber.Number = sourcePhoneNumber;
            var actualPhoneNumber = _phoneNumber.Number;

            //Assert
            Assert.AreEqual(expectedPhoneNumber, actualPhoneNumber);
        }

        [TestCase(87776665544)]
        [TestCase(877766655477777777)]
        public void PhoneNumber_BadPhoneNumber_ThrowsException(long wrongPhoneNumber)
        {
            //Assert
            Assert.Throws<ArgumentException>
            (
                //Act
                () => _phoneNumber.Number = wrongPhoneNumber
            );
        }
    }
}
