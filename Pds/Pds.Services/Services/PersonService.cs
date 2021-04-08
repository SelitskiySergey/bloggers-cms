using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Core.Enums;
using Pds.Core.Exceptions;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

namespace Pds.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        private static PersonServiceException UnableToUnarchiveNonArchivedPersonException =>
            new("nableToUnarchiveNonArchived",
                "Персона еще не архивирована",
                400,
                new Dictionary<string, object>(1)
                {
                    {
                        "Status", "Персона уже архивирована. Разархивировать неархивированную персону невозможно."
                    }
                });
        private static PersonServiceException PersonAlreadyArchivedException => 
            new("PersonAlreadyArchived",
                "Персона уже архивирована",
                400,
                new Dictionary<string, object>(1)
                {
                    {
                        "Status", "Персона уже архивирована. Архивация не требуется."
                    }
                });
        private static PersonServiceException WrongCountOfBrandsException =>
            new("InvalidBrandCount",
                "Отсутствуют выбранные бренды",
                400,
                new Dictionary<string, object>(1)
                {
                    {
                        "Brands", "У персоны обязательно должен хотя бы один бренд"
                    }
                });

        public async Task<List<Person>> GetAllAsync()
        {
            return await unitOfWork.Persons.GetAllWithResourcesAsync();
        }

        public async Task<Guid> CreateAsync(Person person)
        {
            if (person.Brands.Count == 0) throw WrongCountOfBrandsException;

            // Restore brands from DB
            var brandsFromApi = person.Brands;
            var brandsFromBd = new List<Brand>();
            foreach (var brandFromApi in brandsFromApi)
            {
                var brandFromDb = await unitOfWork.Brands.GetFirstWhereAsync(c => c.Id == brandFromApi.Id);
                if (brandFromDb != null) brandsFromBd.Add(brandFromDb);
            }

            person.Brands = brandsFromBd;
            person.CreatedAt = DateTime.UtcNow;
            var result = await unitOfWork.Persons.InsertAsync(person);

            return result.Id;
        }

        public async Task ArchiveAsync(Guid personId)
        {
            var person = await unitOfWork.Persons.GetFirstWhereAsync(p => p.Id == personId);
            if (person == null)
                throw ExceptionHelper.CreateNotFoundException(nameof(Person));
            if (person.Status == PersonStatus.Archived)
                throw PersonAlreadyArchivedException;
            person.Status = PersonStatus.Archived;
            person.ArchivedAt = DateTime.UtcNow;
            await unitOfWork.Persons.UpdateAsync(person);
        }

        public async Task UnarchiveAsync(Guid personId)
        {
            var person = await unitOfWork.Persons.GetFirstWhereAsync(p => p.Id == personId);
            if (person == null)
                throw ExceptionHelper.CreateNotFoundException(nameof(Person));
            if (person.Status != PersonStatus.Archived)
                throw UnableToUnarchiveNonArchivedPersonException;
            person.Status = PersonStatus.Active;
            person.UnarchivedAt = DateTime.UtcNow;
            await unitOfWork.Persons.UpdateAsync(person);
        }


        public async Task DeleteAsync(Guid personId)
        {
            var person = await unitOfWork.Persons.GetFirstWhereAsync(p => p.Id == personId);
            if (person == null)
                throw ExceptionHelper.CreateNotFoundException(nameof(Person));
            if (person.Status != PersonStatus.Archived)
                throw UnableToUnarchiveNonArchivedPersonException;
                    
            await unitOfWork.Persons.Delete(person);
        }

        public async Task<List<Person>> GetPersonsForListsAsync()
        {
            var persons = new List<Person> {new() {Id = Guid.Empty}};
            var personsFromDb = await unitOfWork.Persons.GetForListsAsync();
            persons.AddRange(personsFromDb);

            return persons;
        }
    }
}