using SIS.App.IRunes.Models;
using SIS.App.IRunes.Services.AlbumServices;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SIS.App.IRunes.App.Controllers
{
    public class AlbumController : BaseController
    {
        private readonly IAlbumService albumService;

        public AlbumController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        public IHttpResponse Create(IHttpRequest request)
        {
            if (request.RequestMethod == HttpRequestMethod.Get)
            {
                this.ViewData["errorDisplay"] = "none";
                return this.View("Albums/Create");
            }

            var name = request.FormData["name"].ToString().Trim();
            var cover = request.FormData["cover"].ToString().Trim();

            if (!IsValidAlbumData(name, cover))
            {
                this.ViewData["errorDisplay"] = "inline";
                return this.View("Albums/Create");
            }

            this.albumService.Add(name, cover);

            return this.View("Albums/Create");
        }

        public IHttpResponse All(IHttpRequest request)
        {
            ICollection<Album> albums = this.albumService.GetAll();

            if (albums.Count == 0)
            {
                this.ViewData["albums"] = "There are currently no albums.";

                return this.View("Albums/All");
            }

            var albumsText = albums
                .Select(
                a => $"<div><strong><a href=\"/Albums/Details?id={a.Id}\">{a.Name}</a></strong></div>")
                .ToArray();

            this.ViewData["albums"] = string.Join("</br>", albumsText);

            return this.View("Albums/All");
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            if (!request.QueryData.ContainsKey("id"))
            {
                return this.Redirect("/Albums/All");
            }

            var id = request.QueryData["id"].ToString();

            var album = this.albumService.Get(id);

            if (album == null)
            {
                return this.Redirect("/Albums/All");
            }

            this.ViewData["url"] = WebUtility.UrlDecode(album.Cover);
            this.ViewData["name"] = album.Name;
            this.ViewData["price"] = album.Tracks.Sum(t => t.Price).ToString();

            this.ViewData["albumId"] = album.Id;

            var sb = new StringBuilder();
            int indexer = 1;
            foreach (var track in album.Tracks)
            {
                sb.Append($"<li><strong>{indexer}</strong>. <a href=\"/Tracks/Details?albumId={track.AlbumId}&trackId={track.Id}\">{WebUtility.UrlDecode(track.Name)}</a></li>");
                indexer++;
            }

            this.ViewData["displayTracks"] = indexer == 1 ? "none" : "block";
            this.ViewData["tracks"] = sb.ToString();

            return this.View("Albums/Details");
        }

        private bool IsValidAlbumData(string name, string cover)
        {
            return string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(cover)
                ? false
                : true;
        }
    }
}