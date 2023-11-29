using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Bogus;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using Xunit;

namespace Tests.Repository
{
    public class Repository
    {
        private readonly Fixture _fixture;
        private readonly DataContext _context;
        private readonly Faker _faker;
        public Repository()
        {
            _fixture = new Fixture();
            _faker = new Faker();

            var dbOptions = new DbContextOptionsBuilder()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());

            _context = new DataContext(dbOptions.Options);
        }
        [Fact]
        public async Task GivenAUser_WhenTheCreateFunctionIsCalled_AddThisUserToTheList()
        {
            var user = _fixture.Create<User>();
            var repository = new BaseRepository<User>(_context);

            await repository.Create(user);

            var users = _context.Users.ToList();
            Assert.Single(users);
        }

        [Fact]
        public async Task GivenAUserId_WhenAUserExists_ReturnThisUserInformation()
        {
            var user = _fixture.Create<User>();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var repository = new BaseRepository<User>(_context);
            var userFound = await repository.GetById(user.Id);

            Assert.NotNull(userFound);
            Assert.Equal(user.Id, userFound.Id);
            Assert.Equal(user.Name, userFound.Name);
            Assert.Equal(user.Email, userFound.Email);
            Assert.Equal(user.CreatedAt, userFound.CreatedAt);
            Assert.Equal(user.UpdatedAt, userFound.UpdatedAt);

        }

        [Fact]
        public async Task GivenAUserId_WhenAUserDoesNotExist_ThrowAnOutOfRangeException()
        {
            var repository = new BaseRepository<User>(_context);

            await Assert.ThrowsAsync<IndexOutOfRangeException>(() => repository.GetById(_faker.Random.Int(1, 100)));
        }

        [Fact]
        public async Task GivenAUserId_WhenTheUserExistsInTheDatabase_ShouldRemoveTheUserFromTheList()
        {
            var repository = new BaseRepository<User>(_context);
            var user = _fixture.Create<User>();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            await repository.Delete(user.Id);

            var users = _context.Users.ToList();
            Assert.Empty(users);
        }
    }
}