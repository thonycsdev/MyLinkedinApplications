using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
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
        public Repository()
        {
            _fixture = new Fixture();

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
    }
}