using TidalInfra.DTO;
using OpenTidl;
using OpenTidl.Methods;
using OpenTidl.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TidalInfra.DTO;

namespace TidalInfra
{
    public class PlaylistLogic
    {
        
        private readonly OpenTidlSession tidlSession;

        public PlaylistLogic(OpenTidlSession tidlSession)
        {
            this.tidlSession = tidlSession;
        }

        public async Task<PlaylistDto> CreateUserPlaylistWithTitle(string title)
        {
            var  playlistModel =  tidlSession.CreateUserPlaylist(title);
            PlaylistDto res = await PlaylistDto.ConvertToDTO(playlistModel);
            return res;
        }

        public async Task<EmptyModelDTO> AddPlaylistTracks( string playlistETag, IEnumerable<int> trackIds, int toIndex = 0)
        {
            var tt = await CreateUserPlaylistWithTitle("bob");
            Task<EmptyModel> playlistModel = tidlSession.AddPlaylistTracks(tt.Uuid, playlistETag, trackIds, toIndex);
            EmptyModelDTO res = await EmptyModelDTO.ConvertToDTO(playlistModel);
            return res;
        }
    }
}
