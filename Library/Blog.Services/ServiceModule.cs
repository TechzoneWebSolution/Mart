//-----------------------------------------------------------------------
// <copyright file="ServiceModule.cs" company="Premiere Digital Services">
//     Copyright Premiere Digital Services. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Blog.Services
{
    using Autofac;    
    using Data;
    using Blog.Services.Contract;

    /// <summary>
    /// The Service module for dependency injection.
    /// </summary>
    public class ServiceModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {           
            builder.RegisterModule<DataModule>();
            
            builder.RegisterType<V1.UserServices>().As<AbstractUserServices>().InstancePerDependency();
            builder.RegisterType<V1.CustomerServices>().As<AbstractCustomerServices>().InstancePerDependency();
            builder.RegisterType<V1.OrderDetailsServices>().As<AbstractOrderDetailsServices>().InstancePerDependency();
            builder.RegisterType<V1.StateServices>().As<AbstractStateServices>().InstancePerDependency();
            builder.RegisterType<V1.DistrictServices>().As<AbstractDistrictServices>().InstancePerDependency();
            builder.RegisterType<V1.ProductTypeServices>().As<AbstractProductTypeServices>().InstancePerDependency();
            builder.RegisterType<V1.ProductsServices>().As<AbstractProductsServices>().InstancePerDependency();
            builder.RegisterType<V1.ProductStockLedgerServices>().As<AbstractProductStockLedgerServices>().InstancePerDependency();
          
            base.Load(builder);
        }
    }
}
