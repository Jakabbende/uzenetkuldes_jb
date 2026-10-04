using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Uzenetkuldo_jb.Models;

namespace Uzenetkuldo_jb
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "/uzenetek", ResponseFormat = WebMessageFormat.Json)]
        List<Uzenet> GetUzenetek();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/uzenet")]
        void AddUzenet(Uzenet uzenet);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/uzenet")]
        void UpdateUzenet(Uzenet uzenet);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/uzenet/{id}")]
        void DeleteUzenet(string id);
    }
}