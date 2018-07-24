using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViaVarejo.Konduto.Domain.Models;
using ViaVarejo.Konduto.Domain.Services;

namespace ViaVarejo.Konduto.WebApi.Controllers {
    
    [Route ("api/konduto")]    
    public class KondutoController : Controller {
        
        private readonly KondutoService _kondutoService;

        public KondutoController (KondutoService kondutoService) {
            _kondutoService = kondutoService;
        }

        [HttpPost]
        [Route("send-data")]
        public void SendData ([FromBody] KondutoData kondutoData) {
            _kondutoService.SendData(kondutoData);
        }
    }
}