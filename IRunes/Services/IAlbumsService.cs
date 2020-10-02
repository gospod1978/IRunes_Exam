namespace IRunes.Services
{
    using System.Collections.Generic;
    using IRunes.ViewModels.Albums;

    public interface IAlbumsService
    {
        void Create(string name, string cover);

        IEnumerable<AlbumInfoViewModel> GetAll();

        AlbumDetailsViewModel GetDetails(string id);
    }
}
