namespace IRunes.Services
{
    using System.Linq;
    using IRunes.Models;
    using IRunes.ViewModels.Tracks;

    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext db;

        public TracksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string albumId, string name, string link, decimal price)
        {
            var track = new Track
            {
                AlbumId = albumId,
                Name = name,
                Link = link,
                Price = price,
            };

            this.db.Tracks.Add(track);

            var allTracksPricesSum = this.db.Tracks
                .Where(x => x.Id == albumId)
                .Sum(x => x.Price) + price;

            var album = this.db.Albums.Find(albumId);
            album.Price = allTracksPricesSum * 0.87M;

            this.db.SaveChanges();
        }

        public DetailsViewModel GetDetails(string trackId)
        {
            var track = this.db.Tracks.Where(x => x.Id == trackId)
                .Select(x => new DetailsViewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Link = x.Link,
                    AlbumId = x.AlbumId,
                }).FirstOrDefault();

                return track;
        }
    }
}
