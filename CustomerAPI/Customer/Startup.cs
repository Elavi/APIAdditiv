﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CustomerAPI.Startup))]

namespace CustomerAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
