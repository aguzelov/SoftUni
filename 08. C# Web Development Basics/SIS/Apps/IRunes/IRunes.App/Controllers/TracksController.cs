using IRunes.Services.AlbumServices;
using IRunes.Services.TrackServices;
using IRunes.Services.UserServices;
using SIS.Framework.Attributes.Methods;
using SIS.Framework.Services.UserCookieServices;
using SIS.HTTP.Enums;
using System.Net;
using SIS.Framework.ActionsResults.Base;

namespace IRunes.App.Controllers
{
    public class TracksController : BaseController
    {
        private const string AllAlbumsPage = "All";
        private const string TrackDetailsPage = "Details";
        private const string TrackCreatePage = "Create";
        private readonly ITrackService trackService;
        private readonly IAlbumService albumService;

        public TracksController(ITrackService shoppingService, IAlbumService albumService, IUserService userService)
        {
            this.trackService = shoppingService;
            this.albumService = albumService;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Create()
        {
            if (!this.Request.QueryData.ContainsKey("albumId"))
            {
                return this.RedirectToAction("/Albums/All");
            }

            var id = this.Request.QueryData["albumId"].ToString();

            var album = this.albumService.Get(id);

            if (album == null)
            {
                return this.RedirectToAction("/Albums/All");
            }

            this.ViewModel["albumId"] = album.Id;

            if (this.Request.RequestMethod == HttpRequestMethod.Get)
            {
                return this.View(TrackCreatePage);
            }

            var name = this.Request.FormData["name"].ToString().Trim();
            var link = this.Request.FormData["link"].ToString().Trim();
            var priceText = this.Request.FormData["price"].ToString().Trim();

            if (!IsValidTrackData(name, link, priceText, out decimal price))
            {
                this.ViewModel["errorDisplay"] = "none";
                return this.View(TrackCreatePage);
            }

            this.trackService.Add(name, link, price, album);

            return this.RedirectToAction($"/Tracks/Details?id={album.Id}");
        }

        [HttpGet]
        public IActionResult Details()
        {
            if (!this.Request.QueryData.ContainsKey("albumId"))
            {
                return this.RedirectToAction("/Albums/All");
            }

            var albumId = this.Request.QueryData["albumId"].ToString();

            if (!this.Request.QueryData.ContainsKey("trackId"))
            {
                return this.RedirectToAction($"/Tracks/Details?albumId={albumId}");
            }

            var trackId = this.Request.QueryData["trackId"].ToString();

            var track = this.trackService.GetTrackById(trackId);

            if (track == null)
            {
                return this.RedirectToAction($"/Tracks/Details?id={albumId}");
            }

            var url = WebUtility.UrlDecode(track.Link);
            var embededUrl = url.Replace("watch?v=", "embed/");

            this.ViewModel["url"] = embededUrl;
            this.ViewModel["name"] = WebUtility.UrlDecode(track.Name);
            this.ViewModel["price"] = track.Price.ToString();

            this.ViewModel["albumId"] = albumId;

            return this.View(TrackDetailsPage);
        }

        private bool IsValidTrackData(string name, string link, string priceText, out decimal price)
        {
            var isParsed = decimal.TryParse(priceText, out price);

            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(link) && isParsed;
        }
    }
}