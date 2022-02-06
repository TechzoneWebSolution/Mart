//-----------------------------------------------------------------------
// <copyright file="DataModule.cs" company="Dexoc Solutions">
//     Copyright Dexoc Solutions. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Blog.Data
{
    using Autofac;
    using Blog.Data.Contract;

    /// <summary>
    /// Contract Class for DataModule.
    /// </summary>
    public class DataModule : Module
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
            builder.RegisterType<V1.CustomerDao>().As<AbstractCustomerDao>().InstancePerDependency();
            builder.RegisterType<V1.UserDao>().As<AbstractUserDao>().InstancePerDependency();
            builder.RegisterType<V1.OrderDetailsDao>().As<AbstractOrderDetailsDao>().InstancePerDependency();
            builder.RegisterType<V1.StateDao>().As<AbstractStateDao>().InstancePerDependency();
            builder.RegisterType<V1.DistrictDao>().As<AbstractDistrictDao>().InstancePerDependency();
            builder.RegisterType<V1.ProductTypeDao>().As<AbstractProductTypeDao>().InstancePerDependency();
            builder.RegisterType<V1.ProductsDao>().As<AbstractProductsDao>().InstancePerDependency();
            builder.RegisterType<V1.ProductStockLedgerDao>().As<AbstractProductStockLedgerDao>().InstancePerDependency();
            base.Load(builder);
        }
    }
}
