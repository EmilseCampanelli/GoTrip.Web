using AutoMapper;
using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Helper;
using GoTrip.Aplicaciones.Services.Interfaces;
using GoTrip.Aplicaciones.Validations;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Implementacion
{
    public class CategoriaService : ICategoriaService
    {

        private readonly IRepository<Categoria> _repository;
        private readonly IMapper _mapper;
        private const int _usuarioId = 1; //TODO: Modificar por el codigo del usuario autenticado

        public CategoriaService(IRepository<Categoria> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task Activate(int id)
        {
            var categoria = await _repository.Get(id);
            BaseEntityHelper.SetActive(categoria, _usuarioId);
            _repository.Update(categoria);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repository.Get(id) != null;
        }

        public async Task<CategoriaDto> Get(int id)
        {
            var model = await _repository.Get(id);
            return _mapper.Map<CategoriaDto>(model);
        }

        public async Task Inactivate(int id)
        {
            var categoria = await _repository.Get(id);
            BaseEntityHelper.SetInactive(categoria, _usuarioId);
            _repository.Update(categoria);
        }

        public async Task<CategoriaDto> Save(CategoriaDto dto)
        {
            Categoria categoria;

            if (dto.Id.Equals(0))
            {
           
                categoria = _mapper.Map<Categoria>(dto);
                BaseEntityHelper.SetCreated(categoria, _usuarioId);
                await _repository.Add(categoria);
            }
            else
            {
              
                categoria = _mapper.Map<Categoria>(dto);
                BaseEntityHelper.SetUpdated(categoria, _usuarioId);
                _repository.Update(categoria);
            }

      
            return _mapper.Map<CategoriaDto>(categoria);
        }

        public async Task Delete(int id)
        {
            var categoria = await _repository.Get(id);
            if (categoria != null)
            {
                await _repository.Delete(categoria);
            }
        }

        public async Task<List<CategoriaDto>> GetActiveCategories()
        {
            var categoria = await _repository.GetAll();
            return _mapper.Map<List<CategoriaDto>>(categoria);
        }

        public async Task<(bool isValid, string message)> Validate(int? id, CategoriaDto dto)
        {
            var validations = new List<(bool isValid, string message)>();

            var validator = new CategoriaValidators();
            var result = await validator.ValidateAsync(dto);
            validations.Add((result.IsValid, string.Join(Environment.NewLine, result.Errors.Select(x => $"Campo {x.PropertyName} invalido. Error: {x.ErrorMessage}"))));

            return (isValid: validations.All(x => x.isValid),
                    message: string.Join(Environment.NewLine, validations.Where(x => !x.isValid).Select(x => x.message)));
        }

        public async Task<List<CategoriaDto>> GetAll()
        {
            var categoria = await _repository.GetAll();
            return _mapper.Map<List<CategoriaDto>>(categoria);
        }
    }
}
