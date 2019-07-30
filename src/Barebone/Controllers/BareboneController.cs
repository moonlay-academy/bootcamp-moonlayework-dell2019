// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Barebone.ViewModels.Barebone;
using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Barebone.Controllers
{
    public class BareboneController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BareboneController(IStorage storage, IConfiguration configuration) : base(storage)
        {
            _configuration = configuration;
        }

        public ActionResult Index()
        {
            return this.View(new IndexViewModelFactory().Create());
        }
    }
}