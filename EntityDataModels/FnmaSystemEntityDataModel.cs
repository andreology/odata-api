using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using odata_poc.Entities;
using System;

namespace odata_poc.EntityDataModels{
    public class FnmaSystemEntityDataModel {
        public IEdmModel GetEntityDataModel() {
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "FnmaSystem";
            builder.ContainerName = "FnmaSystemContainer";

            builder.EntitySet<SystemInterface>("SystemInterface");
            builder.EntitySet<FnmaSystem>("FnmaSystem");
            
            builder.EntitySet<Account>("Account");
            builder.EntitySet<Property>("Property");

            return builder.GetEdmModel();
        }
    }
}