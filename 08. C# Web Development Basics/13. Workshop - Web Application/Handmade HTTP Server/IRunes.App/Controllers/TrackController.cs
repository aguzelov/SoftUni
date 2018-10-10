using IRunes.Services.AlbumServices;
using IRunes.Services.TrackServices;
using IRunes.Services.UserCookieServices;
using IRunes.Services.UserServices;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using System.Net;

namespace IRunes.App.Controllers
{
    public class TrackController : BaseController
    {
        private readonly ITrackService trackService;
        private readonly IAlbumService albumService;
        private readonly IUserService UserService;
        private readonly IUserCookieService UserCookieService;

        public TrackController(ITrackService shoppingService, IAlbumService albumService, IUserService userService, IUserCookieService userCookieService)
        {
            this.trackService = shoppingService;
            this.albumService = albumService;
            UserService = userService;
            UserCookieService = userCookieService;
        }

        public IHttpResponse Create(IHttpRequest request)
        {
            if (!request.QueryData.ContainsKey("albumId"))
            {
                return this.View("Albums/All");
            }

            var id = request.QueryData["albumId"].ToString();

            var album = this.albumService.Get(id);

            if (album == null)
            {
                this.View("Albums/All");
            }

            this.ViewData["albumId"] = album.Id;

            if (request.RequestMethod == HttpRequestMethod.Get)
            {
                return this.View($"Tracks/Create");
            }

            var name = request.FormData["name"].ToString().Trim();
            var link = request.FormData["link"].ToString().Trim();
            var priceText = request.FormData["price"].ToString().Trim();

            if (!IsValidTrackData(name, link, priceText, out decimal price))
            {
                this.ViewData["errorDisplay"] = "none";
                return this.View($"Tracks/Create");
            }

            this.trackService.Add(name, link, price, album);

            return this.Redirect($"/Albums/Details?id={album.Id}");
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            if (!request.QueryData.ContainsKey("albumId"))
            {
                return this.View("Albums/All");
            }

            var albumId = request.QueryData["albumId"].ToString();

            if (!request.QueryData.ContainsKey("trackId"))
            {
                return this.Redirect($"/Albums/Details?id={albumId}");
            }

            var trackId = request.QueryData["trackId"].ToString();

            var track = this.trackService.GetTrackById(trackId);

            if (track == null)
            {
                return this.Redirect($"/Albums/Details?id={albumId}");
            }

            var url = WebUtility.UrlDecode(track.Link);
            var embededUrl = url.Replace("watch?v=", "embed/");

            this.ViewData["url"] = embededUrl;
            this.ViewData["name"] = WebUtility.UrlDecode(track.Name);
            this.ViewData["price"] = track.Price.ToString();

            this.ViewData["albumId"] = albumId;

            return this.View("Tracks/Details");
        }

        private bool IsValidTrackData(string name, string link, string priceText, out decimal price)
        {
            var isParsed = decimal.TryParse(priceText, out price);

            return string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(link) ||
                !isParsed
                ? false
                : true;
        }
    }
}