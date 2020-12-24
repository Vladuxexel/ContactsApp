using System;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ProjectTest
    {
        [Test]
        public void SortContacts_GoodSort_ReturnSortedContacts()
        {
            //Setup
            var sourceProject = new Project();
            var phoneNumber = new PhoneNumber
            {
                Number = 78005553535
            };
            
            sourceProject.Contacts.Add(new Contact()
            {
                Name = "BName",
                Surname = "BSurname",
                BirthDate = new DateTime(1923, 02, 15),
                VkId = "B434234",
                Email = "Bhogger@bk.com",
                PhoneNumber = phoneNumber
            });
            sourceProject.Contacts.Add(new Contact()
            {
                Name = "CName",
                Surname = "CSurname",
                BirthDate = new DateTime(1923, 02, 15),
                VkId = "C434234",
                Email = "Chogger@bk.com",
                PhoneNumber = phoneNumber
            });
            sourceProject.Contacts.Add(new Contact()
            {
                Name = "AName",
                Surname = "ASurname",
                BirthDate = new DateTime(1923, 02, 15),
                VkId = "A434234",
                Email = "Ahogger@bk.com",
                PhoneNumber = phoneNumber
            });
            
            var expectedProject = new Project();
            
            foreach (var contact in sourceProject.Contacts)
            {
                expectedProject.Contacts.Add(contact.Clone() as Contact);
            }
            
            expectedProject.Contacts = new ObservableCollection<Contact>(
                expectedProject.Contacts.OrderBy(i => i.Surname));

            //Act
            var actualProject = new Project
            {
                Contacts = sourceProject.SortContactsBySurname(sourceProject.Contacts)
            };
            var expected = JsonConvert.SerializeObject(expectedProject);
            var actual = JsonConvert.SerializeObject(actualProject);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortContacts_GoodSortAndFind_ReturnSortedFoundContacts()
        {
            //Setup
            var sourceProject = new Project();
            var phoneNumber = new PhoneNumber
            {
                Number = 78005553535
            };

            sourceProject.Contacts.Add(new Contact()
            {
                Name = "BName",
                Surname = "BSurname",
                BirthDate = new DateTime(1923, 02, 15),
                VkId = "B434234",
                Email = "Bhogger@bk.com",
                PhoneNumber = phoneNumber
            });
            sourceProject.Contacts.Add(new Contact()
            {
                Name = "CName",
                Surname = "CSurname",
                BirthDate = new DateTime(1923, 02, 15),
                VkId = "C434234",
                Email = "Chogger@bk.com",
                PhoneNumber = phoneNumber
            });
            sourceProject.Contacts.Add(new Contact()
            {
                Name = "AName",
                Surname = "ASurname",
                BirthDate = new DateTime(1923, 02, 15),
                VkId = "A434234",
                Email = "Ahogger@bk.com",
                PhoneNumber = phoneNumber
            });

            var expectedProject = new Project();
            
            expectedProject.Contacts.Add(sourceProject.Contacts.First());

            //Act
            var actualProject = new Project()
            {
                Contacts = sourceProject.SortContactsBySurname(
                    "BName", sourceProject)
            };
            var expected = JsonConvert.SerializeObject(expectedProject);
            var actual = JsonConvert.SerializeObject(actualProject);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindBirthdayContacts_GoodFindBirthdayContacts_ReturnBirthdayContacts()
        {
            //Setup
            var sourceProject = new Project();
            var phoneNumber = new PhoneNumber
            {
                Number = 78005553535
            };

            var commonDate = new DateTime(1923, 02, 15);

            sourceProject.Contacts.Add(new Contact()
            {
                Name = "BName",
                Surname = "BSurname",
                BirthDate = commonDate,
                VkId = "B434234",
                Email = "Bhogger@bk.com",
                PhoneNumber = phoneNumber
            });
            sourceProject.Contacts.Add(new Contact()
            {
                Name = "CName",
                Surname = "CSurname",
                BirthDate = new DateTime(1923, 10, 15),
                VkId = "C434234",
                Email = "Chogger@bk.com",
                PhoneNumber = phoneNumber
            });
            sourceProject.Contacts.Add(new Contact()
            {
                Name = "AName",
                Surname = "ASurname",
                BirthDate = commonDate,
                VkId = "A434234",
                Email = "Ahogger@bk.com",
                PhoneNumber = phoneNumber
            });

            var expectedProject = new Project();

            expectedProject.Contacts.Add(sourceProject.Contacts.Last());
            expectedProject.Contacts.Add(sourceProject.Contacts.First());

            //Act
            var actualProject = new Project()
            {
                Contacts = sourceProject.FindBirthdayContacts(commonDate)
            };
            var expected = JsonConvert.SerializeObject(expectedProject);
            var actual = JsonConvert.SerializeObject(actualProject);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
