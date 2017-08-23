using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model.Base
{
    public class BaseView
    {
        public BaseView()
        {
            EntityId = Guid.NewGuid();
        }

        [ScaffoldColumn(false)]
        public Guid EntityId { get; set; }
    }
}