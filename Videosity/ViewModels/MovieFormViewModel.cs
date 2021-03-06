﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using Videosity.Models;

namespace Videosity.ViewModels {
    public class MovieFormViewModel {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}