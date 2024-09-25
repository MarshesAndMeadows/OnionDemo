/*using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionDemo.Application.AccommodationCommand;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.AccommodationCommand.CommandDTO;
using OnionDemo.Application.Helpers;
using OnionDemo.Application.HostQuery;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.AccommodationCommand.Tests
{
    [TestClass()]
    public class AccommodationCommandTests
    {
        [TestMethod()]
        public void AccommodationCommandTest()
        {
            var expectedHostId = 123;
            var expectedHost = new HostDto();
            var repository = new TestRepository();
            var work = new TestUnitOfWork();
            var cmd = new Command.AccommodationCommand(repository, work);
            var creaAccDTO = new CreateAccommodationDto();
            creaAccDTO.Host = expectedHost;
            expectedHost.Id = expectedHostId;

            cmd.CreateAccommodation(creaAccDTO);
            var saves = repository.GetAllSaves();
            Assert.AreEqual(1, saves.Count);

            var save = saves.First();
            Assert.IsNotNull(save.Host);
            
            int counter = work.GetCommitCount();
            Assert.AreEqual(1, counter);
            Assert.AreEqual(expectedHostId, save.Host.Id);
        }
    }
    public class TestUnitOfWork : IUnitOfWork
    {
        private int counter = 0;
        public void Commit()
        {
            counter++;
        }

        public int GetCommitCount()
        {
            return counter;
        }

        public void Rollback()
        {
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
        }

    }

    public class TestRepository : IAccommodationRepository
    {
        private readonly List<Accommodation> _accommodations = new List<Accommodation>();
        public List<Accommodation> GetAllSaves()
        {
            return _accommodations;
        }
        public Accommodation GetAccommodation(int id)
        {
            throw new NotImplementedException();
        }

        public void AddAccommodation(Accommodation accommodation)
        {
            _accommodations.Add(accommodation);
        }

        public void UpdateAccommodation(Accommodation accommodation, byte[] rowversion)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccommodation(Accommodation accommodation, byte[] rowversion)
        {
            throw new NotImplementedException();
        }

        Booking IAccommodationRepository.GetBooking(int id)
        {
            throw new NotImplementedException();
        }

        void IAccommodationRepository.AddBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        void IAccommodationRepository.UpdateBooking(Booking booking, byte[] rowversion)
        {
            throw new NotImplementedException();
        }

        void IAccommodationRepository.DeleteBooking(Booking booking, byte[] rowversion)
        {
            throw new NotImplementedException();
        }
    }
}*/