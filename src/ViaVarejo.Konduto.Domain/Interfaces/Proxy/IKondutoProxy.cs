using ViaVarejo.Konduto.Domain.Models;

namespace ViaVarejo.Konduto.Domain.Interfaces.Proxy {

    public interface IKondutoProxy {

        void SendData (KondutoData kondutoData);
    }
}