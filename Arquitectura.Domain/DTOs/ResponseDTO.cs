using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Arquitectura.Domain.DTOs
{
    public class ResponseDTO
    {
        public ResponseDTO()
        {
            Success = true;
            Status = StatusCodes.Status200OK;
        }

        public T? Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        [JsonIgnore]
        public int Status { get; set; }
    }
}
