using SIS.Framework.Attributes.Methods;
using SIS.Framework.Services.UserCookieServices;
using SIS.HTTP.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using IRunes.Models;
using IRunes.Services.AlbumServices;
using SIS.Framework.ActionsResults.Base;

namespace IRunes.App.Controllers
{
    public class AlbumsController : BaseController
    {
        private const string CreateAlbumPage = "Create";
        private const string AllAlbumsPage = "All";
        private const string DetailAlbumPage = "Details";
        private readonly IAlbumService albumService;

        public AlbumsController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Create()
        {
            if (this.Request.RequestMethod == HttpRequestMethod.Get)
            {
                this.ViewModel["errorDisplay"] = "none";
                return this.View(CreateAlbumPage);
            }

            var name = this.Request.FormData["name"].ToString().Trim();
            var cover = this.Request.FormData["cover"].ToString().Trim();

            if (!IsValidAlbumData(name, cover))
            {
                this.ViewModel["errorDisplay"] = "inline";
                return this.View(CreateAlbumPage);
            }

            this.albumService.Add(name, cover);

            return this.RedirectToAction("/Albums/All");
        }

        [HttpGet]
        public IActionResult All()
        {
            ICollection<Album> albums = this.albumService.GetAll();

            if (albums.Count == 0)
            {
                this.ViewModel["albums"] = "There are currently no albums.";

                return this.View(AllAlbumsPage);
            }

            var albumsText = albums
                .Select(
                a => $"<div><strong><a href=\"/Albums/Details?id={a.Id}\">{a.Name}</a></strong></div>")
                .ToArray();

            this.ViewModel["albums"] = string.Join("</br>", albumsText);

            return this.View(AllAlbumsPage);
        }

        [HttpGet]
        public IActionResult Details()
        {
            if (!this.Request.QueryData.ContainsKey("id"))
            {
                return this.RedirectToAction("/Albums/All");
            }

            var id = this.Request.QueryData["id"].ToString();

            var album = this.albumService.Get(id);

            if (album == null)
            {
                return this.RedirectToAction("/Albums/All");
            }

            this.ViewModel["url"] = WebUtility.UrlDecode(album.Cover);
            this.ViewModel["name"] = album.Name;
            this.ViewModel["price"] = album.Tracks.Sum(t => t.Price).ToString();

            this.ViewModel["albumId"] = album.Id;

            var sb = new StringBuilder();
            var indexer = 1;
            foreach (var track in album.Tracks)
            {
                sb.Append($"<li><strong>{indexer}</strong>. <a href=\"/Tracks/Details?albumId={track.AlbumId}&trackId={track.Id}\">{WebUtility.UrlDecode(track.Name)}</a></li>");
                indexer++;
            }

            this.ViewModel["displayTracks"] = indexer == 1 ? "none" : "block";
            this.ViewModel["tracks"] = sb.ToString();

            return this.View(DetailAlbumPage);
        }

        private bool IsValidAlbumData(string name, string cover)
        {
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(cover);
        }
    }
}