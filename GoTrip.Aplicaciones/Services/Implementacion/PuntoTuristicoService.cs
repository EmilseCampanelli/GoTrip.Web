using AutoMapper;
using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Helper;
using GoTrip.Aplicaciones.Services.Interfaces;
using GoTrip.Aplicaciones.Validations;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using Microsoft.AspNetCore.Http;

namespace GoTrip.Aplicaciones.Services.Implementacion
{
    public class PuntoTuristicoService : IPuntoTuristicoService
    {

        private readonly IPuntoTuristicoRepository _puntosRepository;
        private readonly IMapper _mapper;
        private const int _usuarioId = 1; //TODO: Modificar por el codigo del usuario autenticado

        public PuntoTuristicoService(IPuntoTuristicoRepository repository, IRepository<Comentario> repoComentario, IRepository<Ubicacion> repoUbicacion, IMapper mapper)
        {
            _puntosRepository = repository;
            _mapper = mapper;
        }


        public async Task Activate(int id)
        {
            var puntoTuristico = await _puntosRepository.Get(id);
            BaseEntityHelper.SetActive(puntoTuristico, _usuarioId);
            await _puntosRepository.Update(puntoTuristico);
        }

        public async Task<bool> Exists(int id)
        {
            return await _puntosRepository.Get(id) != null;
        }

        public async Task<PuntoTuristicoDto> Get(int id)
        {
            var model = await _puntosRepository.GetPunto(id);
            var mapeo = _mapper.Map<PuntoTuristicoDto>(model);
            return mapeo;

        }

        public async Task Inactivate(int id)
        {
            var puntoTuristico = await _puntosRepository.Get(id);
            BaseEntityHelper.SetInactive(puntoTuristico, _usuarioId);
            await _puntosRepository.Update(puntoTuristico);
        }

        public async Task<PuntoTuristicoDto> Save(PuntoTuristicoDto dto)
        {
            PuntoTuristico puntoTuristico = new PuntoTuristico();

            if (dto.Id.Equals(0))
            {
                var newPuntoTuristico = _mapper.Map<PuntoTuristico>(dto);
                BaseEntityHelper.SetCreated(newPuntoTuristico, _usuarioId);
                puntoTuristico = await _puntosRepository.Add(newPuntoTuristico);
            }
            else
            {
                var updatedPuntoTuristico = _mapper.Map<PuntoTuristico>(dto);
                BaseEntityHelper.SetUpdated(updatedPuntoTuristico, _usuarioId);
                puntoTuristico = await _puntosRepository.Update(updatedPuntoTuristico);
            }

            return _mapper.Map<PuntoTuristicoDto>(puntoTuristico);
        }

        public async Task<string> PutImage(List<IFormFile> images, int id)
        {
            var pathImages = await SavePicture(images);

            var puntoTuristico = await _puntosRepository.Get(id);
            puntoTuristico.PathImagen = String.Join(",", pathImages);
            await _puntosRepository.Update(puntoTuristico);

            return String.Join(",", pathImages);
        }

        public async Task<List<string>> SavePicture(List<IFormFile> images)
        {
            var stringPath = new List<string>();

            if (!images.Any())
            {
                return stringPath;
            }

            foreach (var image in images)
            {
                if (image == null || image.Length == 0)
                {
                    continue;
                }

                try
                {
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    var imageName = $"{Path.GetFileNameWithoutExtension(image.FileName)}_{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                    var imagePath = Path.Combine(uploadFolder, imageName);

                    if (File.Exists(imagePath))
                    {
                        continue;
                    }

                    using (var stream = new FileStream(imagePath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                    {
                        await image.CopyToAsync(stream);
                    }

                    var relativePath = Path.Combine(uploadFolder, imageName);
                    Path.Combine(uploadFolder, Guid.NewGuid().ToString() + Path.GetExtension(image.FileName));
                    stringPath.Add(relativePath);

                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar la imagen", ex);
                }
            }

            return stringPath;
        }


        public async Task<(bool isValid, string message)> Validate(int? id, PuntoTuristicoDto dto)
        {
            var validations = new List<(bool isValid, string message)>();

            var validator = new PuntoTuristicoValidators();
            var result = await validator.ValidateAsync(dto);
            validations.Add((result.IsValid, string.Join(Environment.NewLine, result.Errors.Select(x => $"Campo {x.PropertyName} invalido. Error: {x.ErrorMessage}"))));

            return (isValid: validations.All(x => x.isValid),
                    message: string.Join(Environment.NewLine, validations.Where(x => !x.isValid).Select(x => x.message)));
        }

        public async Task<List<PuntoTuristicoDto>> GetAll()
        {
            var puntoTuristicos = await _puntosRepository.GetAll();
            return _mapper.Map<List<PuntoTuristicoDto>>(puntoTuristicos);
        }
    }
}
