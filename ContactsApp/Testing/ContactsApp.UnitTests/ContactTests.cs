using NUnit.Framework;
using System;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTests
    {
        private Contact _contact;

        [SetUp]
        public void InitContact()
        {
            _contact = new Contact()
            {
                Surname = "Сидоров",
                Name = "Анатолий",
                BirthDate = new DateTime(1990, 02, 13),
                PhoneNumber = new PhoneNumber() { Number = 72344231132 },
                Email = "smth@mail.ru",
                VkId = "id/12312233"
            };
        }

        [Test]
        public void Name_GoodValue_ReturnsSameName()
        {
            //Setup
            const string sourceName = "Ivan";
            var expectedName = sourceName;

            //Act
            _contact.Name = sourceName;
            var actualName = _contact.Name;

            //Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Name_ChangeNameRegister_ReturnsRegisterChangedName()
        {
            //Setup
            const string sourceName = "ivan";
            const string expectedName = "Ivan";

            //Act
            _contact.Name = sourceName;
            var actualName = _contact.Name;

            //Assert
            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase("")]
        [TestCase("012345678901234567890123456789012345678901234567890123456789")]
        public void Name_BadValue_ThrowsException(string wrongName)
        {
            //Assert
            Assert.Throws<ArgumentException>
            (
                //Act
                () => _contact.Name = wrongName
            );
        }

        [Test]
        public void Surname_GoodValue_ReturnsSameSurname()
        {
            //Setup
            const string sourceSurname = "Sergeev";
            var expectedSurname = sourceSurname;

            //Act
            _contact.Surname = sourceSurname;
            var actualSurname = _contact.Surname;

            //Assert
            Assert.AreEqual(expectedSurname, actualSurname);
        }

        [Test]
        public void Surname_ChangeNameRegister_ReturnsRegisterChangedName()
        {
            //Setup
            const string sourceSurname = "sergeev";
            const string expectedSurname = "Sergeev";

            //Act
            _contact.Surname = sourceSurname;
            var actualSurname = _contact.Surname;

            //Assert
            Assert.AreEqual(expectedSurname, actualSurname);
        }

        [TestCase("")]
        [TestCase("012345678901234567890123456789012345678901234567890123456789")]
        public void Surname_BadValue_ThrowsException(string wrongSurname)
        {
            //Assert
            Assert.Throws<ArgumentException>
            (
                //Act
                () => _contact.Surname = wrongSurname
            );
        }

        [Test]
        public void PhoneNumber_GoodValue_ReturnsSamePhoneNumber()
        {
            //Setup
            var sourcePhoneNumber = 78005553535;
            var phoneNumber = new PhoneNumber();
            var expectedPhoneNumber = sourcePhoneNumber;
            phoneNumber.Number = sourcePhoneNumber;

            //Act
            _contact.PhoneNumber = phoneNumber;
            var actualPhoneNumber = _contact.PhoneNumber.Number;

            //Assert
            Assert.AreEqual(expectedPhoneNumber, actualPhoneNumber);
        }

        [Test]
        public void Email_GoodValue_ReturnsSameEmail()
        {
            //Setup
            const string sourceEmail = "email@mail.ru";
            const string expectedEmail = sourceEmail;

            //Act
            _contact.Email = sourceEmail;
            var actualEmail = _contact.Email;

            //Assert
            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [TestCase("")]
        [TestCase("012345678901234567890123456789012345678901234567890123456789")]
        public void Email_BadValue_ThrowsException(string wrongEmail)
        {
            //Assert
            Assert.Throws<ArgumentException>
            (
                //Act
                () => _contact.Email = wrongEmail
            );
        }

        [Test]
        public void VkId_GoodValue_ReturnsSameVkId()
        {
            //Setup
            const string sourceVkId = "id/12341223432";
            const string expectedVkId = sourceVkId;

            //Act
            _contact.VkId = sourceVkId;
            var actualVkId = _contact.VkId;

            //Assert
            Assert.AreEqual(expectedVkId, actualVkId);
        }

        [TestCase("")]
        [TestCase("012345678901234567890123456789012345678901234567890123456789")]
        public void VkId_BadValue_ThrowsException(string wrongVkId)
        {
            //Assert
            Assert.Throws<ArgumentException>
            (
                //Act
                () => _contact.VkId = wrongVkId
            );
        }

        [Test]
        public void BirthDate_GoodValue_ReturnsSameBirthDate()
        {
            //Setup
            var sourceBirthDate = DateTime.Today;
            var expectedBirthDate = sourceBirthDate;

            //Act
            _contact.BirthDate = sourceBirthDate;
            var actualBirthDate = _contact.BirthDate;

            //Assert
            Assert.AreEqual(expectedBirthDate, actualBirthDate);
        }

        [TestCase("01.01.2022")]
        [TestCase("01.01.1800")]
        public void BirthDate_BadValue_ThrowsException(DateTime wrongDate)
        {
            //Assert
            Assert.Throws<ArgumentException>
            (
                //Act
                () => _contact.BirthDate = wrongDate
            );
        }

        [Test]
        public void Clone_GoodClone_ReturnsSameObject()
        {
            //Setup
            var expectedContact = _contact;

            //Act
            var actualContact = expectedContact.Clone() as Contact;

            //Assert
            Assert.AreEqual(expectedContact, actualContact);
        }
    }
}
