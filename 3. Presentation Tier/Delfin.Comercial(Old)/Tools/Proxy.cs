using BigStick.Http; //ATENCION A ESTA LINEA
//...

namespace Tramarsa.Cobros.Data.Services.POL
{
    public class ProxyPasarela : IDataServicePasarela
    {
        public RegistrarCargoResponse RegistrarCargo(RegistrarCargoRequest request)
        {
            RestDialer restDialer = new RestDialer();
            RegistrarCargoResponse response = restDialer.PostJSON<RegistrarCargoResponse, RegistrarCargoRequest>(request, ConfigReader.Proxy.Pasarela.RegistrarCargo, "");
            if (response == null)
                throw new Exception($"Servicio {ConfigReader.Proxy.Pasarela.RegistrarCargo} no disponible");

            return response;
        }
    }
}

/*
ConfigReader.Proxy.Pasarela.RegistrarCargo equivale a http://10.72.20.26:2424/IntegracionServicio.svc/RegistrarCargo
RegistrarCargoRequest es el request que envias al servicio 
RegistrarCargoResponse es lo que responde el servicio
*/