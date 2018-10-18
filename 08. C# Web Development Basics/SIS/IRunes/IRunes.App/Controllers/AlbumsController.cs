using IRunes.Models;
using IRunes.Services.AlbumServices;
using SIS.Framework.ActionResult.Contracts;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Services.UserCookieServices;
using SIS.HTTP.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace IRunes.App.Controllers
{
    public class AlbumsController : BaseController
    {
        private const string CreateAlbumPage = "Create";
        private const string AllAlbumsPage = "All";
        private const string DetailAlbumPage = "Details";
        private readonly IAlbumService albumService;

        public AlbumsController(IAlbumService albumService, IUserCookieService userCookieService)
          : base(userCookieService)
        {
            this.albumService = albumService;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Create()
        {
            if (this.Request.RequestMethod == HttpRequestMethod.Get)
            {
                this.Model["errorDisplay"] = "none";
                return this.View(CreateAlbumPage);
            }

            var name = this.Request.FormData["name"].ToString().Trim();
            var cover = this.Request.FormData["cover"].ToString().Trim();

            if (!IsValidAlbumData(name, cover))
            {
                this.Model["errorDisplay"] = "inline";
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
                this.Model["albums"] = "There are currently no albums.";

                return this.View(AllAlbumsPage);
            }

            var albumsText = albums
                .Select(
                a => $"<div><strong><a href=\"/Albums/Details?id={a.Id}\">{a.Name}</a></strong></div>")
                .ToArray();

            this.Model["albums"] = string.Join("</br>", albumsText);

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

            this.Model["url"] = WebUtility.UrlDecode(album.Cover);
            this.Model["name"] = album.Name;
            this.Model["price"] = album.Tracks.Sum(t => t.Price).ToString();

            this.Model["albumId"] = album.Id;

            var sb = new StringBuilder();
            var indexer = 1;
            foreach (var track in album.Tracks)
            {
                sb.Append($"<li><strong>{indexer}</strong>. <a href=\"/Tracks/Details?albumId={track.AlbumId}&trackId={track.Id}\">{WebUtility.UrlDecode(track.Name)}</a></li>");
                indexer++;
            }

            this.Model["displayTracks"] = indexer == 1 ? "none" : "block";
            this.Model["tracks"] = sb.ToString();

            return this.View(DetailAlbumPage);
        }

        private bool IsValidAlbumData(string name, string cover)
        {
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(cover);
        }
    }
}