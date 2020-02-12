﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kapos_Restaurante_VCliente_Pruebas.Service
{
    class Producto
    {
        public int IVA { get; set; }
    }
    public static class ApirRestIva
    {
        public static int RescatarIva()
        {

            string url = "@https://apidint1920.azurewebsites.net/api/iva";
            var json = new WebClient().DownloadString(url);
            Producto x = JsonConvert.DeserializeObject<Producto>(json);
            return x.IVA;
        }
    }
}
