﻿using AutoMapper;
using CoinyProject.Application.AlbumServices.Interfaces;
using CoinyProject.Application.DTO;
using CoinyProject.Core.Domain.Entities;
using CoinyProject.Infrastructure.Data;
using CoinyProject.Infrastructure.Data.Migrations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoinyProject.Application.AlbumServices.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationDBContext _dBContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        private readonly string imageFolder = "albums/elements/";

        public AlbumService(ApplicationDBContext dBContext, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _webHostEnvironment = webHostEnvironment;
            _dBContext = dBContext;
            _mapper = mapper;
        }
        public async Task<string> ConvertToImageUrl(IFormFile image)
        {
            string folder = imageFolder + Guid.NewGuid().ToString() + "_" + image.FileName;

            await image.CopyToAsync(new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, folder), FileMode.Create));

            return "/" + folder;
        }

        public async Task<int> AddAlbum(AlbumCreating album)
        {
            var _album = _mapper.Map<Album>(album);

            await _dBContext.Albums.AddAsync(_album);
            await _dBContext.SaveChangesAsync();

            return _album.Id;
        }


        public async Task AddAlbumElement(AlbumElementCreating element)
        {
            var album = await _dBContext.Albums
                .Include(x => x.Elements)
                .Where(x => x.Id == element.AlbumId)
                .FirstOrDefaultAsync();

            if (album != null)
            {
                AlbumElement _albumElement = new AlbumElement()
                {
                    Name = element.Name,
                    Description = element.Description,
                    ImageURL = await ConvertToImageUrl(element.Image),
                };

                album.Elements.Add(_albumElement);
                await _dBContext.SaveChangesAsync();
            }
           
        }

        public async Task<IEnumerable<AlbumGetDTO>> GetAllAlbumsDTO()
        {
            var albums = await _dBContext.Albums
                .Include(x => x.Elements)
                .AsNoTracking()
                .ToListAsync();

            var albumsGetDTOList = new List<AlbumGetDTO>();

            foreach(Album album in albums)
            {
                albumsGetDTOList.Add(new AlbumGetDTO()
                {
                    Id = album.Id,
                    Name = album.Name,
                    Description = album.Description,
                    Rate = album.Rate,
                    TitleImageURL = album.Elements?.FirstOrDefault()?.ImageURL
                });
            }
            return albumsGetDTOList;
        }

        public async Task<AlbumGetByIdDTO> GetAlbumById(int id)
        {
            var album = await _dBContext.Albums
                .Where(x => x.Id == id)
                .Include(x => x.Elements)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            
            return _mapper.Map<AlbumGetByIdDTO>(album);
        }

        public async Task<AlbumEditDTO> GetAlbumForEdit(int id)
        {
            var album = await _dBContext.Albums
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return _mapper.Map<AlbumEditDTO>(album);
        }
        public async Task UpdateAlbum(AlbumEditDTO album)
        {
            var _album = await _dBContext.Albums
                .Where(x => x.Id == album.Id)
                .FirstOrDefaultAsync();

            if (_album != null)
            {
                _mapper.Map(album, _album);
                _dBContext.Albums.Update(_album);
                _dBContext.SaveChanges();
            }
        }

        public async Task DeleteAlbum(int id)
        {
            var album = await _dBContext.Albums
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _dBContext.Albums.Remove(album);
            _dBContext.SaveChanges();
        }

        public async Task<AlbumElementEditDTO> GetAlbumElementForEdit(int id)
        {
            var albumElement = await _dBContext.AlbumElements
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return _mapper.Map<AlbumElementEditDTO>(albumElement);

        }

        public async Task<int> UpdateAlbumElement(AlbumElementEditDTO element)
        {
            var _element = await _dBContext.AlbumElements
                .Where(x => x.Id == element.Id)
                .FirstOrDefaultAsync();

            _element.Name = element.Name;
            _element.Description = element.Description;

            if(element.Image != null)
                _element.ImageURL = await ConvertToImageUrl(element.Image);

            _dBContext.AlbumElements.Update(_element);
            _dBContext.SaveChanges();

            return _element.AlbumId;
        }

        public async Task<int> DeleteAlbumElement(int id)
        {
            var element = await _dBContext.AlbumElements
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            _dBContext.AlbumElements.Remove(element);
            _dBContext.SaveChanges();
            
            return element.AlbumId;
        }

        
    }
}
