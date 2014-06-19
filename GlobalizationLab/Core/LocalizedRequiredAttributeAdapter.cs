using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalizationLab.Core
{
    public class LocalizedRequiredAttributeAdapter : RequiredAttributeAdapter
    {
        public LocalizedRequiredAttributeAdapter(
            ModelMetadata metadata,
            ControllerContext context,
            RequiredAttribute attribute
        )
            : base(metadata, context, attribute)
        {
            if (attribute.ErrorMessageResourceType == null)
                attribute.ErrorMessageResourceType = typeof(Resources.Resources);
            if (attribute.ErrorMessageResourceName == null)
                attribute.ErrorMessageResourceName = "PropertyValueRequired";
        }
    
    
    }
    
}