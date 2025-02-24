using AutoMapper;
using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Helper;
using GoTrip.Aplicaciones.Services.Interfaces;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using GoTrip.Dominio.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Implementacion
{
    public class EventoService : IEventoService
    {
        private readonly IRepository<Evento> _eventoRepository;
        private readonly IMapper _mapper;
        private const int _usuarioId = 1; // TODO: Modificar por el código del usuario autenticado

        public EventoService(
            IRepository<Evento> eventoRepository,
            IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        public async Task<EventoDto> Get(int id)
        {
            var evento = await _eventoRepository.Get(id);
            if (evento == null)
            {
                throw new KeyNotFoundException("El evento no existe.");
            }

            return _mapper.Map<EventoDto>(evento);
        }

        public async Task<bool> Exists(int id)
        {
            return await _eventoRepository.Get(id) != null;
        }

        public async Task Activate(int id)
        {
            var evento = await _eventoRepository.Get(id);
            BaseEntityHelper.SetActive(evento, _usuarioId);
            _eventoRepository.Update(evento);
        }

        public async Task Inactivate(int id)
        {
            var evento = await _eventoRepository.Get(id);
            BaseEntityHelper.SetInactive(evento, _usuarioId);
            _eventoRepository.Update(evento);
        }


        /// <summary>
        /// Guarda un evento en la base de datos.
        /// </summary>
        /// <param name="dto">Datos del evento</param>
        /// <returns>Evento creado o actualizado</returns>
        public async Task<EventoDto> Save(EventoDto dto)
        {
            Evento evento;

            if (dto.Id == 0)
            {
                evento = _mapper.Map<Evento>(dto);
                BaseEntityHelper.SetCreated(evento, _usuarioId);
                await _eventoRepository.Add(evento);
            }
            else
            {
                evento = await _eventoRepository.Get(dto.Id);
                if (evento == null)
                {
                    throw new KeyNotFoundException("El evento no existe.");
                }

                _mapper.Map(dto, evento);
                BaseEntityHelper.SetUpdated(evento, _usuarioId);
                _eventoRepository.Update(evento);
            }

            return _mapper.Map<EventoDto>(evento);
        }

        public Task<(bool isValid, string message)> Validate(int? id, EventoDto dto)
        {
            // Aquí puedes agregar lógica para validar el evento antes de guardarlo.
            // Por ejemplo, verificar que las fechas sean válidas o que las ubicaciones existan.
            throw new NotImplementedException();
        }

        public async Task<List<EventoDto>> GetAll()
        {
            var evento = await _eventoRepository.GetAll();
            return _mapper.Map<List<EventoDto>>(evento);
        }

        public async Task<string> PutImage(List<IFormFile> images, int id)
        {
            var pathImages = await SavePicture(images);

            var evento = await _eventoRepository.Get(id);
            evento.PathImagen = String.Join(",", pathImages);
            _eventoRepository.Update(evento);

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
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");



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

                    var imageUrl = $"/images/{imageName}";

                    stringPath.Add(imageUrl);

                }
                catch (Exception ex)
                {
                    throw new Exception("Error al guardar la imagen", ex);
                }
            }

            return stringPath;
        }
    }
}
