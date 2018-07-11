using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoShare.Services
{
    public class AlbumService : IAlbumServise
    {
        private readonly PhotoShareContext context;
        private readonly IUserService userService;
        private readonly ITagService tagService;
        private readonly IAlbumTagService albumTagService;
        private readonly IAlbumUserService albumUserService;

        public AlbumService(PhotoShareContext context, IUserService userService, ITagService tagService, IAlbumTagService albumTagService, IAlbumUserService albumUserService)
        {
            this.context = context;
            this.userService = userService;
            this.tagService = tagService;
            this.albumTagService = albumTagService;
            this.albumUserService = albumUserService;
        }

        public Album GetAlbumByName(string albumTitle)
        {
            if (!Exist(albumTitle))
            {
                throw new ArgumentException($"Album {albumTitle} do not exist!");
            }

            return context.Albums.First(a => a.Name == albumTitle);
        }

        public Album GetAlbumById(int id)
        {
            Album album = context.Albums.Find(id);

            if (album == null)
            {
                throw new ArgumentException($"Album {id} not found!");
            }

            return album;
        }

        public Album CreateAlbum(string username, string albumTitle, string bgColor, params string[] tags)
        {
            User user = userService.GetUserByUsername(username);

            if (Exist(albumTitle))
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            bool isParsed = Enum.TryParse<Color>(bgColor, out Color color);
            if (!isParsed)
            {
                throw new ArgumentException($"Color {bgColor} not found!");
            }

            var tagsCollection = new List<Tag>();
            foreach (var tag in tags)
            {
                tagsCollection.Add(tagService.GetTagByName(tag));
            }

            Album album = new Album
            {
                Name = albumTitle,
                BackgroundColor = color,
            };

            context.Albums.Add(album);

            albumUserService.AddUserToAlbum(album, user);

            foreach (var tag in tagsCollection)
            {
                albumTagService.AddTagToAlbum(album, tag);
            }

            context.SaveChanges();

            return album;
        }

        public bool Exist(string albumName)
        {
            return context.Albums.Any(a => a.Name == albumName);
        }
    }
}