using OpenTidl.Enums;
using OpenTidl.Models;
using System;
using System.Threading.Tasks;

namespace TidalInfra.DTO
{
    public class PlaylistDto
    {
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Id { get; set; }
        public int Image { get; set; }
        public int NumberOfTracks { get; set; }
        public long OfflineDateAdded { get; set; }
        public string Title { get; set; }
        public string Uuid { get; set; }
        public string Url { get; set; }
        public bool PublicPlayList { get; set; }
        public PlaylistTypeDTO Type { get; set; }
        public DateTime? Created { get; set; }
        public string LastUpdated { get; set; }


/*        private static PlaylistTypeDTO ConvertToDTO(PlaylistType playlistType)
        {
          //  PlaylistTypeDTO res = playlistType.
        }*/

        public static async Task<PlaylistDto> ConvertToDTO(Task<PlaylistModel> playlistModel)
        {
            var modle = await playlistModel;
            PlaylistDto res = new PlaylistDto
            {
                Created = modle.Created,
                Description = modle.Description,
/*                Type = modle.Type,
                Duration = modle.Duration,
                Id = modle.Id,
                Image = modle.Image,
                LastUpdated = modle.LastUpdated,*/
                NumberOfTracks = modle.NumberOfTracks,
                OfflineDateAdded = modle.OfflineDateAdded,
                PublicPlayList = modle.PublicPlaylist,
                Title = modle.Title,
                Url = modle.Url,
                Uuid = modle.Uuid
            };
            return res;
        }

    }

    public enum PlaylistTypeDTO
    {
        EDITORIAL = 0,
        PRIVATE = 1,
        USER = 2
    }

}
