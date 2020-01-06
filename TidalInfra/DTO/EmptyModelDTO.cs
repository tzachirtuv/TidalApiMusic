using OpenTidl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidalInfra.DTO
{
    public class EmptyModelDTO
    {
        public string ETag { get; set; }


        public static async Task<EmptyModelDTO> ConvertToDTO(Task<EmptyModel> emptyModel)
        {
            EmptyModel modle = await emptyModel;
            var res = new EmptyModelDTO()
            {
                ETag = modle.ETag
            };
            return res;
        }
    }
}
